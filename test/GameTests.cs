using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GameTests
{
    [TestFixture]
    public class GameTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            // Укажите путь до вашего chromedriver.exe
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            _driver = new ChromeDriver(options);
        }

        [Test]
        public void TestScoreInitialization()
        {
            _driver.Navigate().GoToUrl("http://localhost:8080"); // Адреса вашої гри
            var scoreElement = _driver.FindElement(By.Id("scoreLabel")); // ID елемента рахунку
            Assert.AreEqual("0", scoreElement.Text, "Initial score should be 0.");
        }

        [Test]
        public void TestScoreIncreaseOnLanding()
        {
            _driver.Navigate().GoToUrl("http://localhost:8080");
            _driver.FindElement(By.Id("startGameButton")).Click(); // ID кнопки запуску гри

            // Очікуємо стрибок та приземлення
            System.Threading.Thread.Sleep(3000); // Чекаємо, поки персонаж виконає стрибок

            var scoreElement = _driver.FindElement(By.Id("scoreLabel"));
            Assert.AreNotEqual("0", scoreElement.Text, "Score should increase after landing.");
        }

        [Test]
        public void TestGameOverOnFall()
        {
            _driver.Navigate().GoToUrl("http://localhost:8080");
            _driver.FindElement(By.Id("startGameButton")).Click();

            // Симулюємо падіння
            System.Threading.Thread.Sleep(5000); // Чекаємо, поки персонаж впаде

            var gameOverMessage = _driver.FindElement(By.XPath("//*[contains(text(), 'Game Over')]"));
            Assert.IsTrue(gameOverMessage.Displayed, "Game Over message should appear on fall.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}