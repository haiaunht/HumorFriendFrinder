using HumorWebApp.Data;
using HumorWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumorWebApp.Controllers
{
    public class FindMatchController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public FindMatchController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        // GET: FindMatchController
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var answered = _dbContext.UserAnswer.Where(u => u.User.Id == user.Id);
            if (answered.Count() != 0)
            {
                ViewBag.Total = answered.Sum(x => x.Answer) / answered.Count();

                return View();
            }
            else 
            {
                // if the user is trying to see matches prematurely, send back to evaluation page
                return RedirectToAction("Index", "Evaluation");
            }
        }


        public async Task<IActionResult> Match()
        {
            
            var user = await _userManager.GetUserAsync(User);
            UserAnswer mainUser = _dbContext.UserAnswer.Where(u => u.User.Id == user.Id).FirstOrDefault();



            Match pair = new Match();
            pair.User1 = user;

            // First pass of matching algorithm: grab all users, pair with best match
            IQueryable<UserAnswer> answers = _dbContext.UserAnswer.Include(i => i.EvalItem).Where(u => u.User.Id == user.Id);

            if (answers.Count() == 0)
                return RedirectToAction("Index", "Evaluation");

            // calculate current user humor profile
            //float humorLevel = answers.Sum(x => x.Answer) / answers.Count();
            HumorProfile curHumorProfile = new HumorProfile();
            foreach (UserAnswer ua in answers.ToList())
            {
                curHumorProfile.Add(ua.EvalItem, ua.Answer);
            }

            IdentityUser[] users = _dbContext.Users.Where(u => u.Id != user.Id).ToArray();

            int bestMatchIndex = -1;
            float bestMatchSimilarity = float.MinValue;
            for (int i = 0; i < users.Length; i++)
            {
                answers = _dbContext.UserAnswer.Include(i => i.EvalItem).Where(u => u.User.Id == users[i].Id);
                if (answers.Count() == 0)
                    continue;

                HumorProfile otherHumorProfile = new HumorProfile();
                foreach (UserAnswer ua in answers.ToList())
                {
                    otherHumorProfile.Add(ua.EvalItem, ua.Answer);
                }
                float otherSimilarity = HumorProfile.GetSimilarity(curHumorProfile, otherHumorProfile);
                if (otherSimilarity > bestMatchSimilarity)
                {
                    bestMatchIndex = i;
                    bestMatchSimilarity = otherSimilarity;
                }
                               
            }

            if (bestMatchIndex >= 0)
                pair.User2 = _userManager.FindByIdAsync(users[bestMatchIndex].Id).Result;

                       
            pair.TimeOfMatch = DateTime.Now;

            return View(pair);
        }

        
    }
}
