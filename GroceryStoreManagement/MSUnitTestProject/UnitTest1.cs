using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MSUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [ClassInitialize]
        public static void BeforeClass(TestContext tc)
        {
            Console.WriteLine("This is before class");
        }

        [ClassCleanup]
        public static void AfterClass()
        {
            Console.WriteLine("This is after class");
        }

        [TestInitialize]
        public void BeforeTest()
        {
            Console.WriteLine("This is before test");
        }

        [TestCleanup]
        public void AfterTest()
        {
            Console.WriteLine("This is after test");
        }

        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("This is test method 1");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine("This is test method 1");
        }

    }
}
