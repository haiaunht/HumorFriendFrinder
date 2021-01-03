using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumorWebApp.Models
{
    // Covers humor AND survey-type questions
    public class EvaluationItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TextContent { get; set; }
        public string Link { get; set; }

        public float HumorPhysical { get; set; }
        public float HumorSelfDeprecating { get; set; }
        public float HumorSurreal { get; set; }
        public float HumorImprovisation { get; set; }
        public float HumorWitty { get; set; }
        public float HumorWordplay { get; set; }
        public float HumorObservational { get; set; }
        public float HumorPotty { get; set; }
        public float HumorDark { get; set; }
    }
}
