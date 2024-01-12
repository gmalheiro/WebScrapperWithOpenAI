using HtmlAgilityPack;
using WebScrapperOpenAI.Business.Interfaces;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace WebScrapperOpenAI.Business
{
    public class WebScrapperBusiness : IWebScrapper
    {

        private readonly OpenAIAPI? _chatGpt;

        public WebScrapperBusiness(OpenAIAPI? chatGpt)
        {
            _chatGpt = chatGpt;
        }

        public async Task<string> CertificationStudyPlan(string certification,string scheduledDay)
        {
            var url = $"https://learn.microsoft.com/en-us/credentials/certifications/exams/{certification.ToLower()}/";

            var listWithoutHTML = new List<string>();
            
            using (var httpClient = new HttpClient())
            {
                var html = await httpClient.GetStringAsync(url);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var divs = htmlDocument.DocumentNode.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Contains("section is-small is-uniform padding-top-sm padding-top-xxs-tablet"));

                foreach (var div in divs)
                {
                    listWithoutHTML.Add(div.InnerText.Trim());
                }

                listWithoutHTML.RemoveAt(1);
            }

                var response = await CallChatGpt(listWithoutHTML?.FirstOrDefault() ?? "",certification,scheduledDay);


                return response.Trim();

            
        }

        public async Task<string> CallChatGpt(string phrase,string certification, string scheduledDay)
        {
            using (var httpClient = new HttpClient())
            {
                var response = "";

                var prompt = $@"
                        Atue como um Tutor especialista que cria planos de estudo para ajudar as pessoas a obter a certificação {certification}.
                       Você receberá o objetivo do aluno, seu comprometimento de tempo e preferência de recursos.

                        Você criará um plano de estudo com cronogramas que corresponda a a data em que minha prova está marcada que é : {scheduledDay}

                        Meu primeiro pedido é : Quero obter a {certification} com foco nas questões com maior percentual.
                         
                        Crie um plano de estudos para mim.
 
                        Vou escrever para você as habilidades e suas porcentagens delimitadas por ``````
 
                        FOQUE NAS HABILIDADES COM MAIOR PORCENTAGEM

                        
                        UTILIZE ESSE MODELO COMO BASE COMO DEVE RESPONDER:
                        

                        {certification}
                        1° semana  :
                        - Plan and manage an Azure AI solution (15–20%)
                        - Implement decision support solutions (10–15%)
                        
                        2° semana:
                        - Implement computer vision solutions (15–20%)
                        
                        3° semana:
                        - Implement natural language processing solutions (30–35%)
                        
                        4° semana:
                        - Implement knowledge mining and document intelligence solutions (10–15%)
                        - Implement generative AI solutions (10–15%)

                    HABILIDADES : ```{phrase}``` ";

                var completion = new CompletionRequest
                {
                    Prompt = prompt,
                    Model = Model.DefaultModel,
                    MaxTokens = 200
                };
                var result = await _chatGpt?.Completions.CreateCompletionAsync(completion)!;
                result.Completions.ForEach(resultText => response = resultText.Text);

                return response;
            }
        }

    }
}
