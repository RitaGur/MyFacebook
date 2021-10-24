namespace MemoryGame
{
    public class Game
    {
        private GameBoard m_GameBoard;
        private GamePlayer m_Player;
        private GameCard m_LastOpenCard = null;

        public Game(int i_Rows, int i_Cols, string i_PlayerName)
        {
            m_GameBoard = new GameBoard(i_Rows, i_Cols);
            m_Player = new GamePlayer(i_PlayerName);
        }

        public GamePlayer Player
        {
            get { return m_Player; }
            set { m_Player = value; }
        }

        public GameBoard GameBoard
        {
            get { return m_GameBoard; }
            set { m_GameBoard = value; }
        }

        public GameCard LastOpenCard
        {
            get { return m_LastOpenCard; }
            set { m_LastOpenCard = value; }
        }

        public void OpenCard(int i_Row, int i_Col)
        {
            if (!m_GameBoard.Board[i_Row, i_Col].IsOpen)
            {
                m_GameBoard.Board[i_Row, i_Col].IsOpen = true;
                m_GameBoard.NumberOfClosedCards--;
            }
        }

        public void CloseCard(int i_Row, int i_Col)
        {
            if (m_GameBoard.Board[i_Row, i_Col].IsOpen)
            {
                m_GameBoard.Board[i_Row, i_Col].IsOpen = false;
                m_GameBoard.NumberOfClosedCards++;
            }
        }

        public void UpdateLastOpenCard(GameCard i_GameCard)
        {
            m_LastOpenCard = i_GameCard;
        }

        public bool CheckIfTheCardsMatch(GameCard i_FirstCard, GameCard i_SecondCard)
        {
            bool cardsMatch;

            if (i_FirstCard.CardValue == i_SecondCard.CardValue)
            {
                cardsMatch = true;
            }
            else
            {
                cardsMatch = false;
            }

            return cardsMatch;
        }

        public bool CheckIfTheGameEnd()
        {
            return m_GameBoard.CheckIfAllCardsAreOpen();
        }

        public void AddAPointToPlayer()
        {
            m_Player.Score++;
        }

        private void closeAllCards()
        {
            for (int i = 0; i < m_GameBoard.Rows; i++)
            {
                for (int j = 0; j < m_GameBoard.Cols; j++)
                {
                    m_GameBoard.Board[i, j].IsOpen = false;
                }
            }

            m_GameBoard.NumberOfClosedCards = 16;
        }
    }
}
