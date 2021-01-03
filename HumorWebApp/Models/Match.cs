using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumorWebApp.Models
{
    public class Match
    {
        public int Id { get; set; }
        public ApplicationUser User1 { get; set; }
        public ApplicationUser User2 { get; set; }
        public DateTime TimeOfMatch { get; set; }
    }
}
