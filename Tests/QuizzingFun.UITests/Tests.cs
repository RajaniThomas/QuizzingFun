using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using QuizzingFun.UITests;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace QuizzingFun.UITest
{
    [TestFixture(Platform.Android)]

    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        /*Test to check if Main Page is displaying correctly */
        [Test]
        public void Test1_DisplayMainPageCorrectly()
        {
            //Arrange
            string expectedResult = "FUN QUIZZZ!";
           

            //Act
            AppResult[] results = app.WaitForElement(v => v.Marked("FunQuizLabel")); 
            string actualResult = results[0].Text;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        //Test to check if score is being updated on the Quiz Page when the correct option is selected
        [Test]
        public void Test2_CorrectOptionSelected()
        {
            //Arrange
           
            app.Tap("StartButton");
            string expectedScore = "1";

            //Act
            app.Tap("OptionOne");
            AppResult[] results = app.WaitForElement(v => v.Marked("Score"));
            string actualResult = results[0].Text;

            //Assert
            Assert.AreEqual(expectedScore, actualResult);
        }

        //Test to ensure score does not increase when incorrect option is selected
        [Test]
        public void Test3_IncorrectOptionSelected()
        {
            //Arrange
          
            app.Tap("StartButton");
            string expectedScore = "0";

            //Act
            app.Tap("OptionTwo");
            AppResult[] results = app.WaitForElement(v => v.Marked("Score"));
            string actualResult = results[0].Text;

            //Assert
            Assert.AreEqual(expectedScore, actualResult);
        }

        //Test to check Last Page is displayed properly
        [Test]
        public void Test4_DisplayLastPageCorrectly()
        {
            // Arrange 
            NavigateToLastPage();
            string expectedResult = "Quiz compeleted !";

            //Act
            
            AppResult[] results = app.WaitForElement(c => c.Marked("LastPageText"));
            string actualResult = results[0].Text;

            //Assert
           Assert.AreEqual(expectedResult, actualResult);

        }

        // Test to check if final score is update correctly
        [Test]
        public void Test5_FinalScoreUpdated()
        {
            // Arrange 
            NavigateToLastPage();

            // No previous High Score so current score is highest score
            string expectedResult = "Your score : 3"; 

            //Act
            AppResult[] results = app.WaitForElement(c => c.Marked("FinalScore"));
            string actualResult = results[0].Text;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /*Test to check if highest score is updated correctly*/
        [Test]
        public void Test6_HighestScoreUpdated()
        {
            // Arrange 
            NavigateToLastPage();
            string expectedResult = "Highest Score : 3"; 

            //Act
            AppResult[] results = app.WaitForElement(c => c.Marked("HighestScore"));
            string actualResult = results[0].Text;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        /* Test to check if Play Again button works and loads the Quiz Page
         with options*/
        [Test]
        public void Test7_PlayAgainButtonClicked()
        {
            // Arrange 
            NavigateToLastPage();
            
            //Act
            app.Tap("PlayAgain_Button");
            AppResult[] results = app.WaitForElement(c => c.Marked("Question"));
            string QuizQuestion = results[0].Text;

            //Assert
            Assert.IsNotNull(QuizQuestion);
        }





        //Method to Navigate to the Last Page 
        public void NavigateToLastPage()
        {
            app.Tap("StartButton"); /// Click 'START' button on Main Page

            /* On the Quiz page, select 'option 3' for each question and clicking 'OK'
            on the dialogue box to navigate to next question until the last page is reached*/
            for (int i = 0; i < 8; i++)
            {
                app.Tap("OptionThree"); // Choose the thrid option
                app.Tap("OK"); // Clicking OK on the dialogue box 
            }

        }
    }
}
