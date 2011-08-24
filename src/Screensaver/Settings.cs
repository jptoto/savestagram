using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Forms;

namespace ScreenSaver
{
    public class Settings
    {
        #region Enumerations

        public enum Shapes
        {
            Squares,
            Rectangles,
            Circles,
            Ellipses,
            All
        }

        public enum Speed
        {
            Slow,
            Normal,
            Fast,
            Custom
        }

        #endregion

        #region Private Members

        private Shapes allowedShapes;
        private Speed drawSpeed;
        private int customSpeed;
        private bool useTransparency;
        private string settingsPath = Application.UserAppDataPath + "\\screensaver.xml";

        #endregion

        #region Public Properties

        public Shapes AllowedShapes
        {
            get { return this.allowedShapes; }
            set { this.allowedShapes = value; }
        }

        public Speed DrawSpeed
        {
            get { return this.drawSpeed; }
            set { this.drawSpeed = value; }
        }

        public int CustomSpeed
        {
            get { return this.customSpeed; }
            set { this.customSpeed = value; }
        }

        public bool UseTransparency
        {
            get { return this.useTransparency; }
            set { this.useTransparency = value; }
        }

        #endregion

        #region Constructor

        public Settings()
        {
            this.allowedShapes = Shapes.All;
            this.customSpeed = 0;
            this.drawSpeed = Speed.Normal;
            this.useTransparency = true;
        }

        #endregion

        #region Methods

        public void LoadSettings()
        {
            try
            {
                // Create an instance of the Settings class
                Settings settings = new Settings();

                if (File.Exists(this.settingsPath))
                {
                    // Create an instance of System.Xml.Serialization.XmlSerializer
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));

                    // Create an instance of System.IO.StreamReader 
                    // to point to the settings file on disk
                    StreamReader textReader = new StreamReader(this.settingsPath);

                    // Create an instance of System.Xml.XmlTextReader
                    // to read from the StreamReader
                    XmlTextReader xmlReader = new XmlTextReader(textReader);

                    if (serializer.CanDeserialize(xmlReader))
                    {
                        // Assign the deserialized object to the new settings object
                        settings = ((Settings)serializer.Deserialize(xmlReader));

                        this.allowedShapes = settings.AllowedShapes;
                        this.drawSpeed = settings.DrawSpeed;
                        this.customSpeed = settings.CustomSpeed;
                        this.useTransparency = settings.UseTransparency;
                    }
                    else
                    {
                        // Save a new settings file
                        this.SaveSettings();
                    }

                    // Close the XmlTextReader
                    xmlReader.Close();
                    // Close the XmlTextReader
                    textReader.Close();
                }
                else
                {
                    // Save a new settings file
                    this.SaveSettings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error retrieving deserialized settings! {0}", ex.Message), "Dave on C# Screen Saver", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveSettings()
        {
            try
            {
                // Create an instance of the Settings class
                Settings settings = new Settings();

                settings.AllowedShapes = this.allowedShapes;
                settings.DrawSpeed = this.drawSpeed;

                if (settings.DrawSpeed == Settings.Speed.Custom)
                    settings.CustomSpeed = this.customSpeed;
                else
                    settings.CustomSpeed = 0;

                settings.UseTransparency = this.useTransparency;

                // Create an instance of System.Xml.Serialization.XmlSerializer
                XmlSerializer serializer = new XmlSerializer(settings.GetType());

                // Create an instance of System.IO.TextWriter
                // to save the serialized object to disk
                TextWriter textWriter = new StreamWriter(this.settingsPath);

                // Serialize the settings object
                serializer.Serialize(textWriter, settings);

                // Close the TextWriter
                textWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error saving serialized settings! {0}", ex.Message), "Dave on C# Screen Saver", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
