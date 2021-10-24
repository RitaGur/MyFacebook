namespace BDayCardsGenerator
{
    using System.Collections.Generic;

    public static class BDayGreetingsGenerator
    {
        private static readonly List<string> sr_Greetings;
        private static int s_Index = 0;

        static BDayGreetingsGenerator()
        {
            sr_Greetings = new List<string>();
            sr_Greetings.Add("Hey " + "{1}"
                                    + ", it's {0}, I can't wait for your birtday that's coming up on {2}. I am so excited for you");
            sr_Greetings.Add("Greeting card from {0}:, on {2} you will have your birthday I am so happy for you {1}");
            sr_Greetings.Add("Dear {1}, your birthday is coming up soon, {2} is so close, Can't wait to meet you and celebrate. your {0}");
            sr_Greetings.Add("Hello !! it's me {0}, How are you doing {1}? I heard that your birthday is on {2}. would you like us to celebrate ?");
            sr_Greetings.Add("Whats up? Long time no see !! it's {0}, How are you doing {1}?  {2} is your birthday. would you like us to celebrate ?");
        }

        public static string GetGreeting()
        {
            string greetingResult = sr_Greetings[s_Index];
            s_Index++;

            if (s_Index >= sr_Greetings.Count)
            {
                s_Index = 0;
            }

            return greetingResult;
        }
    }
}