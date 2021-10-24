namespace BDayCardsGenerator
{
    public class Card
    {
        private readonly string r_Sender = "<sender>";
        private readonly string r_Recipient = "<recipient>";
        private string m_Message = "<message>";

        public Card(string i_Sender, string i_Recipient)
        {
            r_Sender = i_Sender;
            r_Recipient = i_Recipient;
        }

        public string Message
        {
            get { return m_Message; }
            set { m_Message = value; }
        }

        public string Recipient
        {
            get { return r_Recipient; }
        }

        public string Sender
        {
            get { return r_Sender; }
        }
    }
}
