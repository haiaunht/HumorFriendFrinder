using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumorWebApp.Models
{
    // wow this hurts to write. Should not be trying to slam this in last minute. Would do this differently with more time.
    public class HumorProfile
    {
        public float[] aspects;
        public float[] counts;

        public enum HumorTypes
        {
            physical,
            selfDeprecating,
            surreal,
            improvisation,
            witty,
            wordplay,
            observational,
            potty,
            dark
        }

        public HumorProfile ()
        {
            aspects = new float[9];
            counts = new float[9];
        }

        public HumorProfile (float[] aspects, float[] counts)
        {
            if (aspects.Length != 9 || counts.Length != 9)
            {
                aspects = new float[9];
                counts = new float[9];
            }
            else
            {
                this.aspects = aspects;
                this.counts = counts;
            }
        }


        public static float GetSimilarity(HumorProfile prof1, HumorProfile prof2)
        {
            float similarity = 0;
            // value range from -20 to 20
            for (int i = 0; i < prof1.aspects.Length; i++)
            {
                similarity += 100 - ((100 / 40) * Math.Abs(prof1.GetAverage((HumorTypes)i) - prof1.GetAverage((HumorTypes)i)));
            }

            return similarity / prof1.aspects.Length;
        }

        public float GetAverage(HumorTypes humorType)
        {
            if (counts[(int)humorType] == 0)
                return 0;

            return aspects[(int)humorType] / counts[(int)humorType];
        }

        public void Add(EvaluationItem item, int answer)
        {
            // scale weight by answer
            float fanswer = (answer - 3); // -2 to 2

            if (item.HumorPhysical > 0)
            {
                aspects[0] += item.HumorPhysical * fanswer;
                counts[0]++;
            }
            if (item.HumorSelfDeprecating > 0)
            {
                aspects[0] += item.HumorSelfDeprecating * fanswer;
                counts[0]++;
            }
            if (item.HumorSurreal > 0)
            {
                aspects[0] += item.HumorSurreal * fanswer;
                counts[0]++;
            }
            if (item.HumorImprovisation > 0)
            {
                aspects[0] += item.HumorImprovisation * fanswer;
                counts[0]++;
            }
            if (item.HumorWitty > 0)
            {
                aspects[0] += item.HumorWitty * fanswer;
                counts[0]++;
            }
            if (item.HumorWordplay > 0)
            {
                aspects[0] += item.HumorWordplay * fanswer;
                counts[0]++;
            }
            if (item.HumorObservational > 0)
            {
                aspects[0] += item.HumorObservational * fanswer;
                counts[0]++;
            }
            if (item.HumorPotty > 0)
            {
                aspects[0] += item.HumorPotty * fanswer;
                counts[0]++;
            }
            if (item.HumorDark > 0)
            {
                aspects[0] += item.HumorDark * fanswer;
                counts[0]++;
            }
        }
    }
}
