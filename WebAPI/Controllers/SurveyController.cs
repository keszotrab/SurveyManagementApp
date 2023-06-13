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
using Infrastructure.EF.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.VisualStudio.Services.Users;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualStudio.Services.Identity;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly IUserSurveyService _surveyService;
        private readonly SurveysDbContext _dbContext;
        private readonly UserManager<UsersEntity> _userManager;


        public SurveyController(IUserSurveyService surveyService, UserManager<UsersEntity> manager)
        {
            _userManager = manager;
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
        public ActionResult<AnswersDto> FindAnswerById(int answerId)
        {
            var result = AnswersDto.of(_surveyService.FindAnswerById(answerId));
            return result is null ? NotFound() : Ok(result);
        }


        [Route("api/FindQuestionById")]
        [HttpGet]
        public ActionResult<QuestionsDto> FindQuestionById(int questionId)
        {
            var result = QuestionsDto.of(_surveyService.FindQuestionById(questionId));
            return result is null ? NotFound() : Ok(result);
        }

        [Route("api/FindSurveyById")]
        [HttpGet]
        public ActionResult<SurveyDto> FindSurveyById(int surveyId)
        {
            var result = SurveyDto.of(_surveyService.FindSurveyById(surveyId));
            return result is null ? NotFound() : Ok(result);
        }



        [Route("api/FindAllSurveys")]
        [HttpGet]
        public ActionResult<IEnumerable<SurveyDto>> FindAllSurveys()
        {
            var result = _surveyService.FindAllSurveys().Select(SurveyDto.of).AsEnumerable();
            return result is null ? NotFound() : Ok(result);
        }



        [Authorize(Roles = "User")]
        [Route("api/CheckMyId")]
        [HttpGet]
        public async Task<IActionResult> GetUserId()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            if (user == null)
                return NotFound();
            return Ok(user.Id);

        }






        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("api/CreateSurvey")]
        public ActionResult<SurveysEntity> CreateSurvey(string type, string name)
        {
            if (type == "Public" || type == "Private" || type == "Domain")
            {


                //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //var user = _userManager.FindByIdAsync(userId);

                var user = _userManager.GetUserAsync(HttpContext.User).Result;


                SurveysEntity entity = new SurveysEntity()
                {
                    Name = name,
                    Type = type,
                    AuthorId = user.Id
                };
                var saved = _dbContext.Surveys.Add(entity);
                _dbContext.SaveChanges();
                return Created("", entity);
            }
            return BadRequest();
        }




        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("api/AddQuestion")]
        public ActionResult<QuestionsDto> AddQuestion(int surveyId, string question)
        {
            var survey = _dbContext.Surveys.First(x => x.Id == surveyId);
            if (survey.IsFilled == false)
            {

                var user = _userManager.GetUserAsync(HttpContext.User).Result;


                var result = _surveyService.AddQuestion(surveyId, question, user.Id);


                return QuestionsDto.of(result);
            }
            return BadRequest("Nie można edytować wypełnionej ankiety");
        }


        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("api/AddAnswer")]
        public ActionResult<AnswersDto> AddAnswer(int qustionId, string answer, string answerType)
        {
            var question = _dbContext.Questions.First(x => x.Id ==  qustionId);
            var survey = _dbContext.Surveys.First(x => x.Id == question.SurveysId);

            if (survey.IsFilled == false)
            {
                if (answerType == "Open" || answerType == "Closed")
                {
                    var user = _userManager.GetUserAsync(HttpContext.User).Result;

                    var result = _surveyService.AddAnswer(qustionId, answer, answerType, user.Id);


                    return AnswersDto.of(result);
                }
                return BadRequest("zły typ odpowiedzi. Odpowiednie typy to: 'Open' i 'Closed' ");
            }
            return BadRequest("Nie można edytować wypełnionej ankiety");



        }


        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("api/AddDomainCheck")]
        public ActionResult<DomainChecksDto> AddDomainCheck(int surveyId, string domainName)
        {
            var survey = _dbContext.Surveys.First(x => x.Id == surveyId);

            if (survey.IsFilled == false)
            {
                var user = _userManager.GetUserAsync(HttpContext.User).Result;
                var result = _surveyService.AddDomainCheck(surveyId, domainName, user.Id);


                return DomainChecksDto.of(result);
            }
            return BadRequest("Nie można edytować wypełnionej ankiety");
        }


        /////////////////////////////////////////////////////////////////
        ///////////////////// Usuwanko //////////////////////////////////
        /////////////////////////////////////////////////////////////////



        [Authorize(Roles = "User")]
        [HttpDelete]
        [Route("api/RemoveAnswer")]
        public ActionResult RemoveAnswer(int answerId)
        {
            var answer = _dbContext.Answers.First(x=> x.Id == answerId);
            var question = _dbContext.Questions.First(x=> x.Id == answer.QuestionId);
            var survey = _dbContext.Surveys.First(x => x.Id == question.SurveysId);

            if (survey.IsFilled == false)
            {

                var user = _userManager.GetUserAsync(HttpContext.User).Result;
                bool result = _surveyService.RemoveAnswer(answerId, user.Id);

                if (result)
                    return Ok();
                else return BadRequest();
            }
            return BadRequest("Nie można edytować wypełnionej ankiety");

        }


        [Authorize(Roles = "User")]
        [HttpDelete]
        [Route("api/RemoveQuestion")]
        public ActionResult RemoveQuestion(int questionId)
        {
            var question = _dbContext.Questions.First(x => x.Id == questionId);
            var survey = _dbContext.Surveys.First(x => x.Id == question.SurveysId);

            if (survey.IsFilled == false)
            {

                var user = _userManager.GetUserAsync(HttpContext.User).Result;
                bool result = _surveyService.RemoveQuestion(questionId, user.Id);

                if (result)
                    return Ok();
                else return BadRequest();
            }
            return BadRequest("Nie można edytować wypełnionej ankiety");
        }

        [Authorize(Roles = "User")]
        [HttpDelete]
        [Route("api/RemoveSurvey")]
        public ActionResult RemoveSurvey(int surveyId)
        {
            var survey = _dbContext.Surveys.First(x => x.Id == surveyId);

            if (survey.IsFilled == false)
            {
                var user = _userManager.GetUserAsync(HttpContext.User).Result;
                bool result = _surveyService.RemoveSurvey(surveyId, user.Id);

                if (result)
                    return Ok();
                else return BadRequest();
            }
            return BadRequest("Nie można edytować wypełnionej ankiety");
        }


        [Authorize(Roles = "User")]
        [HttpDelete]
        [Route("api/RemoveDomainCheck")]
        public ActionResult RemoveDomainCheck(int domainCheckId)
        {
            var domainCheck = _dbContext.DomainCheck.First(x => x.Id == domainCheckId);
            var survey = _dbContext.Surveys.First(x => x.Id == domainCheck.SurveyId);

            if (survey.IsFilled == false)
            {
                var user = _userManager.GetUserAsync(HttpContext.User).Result;
                bool result = _surveyService.RemoveDomainCheck(domainCheckId, user.Id);

                if (result)
                    return Ok();
                else return BadRequest();
            }
            return BadRequest("Nie można edytować wypełnionej ankiety");
        }



        /////////////////////////////////////////////////////////////////
        ///////////////  //// Add User Answers ////  ////////////////////
        /////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////
        ///////////////  //// Public Answers  ////  /////////////////////
        /////////////////////////////////////////////////////////////////

        [AllowAnonymous]
        [HttpPost]
        [Route("api/PublicClosedAnswer")]
        public ActionResult<ClosedUserAnswersDto> PublicClosedAnswer(int answerId, string email)
        {
            var answer = _dbContext.Answers.First(x => x.Id == answerId);
            var question = _dbContext.Questions.First(x => x.Id == answer.QuestionId);
            var survey = _dbContext.Surveys.First(x => x.Id == question.SurveysId);

            if (survey.Type == "Public" || survey.Type == "public")
            {
                var result = _surveyService.PublicClosedAnswer(answerId, email);
                survey.IsFilled = true;
                _dbContext.SaveChanges();
                return ClosedUserAnswersDto.of(result);
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/PublicOpenAnswer")]
        public ActionResult<OpenUserAnswersDto> PublicOpenAnswer(int answerId, string email, string answerText)
        {
            var answer = _dbContext.Answers.First(x => x.Id == answerId);
            var question = _dbContext.Questions.First(x => x.Id == answer.QuestionId);
            var survey = _dbContext.Surveys.First(x => x.Id == question.SurveysId);

            if (survey.Type == "Public" || survey.Type == "public")
            {
                var result = _surveyService.PublicOpenAnswer(answerId, email, answerText);
                survey.IsFilled = true;
                _dbContext.SaveChanges();
                return OpenUserAnswersDto.of(result);
            }
            return BadRequest();
        }


        ////////////////////////////////////////////////////////////////////////////
        ///////////////////////  ////  Private  ////  //////////////////////////////
        ////////////////////////////////////////////////////////////////////////////

        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("api/PrivateClosedAnswer")]
        public ActionResult<ClosedUserAnswersDto> PrivateClosedAnswer(int answerId)
        {
            var answer = _dbContext.Answers.First(x => x.Id == answerId);
            var question = _dbContext.Questions.First(x => x.Id == answer.QuestionId);
            var survey = _dbContext.Surveys.First(x => x.Id == question.SurveysId);

            if (survey.Type == "Private" || survey.Type == "private")
            {

                var user = _userManager.GetUserAsync(HttpContext.User).Result;

                var result = _surveyService.PrivateClosedAnswer(answerId, user.Id);
                survey.IsFilled = true;
                _dbContext.SaveChanges();
                return ClosedUserAnswersDto.of(result);
            }
            return BadRequest();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("api/PrivateOpenAnswer")]
        public ActionResult<OpenUserAnswersDto> PrivateOpenAnswer(int answerId, string answerText)
        {
            var answer = _dbContext.Answers.First(x => x.Id == answerId);
            var question = _dbContext.Questions.First(x => x.Id == answer.QuestionId);
            var survey = _dbContext.Surveys.First(x => x.Id == question.SurveysId);

            if (survey.Type == "Private" || survey.Type == "private")
            {
                var user = _userManager.GetUserAsync(HttpContext.User).Result;

                var result = _surveyService.PrivateOpenAnswer(answerId, user.Id, answerText);
                survey.IsFilled = true;
                _dbContext.SaveChanges();
                return OpenUserAnswersDto.of(result);
            }
            return BadRequest();
        }

        ////////////////////////////////////////////////////////////////////////////
        ///////////////////////  ////  Domain  ////  ///////////////////////////////
        ////////////////////////////////////////////////////////////////////////////

        [AllowAnonymous]
        [HttpPost]
        [Route("api/DomainClosedAnswer")]
        public ActionResult<ClosedUserAnswersDto> DomainClosedAnswer(int answerId, string domain)
        {
            var answer = _dbContext.Answers.First(x => x.Id == answerId);
            var question = _dbContext.Questions.First(x => x.Id == answer.QuestionId);
            var survey = _dbContext.Surveys.First(x => x.Id == question.SurveysId);

            if (survey.Type == "Domain" || survey.Type == "domain")
            {
                var result = _surveyService.DomainClosedAnswer(answerId, domain);
                survey.IsFilled = true;
                _dbContext.SaveChanges();
                return ClosedUserAnswersDto.of(result);
            }
            return BadRequest();
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("api/DomainOpenAnswer")]
        public ActionResult<OpenUserAnswersDto> DomainOpenAnswer(int answerId, string domain, string answerText)
        {
            var answer = _dbContext.Answers.First(x => x.Id == answerId);
            var question = _dbContext.Questions.First(x => x.Id == answer.QuestionId);
            var survey = _dbContext.Surveys.First(x => x.Id == question.SurveysId);

            if (survey.Type == "Domain" || survey.Type == "domain")
            {
                var result = _surveyService.DomainOpenAnswer(answerId, domain, answerText);
               
                
                survey.IsFilled = true;
                _dbContext.SaveChanges();


                return OpenUserAnswersDto.of(result);
            }
            return BadRequest();
        }



    }
}
