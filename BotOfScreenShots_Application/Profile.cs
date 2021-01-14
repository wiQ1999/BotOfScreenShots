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
        const string STARTCODE =
@"using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using BotOfScreenShots_Algorithms;";

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
            _workArea = Screen.PrimaryScreen.Bounds;
            _isPreview = true;
            _isDeveloperMode = false;
            _isSaved = true;
            //CODE STARTCODE!!!
        }

        protected Profile(bool isFileToCreate) : this()
        {
            _id = ++ID;
            _name = "Profile" + _id;
            if (isFileToCreate)
                CreateDiretory();
        }

        //public Profile(string name, bool isFileToCreate) : this()
        //{
        //    _id = ++ID;
        //    _name = name;
        //    if (isFileToCreate)
        //        CreateDiretory();
        //}

        #endregion

        /// <summary>
        /// Static method responsible for generate new standard profile
        /// </summary>
        /// <param name="isFullName">Do Name property has the same value as FullName property?</param>
        /// <param name="isGenerateNewDirectory">Generate new directory?</param>
        /// <returns>New generated profile</returns>
        //public static Profile GenerateProfile(bool isGenerateNewDirectory)
        //{
        //    return new Profile(isGenerateNewDirectory);
        //}

        /// <summary>
        /// Rename directory responsible for storage profile images
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
