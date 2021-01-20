using BotOfScreenShots_Application.Interfaces;
using BotOfScreenShots_Application.Selector;
using BotOfScreenShots_Application.Serilizer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace BotOfScreenShots_Application
{
    public partial class MainForm : Form
    {
        #region Prop

        //Main work area
        public static Rectangle WorkArea;

        //Preview Worker
        private Thread _previewWorker;
        private delegate void UpdatePreviewDelegate(Bitmap bitmap);

        //Timer CodeOnFly
        private System.Timers.Timer _codeOnFlyTimer;

        private readonly ISerializer _jsonSerializer;
        private List<ProfileCompiler> _profilesList;
        private int _profilesListTempIndex;
        private bool _startButton;
        
        /// <summary>
        /// Get current profile with compiler
        /// </summary>
        public ProfileCompiler ProfileCompiler
        {
            get
            {
                if (_profilesList.Count < 1)
                    return null;
                return _profilesList[ProfilesList.SelectedIndex];
            }
        }

        /// <summary>
        /// Get current base profile
        /// </summary>
        public Profile Profile
        {
            get => (Profile)ProfileCompiler;
        }
        
        #endregion

        public MainForm()
        {
            _jsonSerializer = new JSONSerializer();
            WorkArea = Rectangle.Empty;
            _startButton = true;
            InitializeComponent();
            CreatePreviewWorker();
            FillDataGridView();
            DeserializeData();
            EnableControls(true);
        }

        /// <summary>
        /// changes the availability of controls on the MainForm
        /// </summary>
        /// <param name="isEnable">true or false</param>
        private void EnableControls(bool isEnable)
        {
            FilesTreeView.Visible = isEnable;
            RefreshFilesButton.Enabled = isEnable;
            OpenDirectoryButton.Enabled = isEnable;
            WorkAreaButton.Enabled = isEnable;
            ScreenShotButton.Enabled = isEnable;
            PreviewCheckBox.Enabled = isEnable;
            SaveButton.Enabled = isEnable;
            BuildButton.Enabled = isEnable;
            PlayButton.Enabled = isEnable;
            ReferencesList.Enabled = isEnable;
            CodeArea.Enabled = isEnable;
        }

        /// <summary>
        /// Fill and specify references list parameters
        /// </summary>
        private void FillDataGridView()
        {
            ReferencesList.Columns.Add("Libraries", "Libraries");
            ReferencesList.Columns["Libraries"].Resizable = DataGridViewTriState.False;
            ReferencesList.Columns["Libraries"].Width = 170;
        }

        #region Serialization

        /// <summary>
        /// Writes data from UI to current profile and serialize
        /// </summary>
        private void Save()
        {
            Profile.Code = CodeArea.Text;
            Profile.WorkArea = WorkArea;
            Profile.IsPreview = PreviewCheckBox.Checked;
            ProfileCompiler.References.Clear();
            foreach (DataGridViewRow row in ReferencesList.Rows)
            {
                if (row.Cells[0].Value != null)
                    ProfileCompiler.References.Add(Convert.ToString(row.Cells[0].Value));
            }
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
            SetLastProfile();
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
        private void SetLastProfile()
        {
            ProfilesList.SelectedIndex = _profilesList.Count - 1;
        }

        /// <summary>
        /// Adds a profile to profile list and select it
        /// </summary>
        private void AddProfile()
        {
            _profilesList.Add(new ProfileCompiler(true));
            UpdateProfilesList();
            SetLastProfile();
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
                    SetLastProfile();
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
                ProfileCompiler.InitializeSave();
            }
        }

        private void ProfilesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFilesTreeView();
            WorkArea = Profile.WorkArea;
            ReferencesList.Rows.Clear();
            foreach (string references in ProfileCompiler.References)
                ReferencesList.Rows.Add(references);
            CodeArea.Text = Profile.Code;
            PreviewCheckBox.Checked = Profile.IsPreview;
            InitializePreview();
        }

        private void ProfilesList_DropDown(object sender, EventArgs e)
        {
            Save();
        }

        private void FilesTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            PreviewCheckBox.Checked = false;
            string path = Profile.LocalPath + "\\" + e.Node.Text;
            if (File.Exists(path))
            {
                Bitmap bitmapFromPath = (Bitmap)Image.FromFile(path);
                float scale = GetScaleToPreview(bitmapFromPath.Width, bitmapFromPath.Height);
                PreviewPictureBox.Image = new Bitmap(bitmapFromPath, new Size((int)(bitmapFromPath.Width * scale), (int)(bitmapFromPath.Height * scale)));
            }
            else
            {
                MessageBox.Show("Image is not found");
                RefreshFilesTreeView();
            }
        }

        #endregion

        #region Preview

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

        /// <summary>
        /// Analyzes controls on UI and prepares to display or shut down a new thread
        /// </summary>
        private void InitializePreview()
        {
            PreviewPictureBox.Image = null;
            if (PreviewCheckBox.Checked && !_previewWorker.IsAlive)
            {
                _previewWorker.Start();
            }
            else if (PreviewCheckBox.Checked == false)
            {
                _previewWorker.Abort();
                CreatePreviewWorker();
            }
            else
            {
                _previewWorker.Abort();
                CreatePreviewWorker();
                _previewWorker.Start();
            }
        } 

        /// <summary>
        /// Get scale to image adapted to PreviePictureBox
        /// </summary>
        /// <param name="width">Width of image to scale</param>
        /// <param name="height">Height of image to scale</param>
        /// <returns>Image scale</returns>
        private float GetScaleToPreview(int width, int height)
        {
            return Math.Min((float)PreviewPictureBox.Width / width, (float)PreviewPictureBox.Height / height);
        }

        /// <summary>
        /// Captures a work area and updates preview in the infinite loop
        /// </summary>
        private void CaptureWorkArea()
        {
            float scale = GetScaleToPreview(WorkArea.Width, WorkArea.Height);
            using (Bitmap bitmap = new Bitmap(WorkArea.Width, WorkArea.Height))
            {
                while (true)
                {
                    Thread.Sleep(100);
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(WorkArea.Location, Point.Empty, WorkArea.Size);
                    }

                    UpdatePreview(new Bitmap(bitmap, new Size((int)(bitmap.Width * scale), (int)(bitmap.Height * scale))));
                }
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

        private void WorkAreaButton_Click(object sender, EventArgs e)
        {
            Profile.InitializeSave();
            SelectorArea selector = new SelectorArea(Brushes.ForestGreen);
            selector.ShowDialog();
            if (selector.Area != Rectangle.Empty)
                WorkArea = selector.Area;
            selector.Close();
            InitializePreview();
        }

        private void PreviewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            InitializePreview();
            Profile.InitializeSave();
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

        /// <summary>
        /// Refreshes list with profile files
        /// </summary>
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

        /// <summary>
        /// Overwrites timer reposible for listening for CodeOnFly stop
        /// </summary>
        private void CreateCodeOnFlyTimer()
        {
            _codeOnFlyTimer = new System.Timers.Timer(1000)
            {
                AutoReset = true,
                Enabled = true,
            };
            _codeOnFlyTimer.Elapsed += CodeOnFlyTimer_ElapsedEvent;
        }

        /// <summary>
        /// Listens for a static property of ProfileCompiler
        /// </summary>
        /// <param name="sender">Object sender</param>
        /// <param name="e">Timer event</param>
        private void CodeOnFlyTimer_ElapsedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (ProfileCompiler.IsCodeOnFlyCompleted)
            {
                Invoke((MethodInvoker)delegate
                {
                    _startButton = true;
                    ChangePlayButton(Color.ForestGreen, "Play");
                });
                _codeOnFlyTimer.Stop();
            }
        }

        /// <summary>
        /// Changes color and text of Play Button on UI
        /// </summary>
        /// <param name="buttonColor">New color button</param>
        /// <param name="buttonText">New text button</param>
        private void ChangePlayButton(Color buttonColor, string buttonText)
        {
            PlayButton.BackColor = buttonColor;
            PlayButton.Text = buttonText;
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            Save();
            ProfileCompiler.Build();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            Save();
            if (_startButton)
            {
                if (ProfileCompiler.Run()){
                    WindowState = FormWindowState.Minimized;
                    _startButton = false;
                    ChangePlayButton(Color.Firebrick, "Stop");
                    CreateCodeOnFlyTimer();
                }
            }
            else
            {
                ProfileCompiler.Abort();
                WindowState = FormWindowState.Normal;
                _startButton = true;
                ChangePlayButton(Color.ForestGreen, "Play");
            }
        }

        private void CodeArea_TextChanged(object sender, EventArgs e)
        {
            Profile.InitializeSave();
        }

        #endregion

        #region ReferencesList

        private void ReferencesList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Profile.InitializeSave();
        }

        #endregion

        #region Links

        private void AlgorithmsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/wiQ1999/ImageSearchAlgorithm/blob/master/Analiza-Przeszukiwanie_obrazu.pdf");
        }

        private void ProjectLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/wiQ1999/BotOfScreenShots");
        }

        #endregion
    }
}
