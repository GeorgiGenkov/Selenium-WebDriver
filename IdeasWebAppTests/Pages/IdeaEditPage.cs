
using OpenQA.Selenium;

namespace IdeasWebAppTests.Pages
{
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
