using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * All Buisiness logic goes here
*/
namespace RestarauntReviewerLibrary
{
    //buisiness code for the console?
    //in a class, or an interface?
    //review session class?
    //serialization? here or in data project: here name adress, email, phone, comments, reviews
    //try json serializer
    public interface IResauraunt
    {
        void addReview();
        float getAverage();
    }

    public class Restauraunt:IResauraunt
    {
        public string Name { get; set; }
        public string Location { get; set; }
        float AverageReview;

        List<Review> reviews;//where do i intitialize a list?

        //a constructor, but not an all-options one
        public Restauraunt(string name, string location)
        {
            Name = name;
            Location = location;
            reviews = new List<Review>();
        }
        public float getAverage() //needs calculation code?
        {
            return AverageReview;
        }
        //public float calcRating() { } //may be uneeded or call when reviews added/changed
        //public void addReview() { }


    }

    public class Review
    {
        int rating { get; set; } //scope in question
        string reviewerName { get; }

        public Review( int score, string name)
        {
            rating = score;
            reviewerName = name;
        }

        public void setReview(int newScore)
        {
            rating = newScore;
        }
    }
}
