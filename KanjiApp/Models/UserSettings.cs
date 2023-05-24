namespace KanjiApp.Models
{
    public class UserSettings
    {
        public int KanjisPerPractice { get; set; }
        public int GuessedTillKnown { get; set; }
        public string CurrentSet { get; set; }

        public static UserSettings GetDemo()
        {
            return new UserSettings
            {
                KanjisPerPractice = 20,
                GuessedTillKnown = 5,
                CurrentSet = "N7"
            };
        }
    }
}