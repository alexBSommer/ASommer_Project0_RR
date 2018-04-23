using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using PalindromeLibrary;
using Palindrome;

namespace PalindromeTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Candidate testCandidate = new Candidate("racecar");
            Assert.IsTrue(testCandidate.status);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Candidate testCandidate = new Candidate("Racecar");
            Assert.IsTrue(testCandidate.status);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Candidate testCandidate = new Candidate("1221");
            Assert.IsTrue(testCandidate.status);
        }
        [TestMethod]
        public void TestMethod4()
        {
            //never Odd, or Even.
            Candidate testCandidate = new Candidate("never Odd, or Even.");
            Assert.IsTrue(testCandidate.status);
        }
        [TestMethod]
        public void TestMethod5()
        {
            //1231
            Candidate testCandidate = new Candidate("1231");
            Assert.IsFalse(testCandidate.status);

        }
        [TestMethod]
        public void TestMethod6()
        {
            //aBc
            Candidate testCandidate = new Candidate("aBc");
            Assert.IsFalse(testCandidate.status);
        }
    }
}
