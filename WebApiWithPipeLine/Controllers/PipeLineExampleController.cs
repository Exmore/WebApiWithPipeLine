using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PipeLine.Domain;
using PipeLine.Models.AddInfoToFileModels;
using PipeLine.WebApiModels;

namespace WebApiWithPipeLine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PipeLineExampleController : ControllerBase
    {
        private readonly ILogger<PipeLineExampleController> _logger;
        public PipeLineExampleController(ILogger<PipeLineExampleController> logger)
        {
        }

        [HttpGet]
        public PipelineResponseModel Get()
        {
            var resultString = "Всё ок";
            var addInfo = "Просто инфа";

            return new PipelineResponseModel
            {
                Result = resultString,
                AddInfo = addInfo
            };
        }


        [HttpPost]
        public PipelineResponseModel Post(AddInfoToFileInModel inModel)
        {
            var resultString = "Всё ок";
            var addInfo = "Стартовая инфа";
            try
            {
                if (!ModelState.IsValid)
                {
                    addInfo = "Неправельный формат входящего сообщения";
                }
                else if (inModel != null)
                {
                    AddInfoToFileExecutorService.Execute(inModel);
                }
                    
            }
            catch (System.Exception ex)
            {
                resultString = "Произошла ошибка";
                addInfo = $"Ошибка: {ex.Message}";
            }

            return new PipelineResponseModel
            {
                Result = resultString,
                AddInfo = addInfo
            };
        }
    }
}