
using OpenQA.Selenium;

namespace IdeasWebAppTests.Pages
{
	// Provides an access to the input fields of the "Create Idea" form and it's submit button
	public class IdeaEditPage : BasePage
	{
		public static readonly string CreateIdeaUrl = BaseUrl + "/Ideas/Create";

		public IdeaEditPage(IWebDriver driver) : base(driver)
		{

		}

		public IWebElement TitleInput => driver.FindElement(By.XPath("//input[@name='Title']"));

		public IWebElement DescribtionInput => driver.FindElement(By.XPath("//textarea[@name='Description']"));

		public IWebElement EditButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg' and @type='submit']"));

	}
}
