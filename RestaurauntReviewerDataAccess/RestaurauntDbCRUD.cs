using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestarauntReviewerLibrary;

namespace RestaurauntReviewerDataAccess
{
    public class RestaurauntDbCRUD
    {
        public RestarauntContext db = new RestarauntContext();

        public IEnumerable<Restauraunt> GetRestauraunts()
        {
            return db.restauraunts.ToList();
        }
        //find restaraunt
        public Restauraunt FindRestarauntById (int searchId)
        {
            return db.restauraunts.Find(searchId);
        }
        public Restauraunt FindRestarauntByName(string searchName)
        {
            var sample = db.restauraunts
                .Where(r => r.Name == searchName)
                .FirstOrDefault();
            return sample;
        }
        public void AddRestaraunt(Restauraunt subject)
        {
            db.restauraunts.Add(subject);
            db.SaveChanges();
        }
        public void ChangeRestarauntName(int restId, string newName)
        {
            var target = FindRestarauntById(restId);
            target.Name = newName;
            db.SaveChanges();
        }
        public void DeleteRestaraunt (int delId)
        {
            var delRest = FindRestarauntById(delId);
            db.restauraunts.Remove(delRest);
            db.SaveChanges();
        }
        public List<Restauraunt> SearchRestaraunts (string searchName)
        {
            return db.restauraunts.Where(b => b.Name.Contains(searchName)).ToList();
        }
    }
}
