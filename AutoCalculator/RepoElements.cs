using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCalculator
{
    class RepoElements
    {
        public static By Btn0 { get; set; } = By.Id("Btn0");
        public static By Btn1 { get; set; } = By.Id("Btn1");
        public static By Btn2 { get; set; } = By.Id("Btn2");
        public static By Btn3 { get; set; } = By.Id("Btn3");
        public static By BtnMinus { get; set; } = By.Id("BtnMinus");
        public static By BtnPlus { get; set; } = By.Id("BtnPlus");
        public static By BtnMult { get; set; } = By.Id("BtnMult");
        public static By BtnCalc { get; set; } = By.Id("BtnCalc");
        public static By BtnParanL { get; set; } = By.Id("BtnParanL");
        public static By BtnParanR { get; set; } = By.Id("BtnParanR");
        public static By BtnSin { get; set; } = By.Id("BtnSin");
        public static By BtnClear { get; set; } = By.Id("BtnClear");
        public static By BtnHist { get; set; } = By.Id("hist");
        public static By BtnClearhistory { get; set; } = By.Id("clearhistory");
        public static By inputTxt { get; set; } = By.Id("input");
        public static By HistoryList { get; set; } = By.XPath("//*[@id='histframe']/ul");
    }
}
