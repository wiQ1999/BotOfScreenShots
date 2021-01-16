using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BotOfScreenShots_Application
{
    public class Profile : IDisposable
    {
        #region Prop

        const string FILESPATH = @".\Files\";
        const string STARTINGCODE =
            "public static void Main()\r\n" +
            "{\r\n" +
            "\tMessageBox.Show(\"Hello World!\");\r\n" +
            "}";

        private static int ID;

        private readonly int _id;

        private string _name;
        private string _code;
        private Rectangle _workArea;
        private bool _isPreview;
        private bool _isDeveloperMode;
        private bool _isSaved;

        public int Id { get => _id; }
        public string Name
        {
            get => _name;
            set
            {
                RenameDirectory(value);
                _name = value;
            }
        }
        public string Code { get => _code; set => _code = value; }
        public Rectangle WorkArea { get => _workArea; set => _workArea = value; }
        public bool IsPreview { get => _isPreview; set => _isPreview = value; }
        public bool IsDeveloperMode { get => _isDeveloperMode; set => _isDeveloperMode = value; }
        [JsonIgnore]
        public bool IsSaved { get => _isSaved; private set => _isSaved = value; }
        [JsonIgnore]
        public string FullName { get => $"({_id}){_name}"; }
        [JsonIgnore]
        public string LocalPath { get => FILESPATH + FullName; }

        #endregion

        #region ctor

        [JsonConstructor]
        protected Profile(int id, string name)
        {
            ID = id;
            _id = id;
            _name = name;
            _workArea = Screen.PrimaryScreen.Bounds;
            _isPreview = true;
            _isDeveloperMode = false;
            _isSaved = true;
        }

        private Profile()
        {
            _code = STARTINGCODE;
            _workArea = Screen.PrimaryScreen.Bounds;
            _isPreview = true;
            _isDeveloperMode = false;
            _isSaved = true;
        }

        protected Profile(bool isFileToCreate) : this()
        {
            _id = ++ID;
            _name = "Profile" + _id;
            if (isFileToCreate)
                CreateDiretory();
        }

        #endregion

        /// <summary>
        /// Renames directory responsible for storage profile images
        /// </summary>
        /// <param name="newDirectoryName">New directory name</param>
        private void RenameDirectory(string newDirectoryName)
        {
            if (Directory.Exists(LocalPath))
                Directory.Move(LocalPath, FILESPATH + $"({_id}){newDirectoryName}");
            else
                Directory.CreateDirectory(FILESPATH + $"({_id}){newDirectoryName}");
        }

        /// <summary>
        /// Creates directory to storage profile images
        /// </summary>
        private void CreateDiretory()
        {
            if (!Directory.Exists(LocalPath))
                Directory.CreateDirectory(LocalPath);
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

        public void Dispose()
        {
            if (Directory.Exists(LocalPath))
                Directory.Delete(LocalPath, true);
        }
    }
}
