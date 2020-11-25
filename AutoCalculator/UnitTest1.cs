using AutoCalculator;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Tests
{
    public class Tests : BaseSelenium
    {
        #region Constructors
        [OneTimeSetUp] // Check if can be inherited from base class
        public static void MyClassInitialize()
        {
            Instance.Navigate().GoToUrl("https://web2.0calc.com/");
            Click(RepoElements.BtnClear);
            Thread.Sleep(5000);
            Click(FindIdentifierByTxt("AGREE"));
        }
        [SetUp]
        public void Setup()
        {
        }

        #endregion

        [Test]
        public void AllTests()
        {
            Assert.Multiple(() =>
            {
                //2 + 3 = 5
                Console.WriteLine("Test 2 + 3 = 5");
                Click(RepoElements.BtnClear);
                Click(RepoElements.Btn2);
                Click(RepoElements.BtnPlus);
                Click(RepoElements.Btn3);
                Click(RepoElements.BtnCalc);
                var res = GetInputValue(RepoElements.inputTxt);
                Assert.AreEqual("5", res);
                Click(RepoElements.BtnHist);
                //History validation
                var stat = GetResults(RepoElements.HistoryList);
                Assert.AreEqual("2+3", stat[1]);
                Assert.AreEqual("= 5", stat[0]);
                //10 – 2 = 8
                Console.WriteLine("Test 10 – 2 = 8");
                Click(RepoElements.BtnClear);
                Click(RepoElements.Btn1);
                Click(RepoElements.Btn0);
                Click(RepoElements.BtnMinus);
                Click(RepoElements.Btn2);
                Click(RepoElements.BtnCalc);
                res = GetInputValue(RepoElements.inputTxt);
                Assert.AreEqual("8", res);
                //History validation
                stat = GetResults(RepoElements.HistoryList);
                Assert.AreEqual("10-2", stat[1]);
                Assert.AreEqual("= 8", stat[0]);
                //(10 - 2) * 2! = 20
                Console.WriteLine("Test (10 - 2) * 2! = 20");
                Click(RepoElements.BtnClear);
                Click(RepoElements.BtnParanL);
                Click(RepoElements.Btn1);
                Click(RepoElements.Btn0);
                Click(RepoElements.BtnMinus);
                Click(RepoElements.Btn2);
                Click(RepoElements.BtnParanR);
                Click(RepoElements.BtnMult);
                Click(RepoElements.Btn2);
                Click(RepoElements.BtnCalc);
                res = GetInputValue(RepoElements.inputTxt);
                Assert.AreNotEqual("20", res);
                //History validation
                stat = GetResults(RepoElements.HistoryList);
                Assert.AreEqual("(10-2)*2", stat[1]);
                Assert.AreEqual("= 16", stat[0]);
                //Sin(30) = 0.5
                Console.WriteLine("Test Sin(30) = 0.5");
                Click(RepoElements.BtnClear);
                Click(RepoElements.BtnSin);
                Click(RepoElements.Btn3);
                Click(RepoElements.Btn0);
                Click(RepoElements.BtnParanR);
                Click(RepoElements.BtnCalc);
                res = GetInputValue(RepoElements.inputTxt);
                Assert.AreEqual("0.5", res);
                //History validation
                stat = GetResults(RepoElements.HistoryList);
                Assert.AreEqual("sin(30)", stat[1]);
                Assert.AreEqual("= 0.5", stat[0]);

                Assert.AreEqual(4, GetItemsCount(RepoElements.HistoryList), "History items count validation");
                Click(RepoElements.BtnClearhistory);
                ClosePopUpAlert();

                Assert.AreEqual(0, GetItemsCount(RepoElements.HistoryList), "History items count validation");
            });
        }

        [TearDown]
        public void TearDown()
        {
        }
        [OneTimeTearDown]
        public void Cleanup()
        {
            try
            {
                Instance.Quit();
            }
            catch { Instance.Dispose(); }
        }
    }
}
