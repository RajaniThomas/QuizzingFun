using QuizingFun.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace QuizingFun.ViewModel
{
    public class QuizPageViewModel
    {
        public string Question { get; set; }
        public string Option_one { get; set; }
        public string Option_two { get; set; }
        public string Option_three { get; set; }
        public string Option_four { get; set; }
        public string CorrectAnswer { get; set; }
        public int QuestionNumber { get; set; }
        public int Score { get; set; }
        public static int currentScore = 0;
        public static int currentQuestionNumber = 0;
        public static List<String[]> myQuestionSet { get; set; }

        public QuizPageViewModel()
        {
            string[] currentQuestion = FetchIndividualQuestion();
            QuestionNumber = currentQuestionNumber;
            Question = (currentQuestionNumber) + (". ") + currentQuestion[0];
            Option_one = currentQuestion[1];
            Option_two = currentQuestion[2];
            Option_three = currentQuestion[3];
            Option_four = currentQuestion[4];
            CorrectAnswer = currentQuestion[5];
            Score = currentScore;
        }

        /*This method is called in MainPage.xaml.cs . It uses the list retrieved
         from the de-serialized Json data and adds it to the myQuestionSet at the 
         start of the application. 'myQuestionSet' is a list of string array of size 6, 
         containing the Quiz question, the four options and the correct answer*/
        public static void PopulateQuestionSet(QuizQuestionList quizQuestionList)
        {
            myQuestionSet = new List<string[]>();
            for (int i = 0; i < quizQuestionList.QuizQuestions.Count; i++)
            {
                var details = quizQuestionList.QuizQuestions[i];
                string[] thisQuestion = new string[6];
                thisQuestion[0] = details.Question;
                thisQuestion[1] = details.Option_1;
                thisQuestion[2] = details.Option_2;
                thisQuestion[3] = details.Option_3;
                thisQuestion[4] = details.Option_4;
                thisQuestion[5] = details.Correct_Answer;

                myQuestionSet.Add(thisQuestion);
            }
        }
        /*This method fetches the individual question corresponding to the question number */
        private string[] FetchIndividualQuestion()
        {
            string[] individualQuestion;
            individualQuestion = myQuestionSet[currentQuestionNumber];
            currentQuestionNumber += 1;
            return individualQuestion;
        }

        /*This method is called by Page1.xaml.cs when an option is clicked by the user. It 
         checks if the option selected is equal to the correct answer. If it is, it updates
         the current score by 1 and returns bool value true. If not, it returns false*/
        public bool AnswerIsCorrect(string selectedAnswer)
        {
            if (selectedAnswer == CorrectAnswer)
            {
                currentScore += 1;
                return true;
            }
            else
                return false;
        }         
    }
}
