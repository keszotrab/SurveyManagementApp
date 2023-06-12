using ApplicationCore;
using ApplicationCore.Models;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using Infrastructure.Mappers;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly IUserSurveyService _surveyService;
        private readonly SurveysDbContext _dbContext;

        public SurveyController(IUserSurveyService surveyService
            ) {

            _dbContext = new SurveysDbContext();
            _surveyService = surveyService;

        }


        [Route("api/FirstSurveyName")]
        [HttpGet]
        public string FirstSurveyName()
        {
            return _dbContext.Surveys.First().Name;
        }
        

        [Route("api/FindAnswerById")]
        [HttpGet]
        public AnswersDto FindAnswerById(int answerId)
        {
            return AnswersDto.of(_surveyService.FindAnswerById(answerId));
        }

        [Route("api/FindSurveyById")]
        [HttpGet]
        public SurveyDto FindSurveyById(int surveyId)
        {
            return SurveyDto.of(_surveyService.FindSurveyById(surveyId));
        }



        [Route("api/FindQuestionById")]
        [HttpGet]
        public QuestionsDto FindQuestionById(int questionId)
        {
            return QuestionsDto.of(_surveyService.FindQuestionById(questionId));
        }












        /*
         * 
        [AllowAnonymous]
        [Route("api/ShowAllSurveys")]
        [HttpGet]
        public IEnumerable<SurveyDto> FindAllSurveys()
        {

            return _surveyService.FindAllSurveys().Select(SurveyDto.of).AsEnumerable();
        }
        */






        /*
        [HttpGet]
        public IEnumerable<SurveyDto> FindSurveyByAuthor()
        {
            return _service.FindAllQuizzes().Select(SurveyDto.of).AsEnumerable();
        }


        */

        //okay, so basicly what i want to do is Survey id, so i know what survey type it is.
        //probably remove id from dto class becasue it's basicly useless 


        /*
        [Route("api/SaveClosed")]
        [HttpPost]
        public ActionResult SaveClosedAnswer([FromBody] ClosedUserAnswersDto dto, int SurveyId)
        {
            try
            {
                var answer = _surveyService.SaveClosedAnswer(DtoToEntityMapper.FromDtoToClosedUserAnswer(dto));
                return Created("", answer);
            }
            catch (Exception e )
            {
                return BadRequest();
            }
        }

        [Route("api/SaveOpen")]
        [HttpPost]
        public ActionResult SaveOpenAnswer([FromBody] OpenUserAnswersDto dto)
        {
            try
            {
                var answer = _surveyService.SaveOpenAnswer(DtoToEntityMapper.FromDtoToOpenUserAnswer(dto));
                return Created("", answer);
            }
            catch (Exception e )
            {
                return BadRequest();
            }
        }
        */
    }
}
