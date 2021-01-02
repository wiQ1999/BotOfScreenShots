using BotOfScreenShots_Algorithms;
using BotOfScreenShots_Application.Interfaces;
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
        private ISerializer _serializer = new XMLSerializer();
        private List<Profile> _profileList;

        public Profile MainProfile { get; set; }

        public MainForm()
        {
            InitializeComponent();
            DeserializeData();
            EnableControls();
        }

        private void DeserializeData()
        {
            _profileList = _serializer.Deserialize();
            ProfilesList.Items.AddRange(_profileList.ToArray());
        }

        private void EnableControls()
        {
            ProfileChangeNameButton.Enabled = true;
            FilesTreeView.Visible = true;
            WorkAreaButton.Enabled = true;
            ScreenShotButton.Enabled = true;
            PreviewCheckBox.Enabled = true;
            BuildButton.Enabled = true;
            PlayButton.Enabled = true;
            DeveloperModeCheckBox.Enabled = true;
            CodeArea.Enabled = true;
        }

        private void ProfileAddButton_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile("Profile" + Profile.ID);
            _profileList.Add(profile);
            ProfilesList.Items.Add(profile);
            ProfilesList.SelectedIndex = ProfilesList.Items.Count - 1;
        }
    }
}
