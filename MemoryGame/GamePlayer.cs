namespace MemoryGame
{
    public class GamePlayer
    {
        private readonly string r_Name;
        private int m_Score;

        public GamePlayer(string i_PlayerName)
        {
            r_Name = i_PlayerName;
            m_Score = 0;
        }

        public string Name
        {
            get { return r_Name; }
        }

        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }
    }
}
