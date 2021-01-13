using BotOfScreenShots_Algorithms;
using BotOfScreenShots_Application.Interfaces;
using BotOfScreenShots_Application.Selector;
using BotOfScreenShots_Application.Serilizer;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace BotOfScreenShots_Application
{
    public partial class MainForm : Form
    {
        #region Prop

        private readonly CompilerParameters CompilerParams;

        private Thread _previewWorker;
        private delegate void UpdatePreviewDelegate(Bitmap bitmap);

        private readonly ISerializer _jsonSerializer = new JSONSerializer();
        private List<Profile> _profilesList;
        private int _profilesListTempIndex;
        private Rectangle _workArea;
        
        /// <summary>
        /// Get current profile
        /// </summary>
        public Profile Profile
        {
            get
            {
                if (_profilesList.Count < 1)
                    return null;
                return _profilesList[ProfilesList.SelectedIndex];
            }
        }

        #endregion

        public MainForm()
        {
            _workArea = Rectangle.Empty;
            InitializeComponent();
            CreatePreviewWorker();
            DeserializeData();
            EnableControls(true);

            CompilerParams = new CompilerParameters
            {
                GenerateInMemory = true,
                TreatWarningsAsErrors = false,
                GenerateExecutable = false,
                CompilerOptions = "/optimize"
            };
        }

        /// <summary>
        /// changes the availability of controls on the MainForm
        /// </summary>
        /// <param name="isEnable">true or false</param>
        private void EnableControls(bool isEnable)
        {
            FilesTreeView.Visible = isEnable;
            WorkAreaButton.Enabled = isEnable;
            ScreenShotButton.Enabled = isEnable;
            PreviewCheckBox.Enabled = isEnable;
            SaveButton.Enabled = isEnable;
            BuildButton.Enabled = isEnable;
            PlayButton.Enabled = isEnable;
            DeveloperModeCheckBox.Enabled = isEnable;
            CodeArea.Enabled = isEnable;
        }

        /// <summary>
        /// Overwrites thread responsible for showing preview
        /// </summary>
        private void CreatePreviewWorker()
        {
            _previewWorker = new Thread(new ThreadStart(CaptureWorkArea))
            {
                IsBackground = true
            };
        }

        #region Serialization

        /// <summary>
        /// Writes data from UI to current profile and serialize
        /// </summary>
        private void Save()
        {
            Profile.Code = CodeArea.Text;
            Profile.WorkArea = _workArea;
            Profile.IsPreview = PreviewCheckBox.Checked;
            Profile.IsDeveloperMode = DeveloperModeCheckBox.Checked;
            SerializeData();
            Profile.Save();
        }

        /// <summary>
        /// Serialize data to .xml file
        /// </summary>
        private void SerializeData()
        {
            _jsonSerializer.Serialize(_profilesList);
        }

        /// <summary>
        /// Deserializes data from .xml file and selects profiles
        /// </summary>
        private void DeserializeData()
        {
            _profilesList = _jsonSerializer.Deserialize();
            if (_profilesList.Count == 0)
                AddProfile();
            UpdateProfilesList();
            SelectLastProfile();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Profile.IsSaved)
            {
                DialogResult dialog = MessageBox.Show("Do you want to save changes before exit?", "Exiting", MessageBoxButtons.YesNoCancel);

                if (dialog == DialogResult.Yes)
                    Save();
                else if (dialog == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        #endregion

        #region ProfilesList

        /// <summary>
        /// Clears and fill profiles list
        /// </summary>
        private void UpdateProfilesList()
        {
            ProfilesList.Items.Clear();
            ProfilesList.Items.AddRange(_profilesList.ToArray());
        }

        /// <summary>
        /// Selects last profile on profiles list
        /// </summary>
        private void SelectLastProfile()
        {
            ProfilesList.SelectedIndex = _profilesList.Count - 1;
        }

        /// <summary>
        /// Adds a profile to profile list and select it
        /// </summary>
        private void AddProfile()
        {
            _profilesList.Add(Profile.GenerateProfile(true));
            UpdateProfilesList();
            SelectLastProfile();
            Save();
        }

        private void ProfileAddButton_Click(object sender, EventArgs e)
        {
            AddProfile();
        }

        private void ProfileRemoveButton_Click(object sender, EventArgs e)
        {
            if (_profilesList.Count > 1)
            {
                DialogResult dialog = MessageBox.Show($"Do you want to remove {Profile.Name}?", "Removing", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    Profile.Dispose();
                    _profilesList.RemoveAt(ProfilesList.SelectedIndex);
                    UpdateProfilesList();
                    SelectLastProfile();
                    SerializeData();
                }
            }
        }

        private void ProfileChangeNameButton_Click(object sender, EventArgs e)
        {
            if (ProfilesList.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                EnableControls(false);
                ProfileAddButton.Enabled = false;
                ProfileRemoveButton.Enabled = false;
                _profilesListTempIndex = ProfilesList.SelectedIndex;
                ProfilesList.DropDownStyle = ComboBoxStyle.Simple;
            }
            else
            {
                EnableControls(true);
                ProfileAddButton.Enabled = true;
                ProfileRemoveButton.Enabled = true;
                _profilesList[_profilesListTempIndex].Name = ProfilesList.Text;
                ProfilesList.DropDownStyle = ComboBoxStyle.DropDownList;
                UpdateProfilesList();
                ProfilesList.SelectedIndex = _profilesListTempIndex;
                Profile.InitializeSave();
            }
        }

        private void ProfilesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFilesTreeView();
            PreviewCheckBox.Checked = Profile.IsPreview;
            _workArea = Profile.WorkArea;
            DeveloperModeCheckBox.Checked = Profile.IsDeveloperMode;
            CodeArea.Text = Profile.Code;
            InitializePreview();
        }

        private void ProfilesList_DropDown(object sender, EventArgs e)
        {
            Save();
        }

        #endregion

        #region Preview

        /// <summary>
        /// Analyzes controls on UI and prepares to display or shut down a new thread
        /// </summary>
        private void InitializePreview()
        {
            if (PreviewCheckBox.Checked && !_previewWorker.IsAlive)
            {
                _previewWorker.Start();
            }
            else if (PreviewCheckBox.Checked == false)
            {
                _previewWorker.Abort();
                PreviewPictureBox.Image = null;
                CreatePreviewWorker();
            }
            else
            {
                _previewWorker.Abort();
                PreviewPictureBox.Image = null;
                CreatePreviewWorker();
                _previewWorker.Start();
            }
        }

        /// <summary>
        /// Invokes new image into picturebox on UI by delegate method
        /// </summary>
        /// <param name="bitmap">Bitmap image</param>
        private void UpdatePreview(Bitmap bitmap)
        {
            if (PreviewPictureBox.InvokeRequired)

                PreviewPictureBox.Invoke(new UpdatePreviewDelegate(UpdatePreview), new object[] { bitmap });
            else
                PreviewPictureBox.Image = bitmap;
        }

        /// <summary>
        /// Captures a work area and updates preview in the infinite loop
        /// </summary>
        private void CaptureWorkArea()
        {
            float scale = Math.Min((float)PreviewPictureBox.Width / _workArea.Width, (float)PreviewPictureBox.Height / _workArea.Height);
            using (Bitmap bitmap = new Bitmap(_workArea.Width, _workArea.Height, PixelFormat.Format32bppArgb))
            {
                while (true)
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(_workArea.Location, Point.Empty, _workArea.Size);
                    }

                    UpdatePreview(new Bitmap(bitmap, new Size((int)(bitmap.Width * scale), (int)(bitmap.Height * scale))));
                    Thread.Sleep(100);
                }
            }
        }

        private void WorkAreaButton_Click(object sender, EventArgs e)
        {
            Profile.InitializeSave();
            SelectorArea selector = new SelectorArea(Brushes.ForestGreen);
            selector.ShowDialog();
            if (selector.Area != Rectangle.Empty)
                _workArea = selector.Area;
            selector.Close();
            InitializePreview();
        }

        private void PreviewCheckBox_Click(object sender, EventArgs e)
        {
            Profile.InitializeSave();
        }

        private void PreviewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            InitializePreview();
        }

        #endregion

        #region ScreenShot

        private void ScreenShotButton_Click(object sender, EventArgs e)
        {
            SelectorSaver selectorSaver = new SelectorSaver(Brushes.IndianRed, Profile.LocalPath);
            if (selectorSaver.ShowDialog() == DialogResult.OK)
            {
                TimeSpan savingTime = DateTime.Now.TimeOfDay;
                do RefreshFilesTreeView();
                while (!File.Exists(SelectorViewer.FileName + ".png") && savingTime > savingTime.Add(TimeSpan.FromSeconds(3)));
            }
        }

        #endregion

        #region FilesList

        private void RefreshFilesTreeView()
        {
            if (Directory.Exists(Profile.LocalPath))
            {
                FilesTreeView.Nodes.Clear();

                FileInfo[] files = new DirectoryInfo(Profile.LocalPath).GetFiles("*.png", SearchOption.AllDirectories);
                foreach (FileInfo file in files)
                {
                    FilesTreeView.Nodes.Add(file.Name);
                }
            }
        }

        private void RefreshFilesButton_Click(object sender, EventArgs e)
        {
            RefreshFilesTreeView();
        }

        private void OpenDirectoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Profile.LocalPath))
                    throw new Exception("Directory not found.");
                System.Diagnostics.Process.Start(Profile.LocalPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open directory\n" + ex.Message);
            }
        }

        #endregion

        #region CodeArea

        private CompilerResults BuildCode()
        {
            string[] references = { "System.dll", "System.Windows.Forms.dll", "System.Drawing.dll", "BotOfScreenShots_Algorithms.dll" };
            CompilerParams.ReferencedAssemblies.AddRange(references);

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerResults compile = provider.CompileAssemblyFromSource(CompilerParams, new[] { CodeArea.Text });

            if (compile.Errors.HasErrors)
            {
                string errorResult = string.Empty;
                foreach (CompilerError error in compile.Errors)
                {
                    errorResult += error.ToString() + "\n";
                }
                MessageBox.Show(errorResult);
                return null;
            }
            return compile;
        }

        private void RunCode()
        {
            CompilerResults compile = BuildCode();

            if (compile != null)
            {
                Module module = compile.CompiledAssembly.GetModules()[0];
                if (module != null)
                {
                    Type moduleType = module.GetType("Test.Program");
                    if (moduleType != null)
                    {
                        MethodInfo methodInfo = moduleType.GetMethod("Main");
                        if (methodInfo != null)
                        {
                            methodInfo.Invoke(null, null);
                        }
                    }
                }
            }
        }

        private void CodeArea_Enter(object sender, EventArgs e)
        {
            Profile.InitializeSave();
        }

        private void DeveloperModeCheckBox_Click(object sender, EventArgs e)
        {
            Profile.InitializeSave();
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            BuildCode();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            RunCode();
        }


        #endregion

        
    }
}
