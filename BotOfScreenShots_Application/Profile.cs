using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BotOfScreenShots_Application
{
    public class Profile
    {
        #region Prop

        const string FILESPATH = @".\Files\";

        private static int ID;

        private readonly int _id;
        private string _fullName;
        private string _name;
        private string _code;
        private Rectangle _workArea;
        private bool _isPreview;
        private bool _isDeveloperMode;
        private bool _isSaved = true;

        public int Id { get => _id; }
        public string FullName { get => _fullName; private set => _fullName = value; }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                string newS = CreateFullName(value);
                RenameDirectory(newS);
                _fullName = newS;
            }
        }
        public string Code { get => _code; set => _code = value; }
        public Rectangle WorkArea { get => _workArea; set => _workArea = value; }
        public bool IsPreview { get => _isPreview; set => _isPreview = value; }
        public bool IsDeveloperMode { get => _isDeveloperMode; set => _isDeveloperMode = value; }
        [JsonIgnore]
        public bool IsSaved { get => _isSaved; private set => _isSaved = value; }
        [JsonIgnore]
        public string LocalPath { get => FILESPATH + FullName; }

        #endregion

        #region ctor

        private Profile()
        {
            _id = ++ID;
            _workArea = Screen.PrimaryScreen.Bounds;
            _isPreview = true;
            _isDeveloperMode = false;
            _isSaved = true;
            CreateDiretory();
        }

        protected Profile(bool isFullName) : this()
        {
            _fullName = CreateFullName("Profil");
            _name = isFullName ? _fullName : "Profil" + _id;
        }

        public Profile(string name) : this()
        {
            _fullName = CreateFullName(name);
            _name = name;
        }

        #endregion

        /// <summary>
        /// Static method responsible for generate new standard profile
        /// </summary>
        /// <param name="isFullName">Do Name property has the same value as FullName property?</param>
        /// <returns>New generated profile</returns>
        public static Profile GenerateProfile(bool isFullName)
        {
            return new Profile(isFullName);
        }

        /// <summary>
        /// Creates full name with profile id
        /// </summary>
        /// <param name="name">Profile name</param>
        /// <returns>Profile full name</returns>
        private string CreateFullName(string name)
        {
            return $"({_id}){name}";
        }

        /// <summary>
        /// Rename directory responsible for storage profile images
        /// </summary>
        /// <param name="newDirectoryName">New directory name</param>
        public void RenameDirectory(string newDirectoryName)
        {
            if (!Directory.Exists(LocalPath))
                Directory.CreateDirectory(FILESPATH + newDirectoryName);
            else
                Directory.Move(LocalPath, FILESPATH + newDirectoryName);
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
    }
}
