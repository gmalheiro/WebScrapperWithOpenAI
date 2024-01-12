namespace WebScrapperOpenAI.Business.Interfaces
{
    public interface IWebScrapper
    {
         Task<string> CertificationStudyPlan(string certification, string scheduledDay);
         Task<string> CallChatGpt(string phrase, string certification, string scheduledDay);
    }
}
