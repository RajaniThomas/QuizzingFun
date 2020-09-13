// (c) Copyright Skillage I.T. 
// (c) This file is Skillage I.T. software and is made available under license. 
// (c) This software is developed by: Rajani Thomas 
// (c) Date: 15th May 2020 Time: 13.45 
// (c) File Name: Page1.xaml.cs Version: 1-0

using QuizingFun.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizingFun.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        QuizPageViewModel quizPageViewModel;
               
        public Page1()
        {
            InitializeComponent();
            quizPageViewModel = new QuizPageViewModel();
            BindingContext = quizPageViewModel;
        }

        //Event Handler when the first option is clicked
        private void Option1_Clicked(object sender, EventArgs e)
        {
            CheckIfAnswerIsCorrect(sender);
            GoToNextQuestion();
        }
        //Event Handler when the second option is clicked
        private void Option2_Clicked(object sender, EventArgs e)
        {
            CheckIfAnswerIsCorrect(sender);
            GoToNextQuestion();
        }
        //Event Handler when the third option is clicked
        private void Option3_Clicked(object sender, EventArgs e)
        {
            CheckIfAnswerIsCorrect(sender);
            GoToNextQuestion();
        }
        //Event Handler when the fourth option is clicked
        private void Option4_Clicked(object sender, EventArgs e)
        {
            CheckIfAnswerIsCorrect(sender);
            GoToNextQuestion();
        }

        /*This method is called when an option is clicked by the user. It checks extracts the text from the button of the option 
         * selected by the user and compares it with the correct answer*/
        private void CheckIfAnswerIsCorrect(object sender)
        {
            string answerSelected = (sender as Button).Text;
            (sender as Button).IsEnabled = false;
            DisplayMessageforSelectedAnswer(answerSelected);
            (sender as Button).IsEnabled = true;
        }

        /*The selected answer is compared to the actual correct answer from the question set. If the answer is correct, it pops up 
         a dialogue box indicating so, and if the option selected is wrong , it pops up a dialogue box indicating that and also gives 
         the correct answer*/
        private void DisplayMessageforSelectedAnswer(string selectedAnswer)
        {
            if (quizPageViewModel.AnswerIsCorrect(selectedAnswer))
                 DisplayAlert("CORRECT !", "\n YOUR ANSWER : " + selectedAnswer.ToUpper(), "OK");
            else
                 DisplayAlert("WRONG !" , "\n YOURANSWER : " + selectedAnswer.ToUpper() + 
                     "\n\n CORRECT ANSWER : " + quizPageViewModel.CorrectAnswer.ToUpper(), "OK");
        }

        /*This method checks if the number of questions has reached 8. If it is less than 8, it pops up the next question on Page1. 
         * If the current Question number is 8, it navigates to the Last page which displays the overall Quiz Score and also the best 
         * score of all games played by the player.*/
        private void GoToNextQuestion()
        {
            if (quizPageViewModel.QuestionNumber < 8)
                Navigation.PushAsync(new Page1());
            else
                Navigation.PushAsync(new LastPage());  
        }
    }
}