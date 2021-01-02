using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BotOfScreenShots_Application
{
    public class Profile
    {
        public static int ID;

        const string FILESPATH = @"./Files/";

        private string _name;
        private string _localPath;
        private string[] _code;
        private Rectangle _workArea;
        private bool _isPreview;
        private bool _isDeveloperMode;
        private bool _isToEdit;

        public string Name { get => _name; set => _name = value; }
        public string LocalPath { get => _localPath; set => _localPath = value; }
        public string[] Code { get => _code; set => _code = value; }
        public Rectangle WorkArea { get => _workArea; set => _workArea = value; }
        public bool IsPreview { get => _isPreview; set => _isPreview = value; }
        public bool IsDeveloperMode { get => _isDeveloperMode; set => _isDeveloperMode = value; }
        [XmlIgnore]
        public bool IsToEdit { get => _isToEdit; set => _isToEdit = value; }

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
            _isToEdit = false;
        }

        public void ChangeName(string newName)
        {
            //zmiana starego folderu na nową nazwę
            _name = newName;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
