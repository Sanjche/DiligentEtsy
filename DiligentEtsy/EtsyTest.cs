using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using DiligentEtsy.Lib;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace DiligentEtsy
{
    class EtsyTest : BaseTestscs
    {
        [SetUp]
        public void SetUp()
        {
            Logger.SetFileName(@"C:\DiligentEtsy\Etsy.log");
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
            this.wait = new WebDriverWait(this.driver, new TimeSpan(0, 0, 10));

        }

        [TearDown]
        public void TearDown()
        {
            this.driver.Close();
        }

        [Test]

        public void SignIn()
        {
            Logger.Log("INFO:", "Starting SignIn test");
            this.GoToURL("https://www.etsy.com/");

            IWebElement etsyLogo = this.WaitForElement(EC.ElementIsVisible(By.Id("logo")));
            Assert.IsTrue(etsyLogo.Displayed);

            IWebElement linkSignIn = this.WaitForElement(EC.ElementToBeClickable(By.XPath("//button[contains(.,'Sign in')]")));
            Assert.IsTrue(linkSignIn.Displayed);
            linkSignIn.Click();

            IWebElement msgSignIn = this.WaitForElement(EC.ElementExists(By.XPath("//h1[contains(.,'Sign in')]")));
            Assert.IsTrue(msgSignIn.Displayed);

            IWebElement fieldEmail = this.MyFindElement(By.Name("email"));
            this.PopulateInput(By.Name("email"), "alexs.testmail87@gmail.com");

            IWebElement bttnContinue = this.MyFindElement(By.Name("submit_attempt"));
            bttnContinue.Click();


            IWebElement fieldPassword = this.WaitForElement(EC.ElementToBeClickable(By.Name("password")));

            PopulateInput(By.Name("password"), "testcase1");

            IWebElement bttnSignIn = this.MyFindElement(By.Name("submit_attempt"));
            bttnSignIn.Click();


            IWebElement msgWellcome = this.WaitForElement(EC.ElementIsVisible(By.XPath("//h1")));

            Assert.IsTrue(msgWellcome.Displayed);

        }
        [Test]

        public void SearchField()
        {

            Logger.Log("INFO:", "Starting SearchField test");
            this.GoToURL("https://www.etsy.com/");

            IWebElement etsyLogo = this.WaitForElement(EC.ElementIsVisible(By.Id("logo")));
            Assert.IsTrue(etsyLogo.Displayed);

            IWebElement SearchBar = this.WaitForElement(EC.ElementToBeClickable(By.Name("search_query")));
            SearchBar.SendKeys("wall clock");
            IWebElement bttnSearch = this.MyFindElement(By.t);
            bttnSearch.Click();

            IWebElement SelectedItem = this.MyFindElement(By.LinkText(
                    "Oak Wood Wall Clock PAULIS"
                ));
            Assert.IsTrue(SelectedItem.Displayed);
            SelectedItem.Click();


        }

        
    }
    }
