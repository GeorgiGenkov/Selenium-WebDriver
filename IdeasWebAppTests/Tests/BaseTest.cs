using IdeasWebAppTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IdeasWebAppTests.Tests
{
	public class BaseTest
	{
        public IWebDriver driver;
		public LoginPage loginPage;
		public CreateIdeaPage createIdeaPage;
		public MyIdeasPage myIdeasPage;
		public IdeaReadPage ideaReadPage;
		public IdeaEditPage ideaEditPage;

		private readonly string email = "youremail@mail.com";
		private readonly string password = "RepeatYourPassword";

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			var chromeOptions = new ChromeOptions();
			chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
			chromeOptions.AddArgument("--disable-search-engine-choice-screen");

			driver = new ChromeDriver(chromeOptions);
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			loginPage = new LoginPage(driver);
			createIdeaPage = new CreateIdeaPage(driver);
			myIdeasPage = new MyIdeasPage(driver);
			ideaReadPage = new IdeaReadPage(driver);
			ideaEditPage = new IdeaEditPage(driver);

			loginPage.OpenPage();
			loginPage.Login(email, password);
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			driver.Quit();
			driver.Dispose();
		}


		public long RandomNumber(long min, long max)
		{
			Random random = new Random();

			long result = random.NextInt64(min, max);

			return result;
		}
    }
}
