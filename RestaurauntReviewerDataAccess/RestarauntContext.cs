using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RestarauntReviewerLibrary;


namespace RestaurauntReviewerDataAccess
{
    public class RestarauntContext: DbContext
    {
        public DbSet<Restauraunt> restauraunts { get; set; }
        public DbSet <Review> reviews { get; set; }

        public RestarauntContext() : base("name=RestarauntDbConnectionString")
        {
            Database.SetInitializer<RestarauntContext>(new RestarauntInitialize());
        }

        
    }
}
