using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ScreenSaver
{
    public partial class ScreenSaverForm : Form
    {
        #region Preview Window Declarations

        // Changes the parent window of the specified child window
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        // Changes an attribute of the specified window
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        // Retrieves information about the specified window
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        // Retrieves the coordinates of a window's client area
        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        #endregion

        #region Private Members

        // Graphics object to use for drawing
        private Graphics graphics;

        // Random object for randomizing drawings
        private Random random;

        // Settings object which contains the screensaver settings
        private Settings settings;

        // Flag used to for initially setting mouseMove location
        private bool active;

        // Used to determine if the Mouse has actually been moved
        private Point mouseLocation;

        // Used to indicate if screensaver is in Preview Mode
        private bool previewMode = false;

        #endregion

        #region Constructors

        public ScreenSaverForm()
        {
            InitializeComponent();
           
        }

        public ScreenSaverForm(IntPtr previewHandle)
        {
            InitializeComponent();

            // Set the preview window of the screen saver selection 
            // dialog in Windows as the parent of this form.
            SetParent(this.Handle, previewHandle);

            // Set this form to a child form, so that when the screen saver selection 
            // dialog in Windows is closed, this form will also close.
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            // Set the size of the screen saver to the size of the screen saver 
            // preview window in the screen saver selection dialog in Windows.
            Rectangle ParentRect;
            GetClientRect(previewHandle, out ParentRect);
            this.Size = ParentRect.Size;

            this.Location = new Point(0, 0);

            this.previewMode = true;
        }

        #endregion

        #region Events

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialise private members
                this.random = new Random();
                this.settings = new Settings();
                this.settings.LoadSettings();
                this.active = false;

                // Hide the cursor
                Cursor.Hide();

                // Create the Graphics object to use when drawing.
                this.graphics = this.CreateGraphics();

                // Set the draw speed from the settings file
                switch (this.settings.DrawSpeed)
                {
                    case Settings.Speed.Custom:
                        tmrMain.Interval = this.settings.CustomSpeed;
                        break;
                    case Settings.Speed.Fast:
                        tmrMain.Interval = 100;
                        break;
                    case Settings.Speed.Normal:
                        tmrMain.Interval = 200;
                        break;
                    case Settings.Speed.Slow:
                        tmrMain.Interval = 500;
                        break;
                }



                // Enable the timer.
                tmrMain.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error loading screen saver! {0}", ex.Message), "Dave on C# Screen Saver", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.previewMode)
            {
                // If the mouseLocation still points to 0,0, move it to its actual 
                // location and save the location. Otherwise, check to see if the user
                // has moved the mouse at least 10 pixels.
                if (!this.active)
                {
                    this.mouseLocation = new Point(e.X, e.Y);
                    this.active = true;
                }
                else
                {
                    if ((Math.Abs(e.X - this.mouseLocation.X) > 10) ||
                        (Math.Abs(e.Y - this.mouseLocation.Y) > 10))
                    {
                        // Exit the screensaver
                        Application.Exit();
                    }
                }
            }
        }

        private void ScreenSaverForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.previewMode)
            {
                // Exit the screensaver if not in preview mode
                Application.Exit();
            }
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            this.DrawShape();
        }

        #endregion

        #region Methods

        private void DrawShape()
        {
            try
            {
                // Rectangle object for painting shapes in
                Rectangle rect;

                // Color object used for colouring the shapes
                Color colour;

                // Generate random coordinates for drawing shapes
                int x1 = random.Next(0, this.Width);
                int x2 = random.Next(0, this.Width);
                int y1 = random.Next(0, this.Height);
                int y2 = random.Next(0, this.Height);

                // Get smaller coordinates
                int x = Math.Min(x1, x2);
                int y = Math.Min(y1, y2);

                // Get smallest dimension for use when drawing in rectangles of equal sides
                int smallerSide = Math.Min(Math.Abs(x1 - x2), Math.Abs(y1 - y2));

                // Generate a random shape to display when user selects All shapes
                int allId = random.Next(0, 4);

                if (this.settings.UseTransparency)
                {
                    // Generate a random colour with a random level of transparency
                    colour = Color.FromArgb(this.random.Next(255),
                                            this.random.Next(255),
                                            this.random.Next(255),
                                            this.random.Next(255));
                }
                else
                {
                    // Generate a random colour with no transparency
                    colour = Color.FromArgb(255,
                                            this.random.Next(255),
                                            this.random.Next(255),
                                            this.random.Next(255));
                }

                // Create a coloured brush
                SolidBrush brush = new SolidBrush(colour);

                // Display shapes according to settings
                switch (this.settings.AllowedShapes)
                {
                    case Settings.Shapes.Circles:
                        // Draw a circle
                        rect = new Rectangle(x, y, smallerSide, smallerSide);
                        graphics.FillEllipse(brush, rect);
                        break;

                    case Settings.Shapes.Ellipses:
                        // Draw an ellipse
                        rect = new Rectangle(x, y, Math.Abs(x1 - x2), Math.Abs(y1 - y2));
                        graphics.FillEllipse(brush, rect);
                        break;

                    case Settings.Shapes.Rectangles:
                        // Draw a rectangle
                        rect = new Rectangle(x, y, Math.Abs(x1 - x2), Math.Abs(y1 - y2));
                        graphics.FillRectangle(brush, rect);
                        break;

                    case Settings.Shapes.Squares:
                        // Draw a square
                        rect = new Rectangle(x, y, smallerSide, smallerSide);
                        graphics.FillRectangle(brush, rect);
                        break;

                    case Settings.Shapes.All:
                        // Draw all the different type of shapes
                        if (allId == 0)
                        {
                            // Draw a circle
                            rect = new Rectangle(x, y, smallerSide, smallerSide);
                            graphics.FillEllipse(brush, rect);
                        }
                        else if (allId == 1)
                        {
                            // Draw an ellipse
                            rect = new Rectangle(x, y, Math.Abs(x1 - x2), Math.Abs(y1 - y2));
                            graphics.FillEllipse(brush, rect);
                        }
                        else if (allId == 2)
                        {
                            // Draw a rectangle
                            rect = new Rectangle(x, y, Math.Abs(x1 - x2), Math.Abs(y1 - y2));
                            graphics.FillRectangle(brush, rect);
                        }
                        else
                        {
                            // Draw a square
                            rect = new Rectangle(x, y, smallerSide, smallerSide);
                            graphics.FillRectangle(brush, rect);
                        }

                        break;
                }
            }
            catch
            { }
        }

        #endregion
    }
}
