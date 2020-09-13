// (c) Copyright Skillage I.T. 
// (c) This file is Skillage I.T. software and is made available under license. 
// (c) This software is developed by: Rajani Thomas 
// (c) Date: 15th May 2020 Time: 13.45 
// (c) File Name: LastPageViewModel.cs Version: 1-0


using System;

namespace QuizingFun.ViewModel
{
     class LastPageViewModel
    {        
        public string FinalResult { get; set; }
        public string ScoreMessage { get; set; }
        public string HighestScore { get; set; }

        QuizPageViewModel qvm = new QuizPageViewModel();
        ScoresDatabase scoresDatabase;

        public LastPageViewModel()
        {
            scoresDatabase = new ScoresDatabase();
            scoresDatabase.AddScoreToDB(qvm.Score.ToString());
            
            FinalResult = GetFinalScore();
            HighestScore = GetHighScore();
            ScoreMessage = GetScoreMessage();
        }

        /*This method returns a string value in the format Your Score : + Actual Score.*/
        private string GetFinalScore()
        {
            string finalScore = "Your score : " + qvm.Score.ToString() ;
            return finalScore;
        }


        /*This method loops through the ScoresList retrieved from the Scores file and 
         checks for the highest score. It returns the value of the highest score */
        private string GetHighScore()
        {
            int highScore = 0;         

            for (int i =0; i< ScoresDatabase.ScoresList.Count; i++)
            {
                int thisScore = Convert.ToInt32(ScoresDatabase.ScoresList[i]);
                if (highScore < thisScore)
                    highScore = thisScore;
            }

            string retStrng = "Highest Score : " + highScore; 
            return retStrng;
        }

        /*This method checks for the range of the score. There are 3 categories which are 
         * ; less than 3, 3 to 4 or greater than 4. It returns a string value which is a 
         * score message based on the range of the user's score.*/
            private string GetScoreMessage()
        {
            string scoreMessage = "";
            if (qvm.Score > 4)
                scoreMessage = "Well Done !!!";
            else if (qvm.Score>2  && qvm.Score < 5)
                scoreMessage = "Nice ...You did well ! ";
            else if (qvm.Score < 3 )
                scoreMessage = "Hmmm... Better luck next time ! ";
            return scoreMessage;
        }
    }
}
