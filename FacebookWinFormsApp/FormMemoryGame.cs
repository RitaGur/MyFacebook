using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using MemoryGame;

namespace BasicFacebookFeatures
{
    public partial class FormMemoryGame : Form
    {
        private const int k_GameBoardSize = 4;
        private const int k_PaddingButtonSize = 8;
        private const int k_ButtonSize = 67;

        private readonly MemoryGameSettingsForm r_MemoryGameSettingsForm;
        private readonly Game r_MemoryGame;
        private MemoryGameItem[,] m_MemoryGameMatrix;
        private MemoryGameItem m_FirstClickedCard = null;
        private MemoryGameItem m_SecondClickedCard = null;
        private bool m_FirstClick = false;
        private List<Image> m_FriendsProfilePictures = null;
        private List<Image> m_MorePictures = null;

        public FormMemoryGame(User i_LoggedInUser)
        {
            m_FriendsProfilePictures = new List<Image>();
            r_MemoryGameSettingsForm = new MemoryGameSettingsForm(i_LoggedInUser, ref m_FriendsProfilePictures);
            r_MemoryGameSettingsForm.ShowDialog();

            InitializeComponent();
            m_MemoryGameMatrix = new MemoryGameItem[k_GameBoardSize, k_GameBoardSize];
            r_MemoryGame = new Game(k_GameBoardSize, k_GameBoardSize, i_LoggedInUser.Name);
            m_MorePictures = new List<Image>();

            if (r_MemoryGameSettingsForm.DialogResult == DialogResult.Yes)
            {
                initializeMorePicturesList();
                combinePicturesLists();
                createGameBoard();
                this.ShowDialog();
            }
        }

        private void combinePicturesLists()
        {
            int i = 0;

            while (m_FriendsProfilePictures.Count < 8)
            {
                m_FriendsProfilePictures.Add(m_MorePictures[i]);
                i++;
            }
        }

        private void initializeMorePicturesList()
        {
            m_MorePictures.Add(Properties.Resources._1);
            m_MorePictures.Add(Properties.Resources._2);
            m_MorePictures.Add(Properties.Resources._3);
            m_MorePictures.Add(Properties.Resources._4);
            m_MorePictures.Add(Properties.Resources._5);
            m_MorePictures.Add(Properties.Resources._6);
            m_MorePictures.Add(Properties.Resources._7);
            m_MorePictures.Add(Properties.Resources._8);
        }

        private void createGameBoard()
        {
            m_MemoryGameMatrix = new MemoryGameItem[k_GameBoardSize, k_GameBoardSize];
            Random random = new Random();
            int randomIndex;

            List<ImageID> imageIDList = new List<ImageID>();
            buildImageIDList(ref imageIDList);

            List<int> indexList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            for (int i = 0; i < k_GameBoardSize; i++)
            {
                for (int j = 0; j < k_GameBoardSize; j++)
                {
                    randomIndex = random.Next(0, indexList.Count);
                    m_MemoryGameMatrix[i, j] = new MemoryGameItem(i, j, imageIDList[indexList[randomIndex]].ImageIndex, imageIDList[indexList[randomIndex]].CardImage);
                    r_MemoryGame.GameBoard.Board[i, j].CardValue = imageIDList[indexList[randomIndex]].ImageIndex;
                    indexList.RemoveAt(randomIndex);
                    m_MemoryGameMatrix[i, j].Top = (k_PaddingButtonSize * (i + 1)) + (k_ButtonSize * i);
                    m_MemoryGameMatrix[i, j].Left = (k_PaddingButtonSize * (j + 1)) + (k_ButtonSize * j);
                    m_MemoryGameMatrix[i, j].Size = new Size(k_ButtonSize, k_ButtonSize);
                    m_MemoryGameMatrix[i, j].TabStop = false;
                    m_MemoryGameMatrix[i, j].Image = Properties.Resources.cover1;
                    m_MemoryGameMatrix[i, j].Click += gameItem_Click;
                    this.Controls.Add(m_MemoryGameMatrix[i, j]);
                }
            }
        }

        private void buildImageIDList(ref List<ImageID> io_ImageIDList)
        {
            List<int> indexList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            Random random = new Random();
            int randomIndex;
            ImageID imageIDToInsert;

            for (int i = 0; i < 8; i++)
            {
                randomIndex = random.Next(0, indexList.Count);
                imageIDToInsert = new ImageID(m_FriendsProfilePictures[randomIndex], indexList[randomIndex]);
                m_FriendsProfilePictures.RemoveAt(randomIndex);
                indexList.RemoveAt(randomIndex);

                io_ImageIDList.Add(imageIDToInsert);
                io_ImageIDList.Add(imageIDToInsert);
            }
        }

        private void gameItem_Click(object sender, EventArgs e)
        {
            MemoryGameItem currGameItem = sender as MemoryGameItem;
            int rowIndex = currGameItem.RowIndex;
            int colIndex = currGameItem.ColIndex;

            if (!currGameItem.GameCard.IsOpen && !timerTwoClickedCards.Enabled)
            {
                currGameItem.Image = currGameItem.CardImage;
                r_MemoryGame.OpenCard(rowIndex, colIndex);
                currGameItem.GameCard.IsOpen = true;

                if (m_FirstClick == false)
                {
                    m_FirstClick = true;
                    r_MemoryGame.LastOpenCard = currGameItem.GameCard;
                    m_FirstClickedCard = currGameItem;
                }
                else
                {
                    m_SecondClickedCard = currGameItem;

                    if (!checkIfCardsMatch(currGameItem.GameCard))
                    {
                        timerTwoClickedCards.Start();
                    }

                    m_FirstClick = false;
                }
            }

            checkIfWin();
        }

        private void checkIfWin()
        {
            string formName = "A Win!";

            if (r_MemoryGame.CheckIfTheGameEnd())
            {
                DialogResult dialogResult = MessageBox.Show(String.Format("{0}, You Won!", r_MemoryGame.Player.Name), formName);
                this.Close();
            }
        }

        private bool checkIfCardsMatch(GameCard i_SecondGameCard)
        {
            return r_MemoryGame.CheckIfTheCardsMatch(r_MemoryGame.LastOpenCard, i_SecondGameCard);
        }

        private void timerTwoClickedCards_Tick(object sender, EventArgs e)
        {
            timerTwoClickedCards.Stop();

            m_FirstClickedCard.GameCard.IsOpen = false;
            m_SecondClickedCard.GameCard.IsOpen = false;
            r_MemoryGame.CloseCard(m_FirstClickedCard.RowIndex, m_FirstClickedCard.ColIndex);
            r_MemoryGame.CloseCard(m_SecondClickedCard.RowIndex, m_SecondClickedCard.ColIndex);
            m_FirstClickedCard.Image = Properties.Resources.cover1;
            m_SecondClickedCard.Image = Properties.Resources.cover1;
        }
    }
}
