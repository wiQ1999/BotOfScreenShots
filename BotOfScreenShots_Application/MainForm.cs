using BotOfScreenShots_Algorithms;
using BotOfScreenShots_Application.Interfaces;
using BotOfScreenShots_Application.Selector;
using BotOfScreenShots_Application.XMLSerilizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotOfScreenShots_Application
{
    public partial class MainForm : Form
    {
        private readonly ISerializer _serializer = new XMLSerializer();
        private List<Profile> _profilesList;
        private int _profilesListTempIndex;
        private Rectangle _workArea;
        
        public Profile Profile
        {
            get
            {
                if (_profilesList.Count < 1)
                    return null;
                return _profilesList[ProfilesList.SelectedIndex];
            }
        }

        public MainForm()
        {
            InitializeComponent();
            DeserializeData();
            EnableControls(true);
        }

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

        #region Serialization

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

        private void DeserializeData()
        {
            _profilesList = _serializer.Deserialize();
            if (_profilesList.Count == 0)
                AddProfile();
            UpdateProfilesList();
            SelectLastProfile();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            Profile.SaveProfile();
            Profile.Code = CodeArea.Lines;
            Profile.WorkArea = _workArea;
            Profile.IsPreview = PreviewCheckBox.Checked;
            Profile.IsDeveloperMode = DeveloperModeCheckBox.Checked;
            _serializer.Serialize(_profilesList);
        }

        #endregion

        #region ProfilesList

        private void UpdateProfilesList()
        {
            ProfilesList.Items.Clear();
            ProfilesList.Items.AddRange(_profilesList.ToArray());
        }

        private void SelectLastProfile()
        {
            ProfilesList.SelectedIndex = _profilesList.Count - 1;
        }

        private void AddProfile()
        {
            _profilesList.Add(new Profile("Profile" + Profile.ID));
            UpdateProfilesList();
            SelectLastProfile();
        }

        private void ProfileAddButton_Click(object sender, EventArgs e)
        {
            Save();
            AddProfile();
        }

        private void ProfileRemoveButton_Click(object sender, EventArgs e)
        {
            if (_profilesList.Count > 1)
            {
                _profilesList.RemoveAt(ProfilesList.SelectedIndex);
                UpdateProfilesList();
                SelectLastProfile();
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
                _profilesList[_profilesListTempIndex].ChangeName(ProfilesList.Text);
                ProfilesList.DropDownStyle = ComboBoxStyle.DropDownList;
                UpdateProfilesList();
                ProfilesList.SelectedIndex = _profilesListTempIndex;
                Profile.InitiateSave();
            }
        }

        private void ProfilesList_SelectedIndexChanged(object sender, EventArgs e)//to do
        {
            //FilesList
            PreviewCheckBox.Checked = Profile.IsPreview;
            _workArea = Profile.WorkArea;
            DeveloperModeCheckBox.Checked = Profile.IsDeveloperMode;
            CodeArea.Lines = Profile.Code;
        }

        private void ProfilesList_DropDown(object sender, EventArgs e)
        {
            Save();
        }

        #endregion

        private void CodeArea_Enter(object sender, EventArgs e)
        {
            Profile.InitiateSave();
        }

        private void WorkAreaButton_Click(object sender, EventArgs e)
        {
            Profile.InitiateSave();
            SelectorArea selector = new SelectorArea(Brushes.ForestGreen);
            selector.ShowDialog();
            _workArea = selector.Area;
            selector.Close();
        }

        private void PreviewCheckBox_Click(object sender, EventArgs e)
        {
            Profile.InitiateSave();

        }

        private void DeveloperModeCheckBox_Click(object sender, EventArgs e)
        {
            Profile.InitiateSave();
        }
    }
}
