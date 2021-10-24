using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class MemoryGameSettingsForm : Form
    {
        private const int k_MaxFriends = 8;

        private List<Image> m_FriendsProfilePicturesList;
        private User m_LoggedInUser;

        public MemoryGameSettingsForm(User i_LoggedInUser, ref List<Image> io_FriendsProfilePicturesList)
        {
            m_FriendsProfilePicturesList = io_FriendsProfilePicturesList;
            m_LoggedInUser = i_LoggedInUser;

            InitializeComponent();

            FacebookObjectCollection<User> myFriendsList = i_LoggedInUser.Friends;

            foreach (var friend in myFriendsList)
            {
                if (friend.Name != null)
                {
                    listBoxFriendsList.Items.Add(friend.Name);
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxFriendsList.SelectedItems.Count && i < k_MaxFriends; i++)
            {
                m_FriendsProfilePicturesList.Add(m_LoggedInUser.Friends[i].ImageSquare);
            }

            m_FriendsProfilePicturesList.Add(m_LoggedInUser.ImageSquare);

            this.Close();
            this.DialogResult = DialogResult.Yes;
        }
    }
}
