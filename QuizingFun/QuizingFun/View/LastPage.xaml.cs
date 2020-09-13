// (c) Copyright Skillage I.T. 
// (c) This file is Skillage I.T. software and is made available under license. 
// (c) This software is developed by: Rajani Thomas 
// (c) Date: 15th May 2020 Time: 13.45 
// (c) File Name: LastPage.xaml.cs Version: 1-0

using QuizingFun.ViewModel;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizingFun.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LastPage : ContentPage
    {
        LastPageViewModel lastPageViewModel;
        public LastPage()
        {
            InitializeComponent();
            lastPageViewModel = new LastPageViewModel();
            BindingContext = lastPageViewModel;
        }

        /*This is the event handler code when the 'Play Again' button is clicked on the Last Page. It shuffles the 
         Question set retrieved from the Json file , resets the current Question number and score to 0 and loads the 
         Page1 again.*/
        private void ReplayButtonClicked(object sender, EventArgs e)
        {
            var random = new Random();
            QuizPageViewModel.myQuestionSet = QuizPageViewModel.myQuestionSet.OrderBy(x => random.Next()).ToList();
            QuizPageViewModel.currentQuestionNumber = 0;
            QuizPageViewModel.currentScore = 0;
            Navigation.PushAsync(new Page1());
        }

        /*This is the event handler code when the 'Exit Fun Quizz' button is clicked. */
        private void ExitButtonClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}