namespace MemoryGame
{
    public class GameCard
    {
        private int m_CardValue;
        private bool m_IsOpen;

        public GameCard()
        {
            m_CardValue = -1;
            m_IsOpen = false;
        }

        public GameCard(int i_CardValue)
        {
            m_CardValue = i_CardValue;
            m_IsOpen = false;
        }

        public bool IsOpen
        {
            get { return m_IsOpen; }
            set { m_IsOpen = value; }
        }

        public int CardValue
        {
            get { return m_CardValue; }
            set { m_CardValue = value; }
        }
    }
}
