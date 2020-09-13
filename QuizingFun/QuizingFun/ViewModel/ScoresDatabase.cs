
using System.Collections.Generic;
using System.IO;


namespace QuizingFun.ViewModel
{
    public class ScoresDatabase
    {
        public static List<string> ScoresList = new List<string>();
        readonly string scoresFilePath = Path.Combine
            (System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), 
            "Scores.txt");

        /*This method is called when Quiz ends and the Last Page is loaded. It basically adds 
         * the latest user score to the Scores.txt file. If the file exists, it just appends 
         the score to the file. If the file does not exist, it creates a file and then appends
         the score to the file.*/
        public void AddScoreToDB(string finalScore)
        {
            //If there is no previous scores file existing
            if (!File.Exists(scoresFilePath))
            {
                using (StreamWriter sw = File.CreateText(scoresFilePath))
                    sw.WriteLine(finalScore);
            }

            /*if scores file already exists , append the new score to the file*/
            else
            {
                using (StreamWriter sw = File.AppendText(scoresFilePath))   
                    sw.WriteLine(finalScore);
            }
            // Update list which contains all the scores of the user
            UpdateScoresList();
        }

        /*This method reads the Scores.txt file containing all the previous scores of the user, 
         * splits it and adds it to a list of string called the ScoresList*/
        private void UpdateScoresList()
        {
            ScoresList = new List<string>();
            using (StreamReader r = File.OpenText(scoresFilePath))
            {
                string score = "";
                while ((score = r.ReadLine()) != null)
                    ScoresList.Add(score);     
            }
        }
    } 
}
