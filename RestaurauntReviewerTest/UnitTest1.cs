using RestrauntReviewer0;
using RestarauntReviewerLibrary;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
/*
* Handle Unit tests
* Not cause actual database access
* reaserch how to write unit testing
* test small pieces of code
*/

namespace RestaurauntReviewerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRestaurauntName()
        {
            Restauraunt Testauraunt = new Restauraunt("sampleName", "sampleLocation" );
           Debug.Assert (Testauraunt.Name == "sampleName");// gives return type bool
        }
        [TestMethod]
        public void TestRestaurauntLocation()
        {
            Restauraunt Testauraunt = new Restauraunt("sampleName", "sampleLocation");
            Debug.Assert(Testauraunt.Location == "sampleLocation");// gives return type bool
        }
        [TestMethod]
        public void TestReview()
        {

        }
        [TestMethod]
        public void TestAverage()
        {

        }
        /*
         * Tests to write:
         * get an average
         * add review, is average updated?
         * change review, is average updated?
         * get review data
         * top 3 reviews
         * data serialization
         * is object matching w/ seialize and deserialize
         * search function by name
         * sort by name
         * check invalid user input
         * menu check
         *
         */
    }

}
