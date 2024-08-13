using OpenQA.Selenium;

namespace IdeasWebAppTests.Pages
{
	// Provides quick "Login" into the web app
	public class LoginPage : BasePage
	{
        public static readonly string LoginUrl = BaseUrl + "/Users/Login";

        public LoginPage(IWebDriver driver) : base(driver)
        {
            
        }

		public IWebElement EmailInput => driver.FindElement(By.XPath("//input[@name='Email']"));

		public IWebElement PasswordInput => driver.FindElement(By.XPath("//input[@name='Password']"));

		public IWebElement SigninButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg btn-block']"));


		public void Login(string email, string password)
		{
			EmailInput.Clear();
			PasswordInput.Clear();

			EmailInput.SendKeys(email);
			PasswordInput.SendKeys(password);

			SigninButton.Click();
		}

		public void OpenPage()
		{
			driver.Navigate().GoToUrl(LoginUrl);
		}
	}
}
