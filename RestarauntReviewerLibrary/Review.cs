using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace RestarauntReviewerLibrary
{
    [DataContract]
    public class Review
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int RestID { get; set; }
        [DataMember]
        public int ReviewerRating { get; set; } //scope in question
        [DataMember]
        public string ReviewerName { get; set; }
        [DataMember]
        public string Reviewercomment { get; set; }
        //Constructor
        //----------------
        public Review(int restarNum, int score, string name)
        {
            RestID = restarNum;
            ReviewerRating = score;
            ReviewerName = name;
        }
        public override string ToString()
        {
            return ($"{ReviewerName} || {ReviewerRating}/n{Reviewercomment}");
        } 
    }
}
