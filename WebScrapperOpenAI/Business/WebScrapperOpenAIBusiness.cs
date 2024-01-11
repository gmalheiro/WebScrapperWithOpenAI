using HtmlAgilityPack;

namespace WebScrapperOpenAI.Business
{
    public class WebScrapperOpenAIBusiness
    {

        public async Task<string> CertificationStudyPlan(string certification)
        {
            var url = $"https://learn.microsoft.com/pt-br/credentials/certifications/exams/{certification.ToLower()}/";

            using (var httpClient = new HttpClient())
            {
                var html = await httpClient.GetStringAsync(url);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                // Find the starting and ending nodes based on headings
                var startNode = htmlDocument.DocumentNode.SelectSingleNode(@"//h2[contains(text(), 'Habilidades medidas')]");
                var endNode = htmlDocument.DocumentNode.SelectSingleNode(@"//h2[contains(text(), 'Duas maneiras de preparar')]");

                if (startNode != null && endNode != null)
                {
                    // Extract the content between start and end nodes
                    var contentNodes = startNode
                        .SelectNodes(".//following-sibling::node()[following::h2[contains(text(), 'Duas maneiras de preparar')]]")
                        ?.Where(node => node.NodeType == HtmlNodeType.Text || node.Name == "ul" || node.Name == "li")
                        .Select(node => node.OuterHtml)
                        .ToList();

                    return string.Join("", contentNodes ?? new List<string>());
                }
                else
                {
                    return string.Empty;
                }
            }
        }


    }
}
