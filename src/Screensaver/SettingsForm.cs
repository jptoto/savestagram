using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace ScreenSaver
{
    public partial class SettingsForm : Form
    {
        #region Constructor

        public SettingsForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.LoadSettings();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SaveSettings();
            Application.Exit();
        }

        #endregion

        #region Methods

        private void LoadSettings()
        {
            try
            {
                // Create an instance of the Settings class
                Settings settings = new Settings();

                // Load the settings
                settings.LoadSettings();

                // Set the selected item in the combo 
                switch (settings.AllowedShapes)
                {
                    case Settings.Shapes.All:
                        cboShape.SelectedItem = "All";
                        break;
                    case Settings.Shapes.Circles:
                        cboShape.SelectedItem = "Circles";
                        break;
                    case Settings.Shapes.Ellipses:
                        cboShape.SelectedItem = "Ellipses";
                        break;
                    case Settings.Shapes.Rectangles:
                        cboShape.SelectedItem = "Rectangles";
                        break;
                    case Settings.Shapes.Squares:
                        cboShape.SelectedItem = "Squares";
                        break;
                    default:
                        cboShape.SelectedItem = "All";
                        break;
                }

                // Set the selected item in the combo 
                switch (settings.DrawSpeed)
                {
                    case Settings.Speed.Custom:
                        cboSpeed.SelectedItem = "Custom";
                        break;
                    case Settings.Speed.Fast:
                        cboSpeed.SelectedItem = "Fast";
                        break;
                    case Settings.Speed.Normal:
                        cboSpeed.SelectedItem = "Normal";
                        break;
                    case Settings.Speed.Slow:
                        cboSpeed.SelectedItem = "Slow";
                        break;
                    default:
                        cboSpeed.SelectedItem = "Normal";
                        break;
                }

                // Set the remaining settings
                mtxtCustomSpeed.Text = settings.CustomSpeed.ToString();
                chkUseTransparency.Checked = settings.UseTransparency;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error loading settings! {0}", ex.Message), "Dave on C# Screen Saver", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSettings()
        {
            try
            {
                // Create an instance of the Settings class
                Settings settings = new Settings();

                // Set the enum according to the selected value in the combo
                switch (cboShape.SelectedItem.ToString().ToLower())
                {
                    case "all":
                        settings.AllowedShapes = Settings.Shapes.All;
                        break;
                    case "circles":
                        settings.AllowedShapes = Settings.Shapes.Circles;
                        break;
                    case "ellipses":
                        settings.AllowedShapes = Settings.Shapes.Ellipses;
                        break;
                    case "rectangles":
                        settings.AllowedShapes = Settings.Shapes.Rectangles;
                        break;
                    case "squares":
                        settings.AllowedShapes = Settings.Shapes.Squares;
                        break;
                    default:
                        settings.AllowedShapes = Settings.Shapes.All;
                        break;
                }

                // Set the enum according to the selected value in the combo
                switch (cboSpeed.SelectedItem.ToString().ToLower())
                {
                    case "custom":
                        settings.DrawSpeed = Settings.Speed.Custom;
                        break;
                    case "fast":
                        settings.DrawSpeed = Settings.Speed.Fast;
                        break;
                    case "normal":
                        settings.DrawSpeed = Settings.Speed.Normal;
                        break;
                    case "slow":
                        settings.DrawSpeed = Settings.Speed.Slow;
                        break;
                    default:
                        settings.DrawSpeed = Settings.Speed.Normal;
                        break;
                }

                // If the selecte draw speed is set to "Custom" then
                // save the custom speed else save 0.
                if (settings.DrawSpeed == Settings.Speed.Custom)
                {
                    int customSpeed = 0;
                    int.TryParse(mtxtCustomSpeed.Text, out customSpeed);
                    settings.CustomSpeed = customSpeed;
                }
                else
                {
                    settings.CustomSpeed = 0;
                }

                settings.UseTransparency = chkUseTransparency.Checked;

                // Save the settings
                settings.SaveSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error saving settings! {0}", ex.Message), "Dave on C# Screen Saver", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
