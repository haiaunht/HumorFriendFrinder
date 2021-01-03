using HumorWebApp.Data;
using HumorWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HumorWebApp.Controllers
{
    public class EvaluationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private static int _size;
        public static int totalPoint;

        public EvaluationController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _size = _dbContext.EvaluationItem.Count();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            EvaluationItem evalItem = new EvaluationItem();
            try
            {
                // get user answer eval ids
                var answered = _dbContext.UserAnswer.Where(u => u.User.Id == user.Id).Select(a => a.EvalItem.Id);
                var items = _dbContext.EvaluationItem.Where(i => !answered.Contains(i.Id));
                evalItem = items.Take(1).First();
                System.Diagnostics.Debug.WriteLine("The eval item title is: '" + evalItem.Title + "'");

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                evalItem.Title = "You have answered everything!";
            }

            return View(evalItem);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Answer(IFormCollection form)
        {
            var user = await _userManager.GetUserAsync(User);
            try // kinda sorta abusing try catches, there is a better way to do this...
            {
                int evalItemId = int.Parse(form["evalItemId"]);
                int answerVal = int.Parse(form["answer"]);
                //int answerVal = int.Parse(HttpContext.Request.Query["inlineRadioOptions"]);

                EvaluationItem answeredEvalItem = _dbContext.EvaluationItem.First(i => i.Id == evalItemId);

                if (_dbContext.UserAnswer.Where(u => u.User.Id == user.Id && u.EvalItem.Id == evalItemId).Count() == 0)
                {
                    UserAnswer answer = new UserAnswer();
                    answer.User = user;
                    answer.EvalItem = answeredEvalItem;
                    answer.Answer = answerVal;
                    _dbContext.UserAnswer.Add(answer);
                    _dbContext.SaveChanges();
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception parsing POST Answer: " + e);
            }

            return RedirectToAction("Index");
        }

        
    }
}
