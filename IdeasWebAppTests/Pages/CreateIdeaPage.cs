
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace IdeasWebAppTests.Pages
{
	public class CreateIdeaPage : BasePage
	{
		public static readonly string CreateIdeaUrl = BaseUrl + "/Ideas/Create";

        public CreateIdeaPage(IWebDriver driver) : base(driver)
        {
            
        }

		public IWebElement TitleInput => driver.FindElement(By.XPath("//input[@name='Title']"));

		public IWebElement DescribtionInput => driver.FindElement(By.XPath("//textarea[@name='Description']"));

		public IWebElement CreateButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg' and @type='submit']"));

		public IWebElement MainMessage => driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']/ul/li"));

		public IWebElement TitleErrorMessage => driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"))[0];

		public IWebElement DescribtionErrorMessage => driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"))[1];


		public void OpenPage()
		{
			driver.Navigate().GoToUrl(CreateIdeaUrl);
		}

		public void CreateIdea(string title, string description)
		{
			TitleInput.Clear();
			DescribtionInput.Clear();

			TitleInput.SendKeys(title);
			DescribtionInput.SendKeys(description);
			
			CreateButton.Click();
		}

		public void AssertErrormessages()
		{
			Assert.True(driver.Url.Equals(CreateIdeaUrl), "Same Url");

			Assert.True(MainMessage.Text.Equals("Unable to create new Idea!"), "Main Error Message");

			Assert.True(TitleErrorMessage.Text.Equals("The Title field is required."), "Title Error Message");

			Assert.True(DescribtionErrorMessage.Text.Equals("The Description field is required."), "Description Error Message");
		}
	}
}
