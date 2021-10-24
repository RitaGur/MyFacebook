using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemoryGame;

namespace BasicFacebookFeatures
{
    public class MemoryGameItem : Button
    {
        private int m_RowIndex;
        private int m_ColIndex;
        private GameCard m_GameCard;
        private Image m_CardImage;

        public MemoryGameItem(int i_RowIndex, int i_ColIndex, int i_GameCardValue, Image i_Image)
        {
            m_RowIndex = i_RowIndex;
            m_ColIndex = i_ColIndex;
            m_GameCard = new GameCard(i_GameCardValue);
            m_CardImage = i_Image;
        }

        public GameCard GameCard
        {
            get { return m_GameCard; }
            set { m_GameCard = value; }
        }

        public int RowIndex
        {
            get { return m_RowIndex; }
            set { m_RowIndex = value; }
        }

        public int ColIndex
        {
            get { return m_ColIndex; }
            set { m_ColIndex = value; }
        }

        public Image CardImage
        {
            get { return m_CardImage; }
            set { m_CardImage = value; }
        }
    }
}
