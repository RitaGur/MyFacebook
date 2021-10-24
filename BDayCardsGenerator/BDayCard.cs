namespace BDayCardsGenerator
{
    public class BDayCard : Card
    {
        private readonly string r_BDay = "<bday>";

        public BDayCard(string i_Sender, string i_Recipient, string i_BDay) : base(i_Sender, i_Recipient)
        {
            this.r_BDay = i_BDay;
            GetNextGreeting();
        }

        public void GetNextGreeting()
        {
            this.Message = string.Format(BDayGreetingsGenerator.GetGreeting(), Sender, Recipient, r_BDay);
        }
    }
}
