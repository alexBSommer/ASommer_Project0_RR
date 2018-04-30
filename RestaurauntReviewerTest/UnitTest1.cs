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
            Restauraunt Testauraunt = new Restauraunt("sampleName");
            Assert.IsTrue(Testauraunt.Name == "sampleName");// gives return type bool
        }
        [TestMethod]
        public void TestRestaurauntCity()
        {
            Restauraunt Testauraunt = new Restauraunt("sampleName", "sampleCity", "sampleState", "sampleAddress");
            Assert.IsTrue(Testauraunt.City == "sampleCity");// gives return type bool
        }
        [TestMethod]
        public void TestRestaurauntState()
        {
            Restauraunt Testauraunt = new Restauraunt("sampleName", "sampleCity", "sampleState", "sampleAddress");
            Assert.IsTrue(Testauraunt.State == "sampleState");// gives return type bool
        }
        [TestMethod]
        public void TestRestaurauntAddress()
        {
            Restauraunt Testauraunt = new Restauraunt("sampleName", "sampleCity", "sampleState", "sampleAddress");
            Assert.IsTrue(Testauraunt.Address == "sampleAddress");// gives return type bool
        }
        [TestMethod]
        public void TestReviewName()
        {
            Restauraunt Testauraunt = new Restauraunt("sampleName", "sampleCity", "sampleState", "sampleAddress");
            Testauraunt.addReview(4.0F, "Bob");
            Assert.IsTrue(Testauraunt.Reviews[0].ReviewerRating == 4.0F);
        }
        public void TestReviewRating()
        {
            Restauraunt Testauraunt = new Restauraunt("sampleName", "sampleCity", "sampleState", "sampleAddress");
            Testauraunt.addReview(4.0F, "Bob");
            Assert.IsTrue(Testauraunt.Reviews[0].ReviewerName == "Bob");
        }
        [TestMethod]
        public void TestAverage()
        {
            Restauraunt Testauraunt = new Restauraunt("sampleName", "sampleCity", "sampleState", "sampleAddress");
            Testauraunt.addReview(2.0F, "Alice");
            Testauraunt.addReview(4.0F, "Bob");
            Assert.IsTrue(Testauraunt.averageReview == 3.0F);
        }
        [TestMethod]
        public void TestAverageUpdate()
        {
            Restauraunt Testauraunt = new Restauraunt("sampleName", "sampleCity", "sampleState", "sampleAddress");
            Testauraunt.addReview(1.0F, "Alice");
            Testauraunt.addReview(3.0F, "Bob");
            if (Testauraunt.averageReview == 2.0F)
            {
                Testauraunt.addReview(5.0F, "Carl");
                Assert.IsTrue(Testauraunt.averageReview == 3.0F);
            }
            else Assert.IsTrue(false);
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
