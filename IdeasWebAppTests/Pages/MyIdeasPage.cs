
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace IdeasWebAppTests.Pages
{
	// Provides an access to the existing "Ideas" on the currently logged account and quick access to the lastly created "Idea"
	public class MyIdeasPage : BasePage
	{
		public readonly string IdeasUrl = BaseUrl + "/Ideas/MyIdeas";

		public MyIdeasPage(IWebDriver driver) : base(driver)
        {
            
        }

		public ReadOnlyCollection<IWebElement> IdeasCards => driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));

		public IWebElement ViewButtonLastIdea => IdeasCards.Last().FindElement(By.XPath("//a[contains(@href, '/Ideas/Read')]"));

		public IWebElement EditButtonLastIdea => IdeasCards.Last().FindElement(By.XPath("//a[contains(@href, '/Ideas/Edit')]"));

		public IWebElement DeleteButtonLastIdea => IdeasCards.Last().FindElement(By.XPath("//a[contains(@href, '/Ideas/Delete')]"));

		public IWebElement DescriptionLastIdea => IdeasCards.Last().FindElement(By.XPath("//p[@class='card-text']"));


		public void OpenPage()
		{
			driver.Navigate().GoToUrl(IdeasUrl);
		}

    }
}
