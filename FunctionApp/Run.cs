
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using FunctionApp.DTO;
using CaesarsLogic;

namespace FunctionApp
{
    public static class Run
    {
        [FunctionName("Run")]
        public static async System.Threading.Tasks.Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            string result = null;

            var logic = new Logic('\r', '\n');
            RequestDTO requestDTO;
            try
            {
                requestDTO = JsonConvert.DeserializeObject<RequestDTO>(requestBody);

                if (requestDTO.Encrypt)
                {
                    result = logic.GetEncryptString(requestDTO.Steps, requestDTO.Text);
                }
                else
                {
                    result = logic.GetDecryptString(requestDTO.Steps, requestDTO.Text);
                }
            }
            catch
            {

            }

            return (ActionResult)new OkObjectResult($"{result}");
        }
    }
}
