using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IdeasWebAppTests.Tests
{
	public class IdeaCenterTests : BaseTest
	{
		private string lastCreatedIdeaTitle;
		private string lastCreatedIdeaDescription;

		[Test, Order(1)]
		public void CreateIdeWithInvalidDataTest()
		{
			createIdeaPage.OpenPage();
			createIdeaPage.CreateIdea("", "");

			createIdeaPage.AssertErrormessages();
		}

		[Test, Order(2)]
		public void CreateIdeWithValidDataTest()
		{
			long randomNum = RandomNumber(1000, 10000);

			lastCreatedIdeaTitle = "Title" + randomNum;
			lastCreatedIdeaDescription = "Description" + randomNum;

			createIdeaPage.OpenPage();
			createIdeaPage.CreateIdea(lastCreatedIdeaTitle, lastCreatedIdeaDescription);
			
			Assert.That(driver.Url, Is.EqualTo(myIdeasPage.IdeasUrl), "Incorrect url");

			Assert.That(myIdeasPage.DescriptionLastIdea.Text.Trim(), Is.EqualTo(lastCreatedIdeaDescription), "Incorrect description");
		}

		[Test, Order(3)]
		public void ViewLastIdeaTest()
		{
			myIdeasPage.OpenPage();

			myIdeasPage.ViewButtonLastIdea.Click();

			Assert.That(ideaReadPage.IdeaTitle.Text.Trim(), Is.EqualTo(lastCreatedIdeaTitle), "Incorrect title");

			Assert.That(ideaReadPage.IdeaDescription.Text.Trim(), Is.EqualTo(lastCreatedIdeaDescription), "Incorrect description");

		}

		[Test, Order(4)]
		public void EditLastIdeaTitleTest()
		{
			myIdeasPage.OpenPage();
			myIdeasPage.EditButtonLastIdea.Click();

			string editedTitle = "Edited_" + lastCreatedIdeaTitle;

			ideaEditPage.TitleInput.Clear();
			ideaEditPage.TitleInput.SendKeys(editedTitle);
			ideaEditPage.EditButton.Click();

			Assert.That(driver.Url, Is.EqualTo(myIdeasPage.IdeasUrl), "Incorrect url");

			myIdeasPage.ViewButtonLastIdea.Click();

			Assert.That(ideaReadPage.IdeaTitle.Text.Trim(), Is.EqualTo(editedTitle), "Incorrect title");
		}

		[Test, Order(5)]
		public void EditLastIdeaDescriptionTest()
		{
			myIdeasPage.OpenPage();
			myIdeasPage.EditButtonLastIdea.Click();

			string editedDescription = "Edited_" + lastCreatedIdeaDescription;

			lastCreatedIdeaDescription = editedDescription;

			ideaEditPage.DescribtionInput.Clear();
			ideaEditPage.DescribtionInput.SendKeys(editedDescription);
			ideaEditPage.EditButton.Click();

			Assert.That(driver.Url, Is.EqualTo(myIdeasPage.IdeasUrl), "Incorrect url");

			myIdeasPage.ViewButtonLastIdea.Click();

			Assert.That(ideaReadPage.IdeaDescription.Text.Trim(), Is.EqualTo(editedDescription), "Incorrect description");
		}

		[Test, Order(6)]
		public void DeleteLastIdeaTest()
		{
			myIdeasPage.OpenPage();

			myIdeasPage.DeleteButtonLastIdea.Click();

			bool deletedIdeaStillExist = myIdeasPage.IdeasCards.Any(card => card.Text.Contains(lastCreatedIdeaDescription));

			Assert.That(deletedIdeaStillExist, Is.False, "Deleting failed");
		}
	}
}
