using WebScrapperOpenAI.Business.Interfaces;

namespace WebScrapperOpenAI.Business
{
    public class RandomNumberBusiness : IRandomNumberBusiness
    {
        public int GenerateRandomNumber()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 11);
            return randomNumber;
        }
    }
}
