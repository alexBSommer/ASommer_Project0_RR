using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntReviewerLibrary
{
    public static class TopThree
    {
        public static List<Restauraunt> GetTop(List<Restauraunt> candidates)
        {
            List<Restauraunt> results = new List<Restauraunt>();
            List<Restauraunt> workspace = candidates;
            float Best = 0F;
            Restauraunt top= null;
            foreach (Restauraunt r in workspace)
            {
                if (r.GetAverage() > Best)
                {
                    Best = r.GetAverage();
                    top = r;
                }
            }
            workspace.Remove(top);
            float SecondBest = 0F;
            Restauraunt second= null;
            foreach (Restauraunt r in workspace)
            {
                if (r.GetAverage() > SecondBest)
                {
                    SecondBest = r.GetAverage();
                    second = r;
                }
            }
            workspace.Remove(second);
            float ThirdBest = 0F;
            Restauraunt third = null;
            foreach (Restauraunt r in workspace)
            {
                if (r.GetAverage() > ThirdBest)
                {
                    ThirdBest = r.GetAverage();
                    third = r;
                }
            }
            results.Add(top);
            results.Add(second);
            results.Add(third);
            return results;
        }
    }
}
