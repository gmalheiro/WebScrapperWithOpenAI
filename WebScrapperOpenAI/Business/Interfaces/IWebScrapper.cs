namespace WebScrapperOpenAI.Business.Interfaces
{
    public interface IWebScrapper
    {
         Task<String> CertificationStudyPlan(string certification, string scheduledDay);
    }
}
