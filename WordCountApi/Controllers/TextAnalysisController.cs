using Microsoft.AspNetCore.Mvc;
using WordCountApi.Facade;

namespace WordCountApi.Controllers
{
    [ApiController]
    [Route("/api/textanalysis")]
    public class TextAnalysisController : ControllerBase
    {

        private TextAnalysisControllerFacade textAnalysisControllerFacade;

        public TextAnalysisController()
        {
            this.textAnalysisControllerFacade = new TextAnalysisControllerFacade();
        }

        [HttpPost("file/process/json")]
        public IActionResult PostFileUploadJson(IFormFile file)
        {
            if (file.Length == 0)
            {
                return BadRequest("{ \"code\":\"404\", \"message\":\"File is empty\" }");
            }
            if (!Path.GetExtension(file.FileName).Equals(".txt"))
            {
                return BadRequest("{ \"code\":\"404\", \"message\":\"File must be .txt file\" }");
            }

            string responseJson = textAnalysisControllerFacade
                    .ProcessFileToOutputtedFormat(file.OpenReadStream(), "json");
            return Ok(responseJson);
        }

        [HttpPost("file/process/text")]
        public IActionResult PostFileUploadText(IFormFile file)
        {
            if (file.Length == 0)
            {
                return BadRequest("File is empty");
            }
            if (!Path.GetExtension(file.FileName).Equals(".txt"))
            {
                return BadRequest("File must be .txt file");
            }

            string responseJson = textAnalysisControllerFacade
                    .ProcessFileToOutputtedFormat(file.OpenReadStream(), "text");
            return Ok(responseJson);
        }
    }
}