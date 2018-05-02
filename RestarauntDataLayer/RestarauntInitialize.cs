using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RestarauntReviewerLibrary;

namespace RestaurauntDataLayer
{
    class RestarauntInitialize : DropCreateDatabaseIfModelChanges<RestarauntContext>
    {
        protected override void Seed(RestarauntContext context)
        {
            //DataHandler dh = new DataHandler();
            //List<Restauraunt> dataList = dh.GetRestaraunts(@"C:\Users\Alex\source\repos\RestrauntReviewer0\RestarauntReviewerLibrary\ResturauntList.json");
            //foreach (Restauraunt r in dataList )
            //{
            //    context.restauraunts.Add(r);
            //    for ( int i = r.Reviews.Count(); i>0; i--)
            //    {
            //        context.reviews.Add(r.Reviews[i]);
            //    }
            //}
            //seed data
            Restauraunt alpha = new Restauraunt(1, "Krusty Krab", "Bikini Bottom", "California", "12345 Underwater");
            Restauraunt beta = new Restauraunt(2, "Tropoli", "Caroline", "Idaho", "234 Streetplace");
            Restauraunt gamma = new Restauraunt(3, "Brainquil", "Bawcomville", "New Jersey", "345 Nowhere Lane");

            Review Aone = new Review(1 , 5, "SpongeBob");
            Review Atwo = new Review(1, 1, "Squidward");
            Review Athree = new Review(1, 1, "Plankton");
            Review Afour = new Review(1, 5, "Patrick");
            Review Afive = new Review(1, 5, "Sandy");
            //add to context
            context.restauraunts.Add(alpha);
            context.restauraunts.Add(beta);
            context.restauraunts.Add(gamma);
            context.reviews.Add(Aone);
            context.reviews.Add(Atwo);
            context.reviews.Add(Athree);
            context.reviews.Add(Afour);
            context.reviews.Add(Afive);

            base.Seed(context);
            context.SaveChanges();
        }
    }
}
