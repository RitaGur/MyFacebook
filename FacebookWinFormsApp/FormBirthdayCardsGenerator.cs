using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BDayCardsGenerator;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class FormBirthdayCardsGenerator : Form
    {
        private User m_LoggedInUser;
        private BDayCard m_CurrentBDayCard;
        private Color m_ForeColor;
        private Color m_BackColor;

        public FormBirthdayCardsGenerator(User i_LoggerInUser)
        {
            m_LoggedInUser = i_LoggerInUser;
            InitializeComponent();
            fetchFriends();
        }

        private void buttonChooseColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            m_ForeColor = MyDialog.Color = textBoxPreview.ForeColor;

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPreview.ForeColor = MyDialog.Color;
            }
        }

        private void buttonBackGroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            m_BackColor = MyDialog.Color = textBoxPreview.BackColor;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPreview.BackColor = MyDialog.Color;
            }
        }

        private void fetchFriends()
        {
            listBoxMain.Items.Clear();
            FacebookObjectCollection<User> myFriendsList = m_LoggedInUser.Friends;

            foreach (var friend in myFriendsList)
            {
                if (friend.Name != null && !string.IsNullOrEmpty(friend.Birthday))
                {
                    listBoxMain.Items.Add(friend.Name);
                }
            }
        }

        private void listBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            User selectedFriend = m_LoggedInUser.Friends[listBoxMain.SelectedIndex];
            BDayCard bday_Card = new BDayCard(
                m_LoggedInUser.Name,
                selectedFriend.Name,
                selectedFriend.Birthday);
            m_CurrentBDayCard = bday_Card;
            updatePreviewToBDayCardText();
        }

        private void updatePreviewToBDayCardText()
        {
            if (m_CurrentBDayCard != null)
            {
                textBoxPreview.Text = m_CurrentBDayCard.Message;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (m_CurrentBDayCard != null)
            {
                m_CurrentBDayCard.GetNextGreeting();
                updatePreviewToBDayCardText();
            }
        }

        private void buttonGenerateCard_Click(object sender, EventArgs e)
        {
            var frm = textBoxPreview;

            using (var bmp = new Bitmap(frm.Width, frm.Height))
            {
                frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(@"c:\temp\screenshot.jpg");
            }

            Process photoViewer = new Process();
            Process.Start(@"c:\temp\screenshot.jpg");
        }
    }
}
