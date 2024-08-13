
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IdeasWebAppTests.Pages
{
	// Provides quick and easy access to the most used components of the web app as a base for the PoM pattern classes
	public class BasePage
	{
		protected IWebDriver driver;
		protected WebDriverWait wait;
		protected static readonly string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83";

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

		public IWebElement HomeLink =>  driver.FindElement(By.XPath("//img[@class='rounded-circle']"));

		public IWebElement MyProfileLink => driver.FindElement(By.XPath("//a[@class='rounded-circle' and text()='My Profile']"));

		public IWebElement MyIdeasLink => driver.FindElement(By.XPath("//a[@class='rounded-circle' and text()='My Ideas']"));

		public IWebElement CreateIdeaLink => driver.FindElement(By.XPath("//a[@class='rounded-circle' and text()='Create Idea']"));

		public IWebElement LoginButton => driver.FindElement(By.XPath("//a[@class='btn btn-outline-info px-3 me-2'"));

		public IWebElement LogoutButton => driver.FindElement(By.XPath("//a[@type='button' and @class='btn btn-primary me-3'"));


	}
}
