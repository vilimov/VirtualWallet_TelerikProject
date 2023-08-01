namespace VirtualWallet.Tests.TestHelpers
{
    public class CardHelper
    {
        public static Card GetTestCard()
        {
            return new Card
            {
                Id = 1,
                Number = "9876543210123456",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Test User1",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 1
            };
        }

        public static List<Card> GetTestCards()
        {
            return new List<Card>
            {
                new Card
                {
                    Id = 1,
                    Number = "9876543210123457",
                    ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                    CardHolder = "Test User2",
                    CheckNumber = "649",
                    IsCreditCard = true,
                    UserId = 1
                },
                new Card
                {
                    Id = 2,
                    Number = "9876543210123458",
                    ExpirationDate = DateTime.Now.AddYears(1).AddMonths(2), CardHolder = "Test User3",
                    CheckNumber = "223",
                    IsCreditCard = true,
                    UserId = 2
                },
                new Card
                {
                    Id = 3,
                    Number = "9876543210123459",
                    ExpirationDate = DateTime.Now.AddYears(3).AddMonths(9),
                    CardHolder = "Test User4",
                    CheckNumber = "684",
                    IsCreditCard = true,
                    UserId = 3
                }
            };
        }
    }
}
