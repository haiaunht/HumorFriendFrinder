using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumorWebApp.Models
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public EvaluationItem EvalItem { get; set; }
        public int Answer { get; set; }
    }
}
