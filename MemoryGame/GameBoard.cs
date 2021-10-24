using System;

namespace MemoryGame
{
    public class GameBoard
    {
        private const int k_BoardSize = 4;

        private readonly int r_Rows;
        private readonly int r_Cols;
        private GameCard[,] m_Board;
        private int m_NumberOfClosedCards;

        public GameBoard(int i_Rows, int i_Cols)
        {
            r_Rows = i_Rows;
            r_Cols = i_Cols;
            m_NumberOfClosedCards = i_Cols * i_Rows;
            m_Board = new GameCard[i_Rows, i_Cols];
            initializeBoardValues();
        }

        public int Rows
        {
            get { return r_Rows; }
        }

        public int Cols
        {
            get { return r_Cols; }
        }

        public int NumberOfClosedCards
        {
            get { return m_NumberOfClosedCards; }
            set { m_NumberOfClosedCards = value; }
        }

        public GameCard[,] Board
        {
            get { return m_Board; }
        }

        public bool CheckIfCardIsOpen(int i_Row, int i_Col)
        {
            return Board[i_Row, i_Col].IsOpen;
        }

        public bool CheckIfAllCardsAreOpen()
        {
            return m_NumberOfClosedCards == 0 ? true : false;
        }

        private void initializeBoardValues()
        {
            for (int i = 0; i < r_Rows; i++)
            {
                for (int j = 0; j < r_Cols; j++)
                {
                    m_Board[i, j] = new GameCard();
                }
            }
        }
    }
}
