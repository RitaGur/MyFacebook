using System;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private User m_LoggedInUser;
        private string m_ListBeingViewed = string.Empty;
        private AppSettings m_AppSettings;
        private LoginResult m_LoginResult;
        private FormMemoryGame m_FormMemoryGame;
        private FormBirthdayCardsGenerator m_FormBirthdayCardsGenerator;

        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
            m_AppSettings = AppSettings.LoadFromFile();
            this.StartPosition = FormStartPosition.Manual;
            this.Size = m_AppSettings.LastWindowSize;
            this.Location = m_AppSettings.LastWindowLocation;
            this.checkBoxRememberUser.Checked = m_AppSettings.RememberUser;
            if (m_AppSettings.RememberUser && !string.IsNullOrEmpty(m_AppSettings.LastAccessToken))
            {
                m_LoginResult = FacebookWrapper.FacebookService.Connect(m_AppSettings.LastAccessToken);
                fetchLoggedInUser();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            m_AppSettings.LastWindowSize = this.Size;
            m_AppSettings.LastWindowLocation = this.Location;
            m_AppSettings.RememberUser = checkBoxRememberUser.Checked;
            m_AppSettings.LastAccessToken = m_AppSettings.RememberUser ? m_LoginResult.AccessToken : null;
            m_AppSettings.SaveToFile();
        }

        private void fetchLoggedInUser()
        {
            m_LoggedInUser = m_LoginResult.LoggedInUser;

            if (m_LoggedInUser != null)
            {
                buttonLogin.Text = $"Logged in as {m_LoggedInUser.Name}";

                pictureBoxProfilePicture.Visible = true;
                pictureBoxProfilePicture.LoadAsync(m_LoggedInUser.PictureNormalURL);
                makeToolsVisible();
            }
        }

        private void makeToolsVisible()
        {
            foreach (Control control in this.Controls)
            {
                control.Visible = true;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns21c");

            m_LoginResult = FacebookService.Login(
                "819008115673175",
                "email",
                "public_profile",
                "user_likes",
                "user_age_range",
                "user_birthday",
                "user_events",
                "user_friends",
                "user_gender",
                "user_hometown",
                "user_likes",
                "user_link",
                "user_location",
                "user_photos",
                "user_posts",
                "user_videos",
                "publish_to_groups",
                "pages_read_engagement",
                "pages_manage_posts"
            );

            fetchLoggedInUser();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxPostTextArea.Text != string.Empty)
                {
                    Status postText = m_LoggedInUser.PostStatus(textBoxPostTextArea.Text);
                    MessageBox.Show("Posted successfully");
                }
                else
                {
                    MessageBox.Show("Please write text to post");
                }
            }
            catch (Exception ex)
            {
                StringBuilder messageToShow = new StringBuilder();
                messageToShow.AppendLine("There is an issue with Graph Api");
                messageToShow.AppendLine(ex.ToString());
                 MessageBox.Show(messageToShow.ToString());
            }
        }

        private void buttonFetchFriends_Click(object sender, EventArgs e)
        {
            pictureBoxMain.Image = null;
            m_ListBeingViewed = "friendsList";

            listBoxMain.Items.Clear();
            FacebookObjectCollection<User> myFriendsList = m_LoggedInUser.Friends;

            foreach (var friend in myFriendsList)
            {
                if (friend.Name != null)
                {
                    listBoxMain.Items.Add(friend.Name);
                }
            }
        }

        private void buttonFetchPosts_Click(object sender, EventArgs e)
        {
            pictureBoxMain.Image = null;
            m_ListBeingViewed = "postList";

            listBoxMain.Items.Clear();
            FacebookObjectCollection<Post> myPosts = m_LoggedInUser.Posts;

            foreach (var post in myPosts)
            {
                if (post.Message != null)
                {
                    listBoxMain.Items.Add(post.Message);
                }
            }
        }

        private void listBoxMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (m_ListBeingViewed)
            {
                case "postList":
                    {
                        handlePostClicked();
                    }

                    break;
                case "friendsList":
                    {
                        handleFriendClicked();
                    }

                    break;
                case "albumsList":
                    {
                        handleAlbumClicked();
                    }

                    break;
            }
        }

        private void handleFriendClicked()
        {
            pictureBoxMain.Visible = true;

            if (listBoxMain.SelectedItems.Count == 1)
            {
                User selectedFriend = m_LoggedInUser.Friends[listBoxMain.SelectedIndex];

                if (selectedFriend.PictureLargeURL != null)
                {
                    pictureBoxMain.LoadAsync(selectedFriend.PictureLargeURL);
                }
                else
                {
                    pictureBoxMain.Image = pictureBoxMain.ErrorImage;
                }
            }
        }

        private void handleAlbumClicked()
        {
            pictureBoxMain.Visible = true;

            if (listBoxMain.SelectedItems.Count == 1)
            {
                Album selectedAlbum = m_LoggedInUser.Albums[listBoxMain.SelectedIndex];

                if (selectedAlbum.PictureAlbumURL != null)
                {
                    pictureBoxMain.LoadAsync(selectedAlbum.PictureAlbumURL);
                }
                else
                {
                    pictureBoxMain.Image = pictureBoxMain.ErrorImage;
                }
            }
        }

        private void handlePostClicked()
        {
            Post selectedPost = m_LoggedInUser.Posts[listBoxMain.SelectedIndex];
            string updatedTime = selectedPost.UpdateTime.ToString();
            FacebookObjectCollection<Comment> myComments = selectedPost.Comments;
            StringBuilder commentsString = new StringBuilder();
            int count = 0;

            foreach (var comment in myComments)
            {
                if (comment.Message != null)
                {
                    commentsString.Append(string.Format("{0}.", count++));
                    commentsString.AppendLine(comment.Message);
                }
            }

            commentsString.AppendLine(updatedTime);
            MessageBox.Show(commentsString.ToString());
        }

        private void buttonFetchAlbums_Click(object sender, EventArgs e)
        {
            pictureBoxMain.Image = null;
            m_ListBeingViewed = "albumsList";

            listBoxMain.Items.Clear();

            foreach (Album album in m_LoggedInUser.Albums)
            {
                listBoxMain.Items.Add(album.Name);
            }

            if (listBoxMain.Items.Count == 0)
            {
                MessageBox.Show("No Albums");
            }
        }

        private void buttonFetchEvents_Click(object sender, EventArgs e)
        {
            listBoxMain.Items.Clear();
            pictureBoxMain.Image = null;
            m_ListBeingViewed = "eventsList";

            foreach (Event facebookEvent in m_LoggedInUser.Events)
            {
                listBoxMain.Items.Add(facebookEvent.Name);
            }

            if (listBoxMain.Items.Count == 0)
            {
                MessageBox.Show("No Events");
            }
        }

        private void buttonMemoryGame_Click(object sender, EventArgs e)
        {
            pictureBoxMain.Image = null;
            m_FormMemoryGame = new FormMemoryGame(m_LoggedInUser);
        }

        private void buttonBirthdayCards_Click(object sender, EventArgs e)
        {
            pictureBoxMain.Image = null;
            m_FormBirthdayCardsGenerator = new FormBirthdayCardsGenerator(m_LoggedInUser);
            m_FormBirthdayCardsGenerator.ShowDialog();
        }

        private void buttonFetchGroups_Click(object sender, EventArgs e)
        {
            pictureBoxMain.Image = null;
            listBoxMain.Items.Clear();
            m_ListBeingViewed = "groupsList";

            foreach (Group group in m_LoggedInUser.Groups)
            {
                listBoxMain.Items.Add(group.Name);
            }

            if (listBoxMain.Items.Count == 0)
            {
                MessageBox.Show("No Groups");
            }
        }

        private void buttonFetchLikedPages_Click(object sender, EventArgs e)
        {
            pictureBoxMain.Image = null;
            listBoxMain.Items.Clear();
            m_ListBeingViewed = "likedPagesList";

            foreach (Page page in m_LoggedInUser.LikedPages)
            {
                listBoxMain.Items.Add(page.Name);
            }

            if (listBoxMain.Items.Count == 0)
            {
                MessageBox.Show("No Liked Pages");
            }
        }
    }
}
