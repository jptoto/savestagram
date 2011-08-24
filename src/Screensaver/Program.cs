using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenSaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Check for any passed arguments
            if (args.Length > 0)
            {
                switch (args[0].ToLower().Trim().Substring(0, 2))
                {
                    // Preview the screen saver
                    case "/p":
                        // args[1] is the handle to the preview window
                        ScreenSaverForm screenSaverForm = new ScreenSaverForm(new IntPtr(long.Parse(args[1])));
                        screenSaverForm.ShowDialog();
                        Application.Run();
                        break;

                    // Show the screen saver
                    case "/s":
                        RunScreensaver();
                        break;

                    // Configure the screesaver's settings
                    case "/c":
                        // Show the settings form
                        SettingsForm settingsForm = new SettingsForm();
                        settingsForm.ShowDialog();
                        break;

                    // Show the screen saver
                    default:
                        RunScreensaver();
                        break;
                }
            }
            else
            {
                // No arguments were passed so we show the screensaver anyway
                RunScreensaver();
            }
        }

        private static void RunScreensaver()
        {
            int i = System.Windows.Forms.Screen.AllScreens.Count();
            Dictionary<int, ScreenSaverForm> screenMap = new Dictionary<int,ScreenSaverForm>();

            for (int x = 0; x < i; x++)
            {
                screenMap[x] = new ScreenSaverForm();
            }

            int j = 0;
            foreach (System.Windows.Forms.Screen screen in System.Windows.Forms.Screen.AllScreens)
            {
                screenMap[j].Left = screen.Bounds.Width;
                screenMap[j].Top = screen.Bounds.Height;
                screenMap[j].Location = screen.Bounds.Location;
                Point p = new Point(screen.Bounds.Location.X, screen.Bounds.Location.Y);
                screenMap[j].Location = p;
                screenMap[j].Show();
                j++;
            }

            Application.Run();
        }
    }
}