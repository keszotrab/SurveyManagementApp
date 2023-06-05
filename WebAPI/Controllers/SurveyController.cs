using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly SurveysDbContext _dbContext;
        private readonly UserSurveyService _surveyService;

        SurveyController(SurveysDbContext dbContext, UserSurveyService surveyService) {
            _dbContext = dbContext;
            _surveyService = surveyService;
        }

        /*
        [HttpGet]
        public IEnumerable<SurveyDto> FindAllSurveys()
        {
            return _service.FindAllQuizzes().Select(SurveyDto.of).AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<SurveyDto> FindSurveyByAuthor()
        {
            return _service.FindAllQuizzes().Select(SurveyDto.of).AsEnumerable();
        }

        */


        [HttpPost]
        public ActionResult SaveClosedAnswer([FromBody] ClosedUserAnswersDto dto)
        {
            try
            {
                var answer = _surveyService.SaveClosedAnswer(Mappers.DtoToEntityMapper.FromDtoToClosedUserAnswer(dto));
                return Created("", answer);
            }
            catch (Exception e )
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public ActionResult SaveOpenAnswer([FromBody] OpenUserAnswersDto dto)
        {
            try
            {
                var answer = _surveyService.SaveOpenAnswer(Mappers.DtoToEntityMapper.FromDtoToOpenUserAnswer(dto));
                return Created("", answer);
            }
            catch (Exception e )
            {
                return BadRequest();
            }
        }

    }
}
