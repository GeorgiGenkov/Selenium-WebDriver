
using OpenQA.Selenium;

namespace IdeasWebAppTests.Pages
{
	public class IdeaReadPage : BasePage
	{
        public readonly string ideaReadUrl = BaseUrl + "/Ideas/Read";

        public IdeaReadPage(IWebDriver driver) : base(driver)
        {
            
        }

		public IWebElement IdeaTitle => driver.FindElement(By.XPath("//h1[@class='mb-0 h4']"));

		public IWebElement IdeaDescription => driver.FindElement(By.XPath("//p[@class='offset-lg-3 col-lg-6']"));

	}
}
