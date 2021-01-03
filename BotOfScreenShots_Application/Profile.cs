using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BotOfScreenShots_Application
{
    public class Profile
    {
        #region Prop

        public static int ID;

        const string FILESPATH = @"./Files/";

        private string _name;
        private string _localPath;
        private string[] _code;
        private Rectangle _workArea;
        private bool _isPreview;
        private bool _isDeveloperMode;
        private bool _isSaved = true;

        public string Name { get => _name; set => _name = value; }
        public string LocalPath { get => _localPath; set => _localPath = value; }
        public string[] Code { get => _code; set => _code = value; }
        public Rectangle WorkArea { get => _workArea; set => _workArea = value; }
        public bool IsPreview { get => _isPreview; set => _isPreview = value; }
        public bool IsDeveloperMode { get => _isDeveloperMode; set => _isDeveloperMode = value; }
        [XmlIgnore]
        public bool IsSaved { get => _isSaved; private set => _isSaved = value; }

        #endregion

        #region ctor

        public Profile() 
        {
            ID++;
        }

        public Profile(string Name) : this()
        {
            _name = Name;
            _localPath = FILESPATH + Name;
            _workArea = Screen.PrimaryScreen.Bounds;
            _isPreview = true;
            _isDeveloperMode = false;
            _isSaved = true;
        }

        #endregion

        /// <summary>
        /// Change profile name and it folder path
        /// </summary>
        /// <param name="newName">New profile name</param>
        public void ChangeName(string newName)
        {
            //zmiana starego folderu na nową nazwę
            _name = newName;
        }

        /// <summary>
        /// Checks if save variable is turned true
        /// </summary>
        public void InitializeSave()
        {
            if (_isSaved)
                _isSaved = false;
        }

        /// <summary>
        /// Marks profile to save
        /// </summary>
        public void Save()
        {
            _isSaved = true;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
