
// (c) Copyright Skillage I.T. 
// (c) This file is Skillage I.T. software and is made available under license. 
// (c) This software is developed by: Rajani Thomas 
// (c) Date: 15th May 2020 Time: 13.45 
// (c) File Name: QuizQuestions.cs Version: 1-0

using System.Collections.Generic;

namespace QuizingFun.Model
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public string Option_1 { get; set; }
        public string Option_2 { get; set; }
        public string Option_3 { get; set; }
        public string Option_4 { get; set; }
        public string Correct_Answer { get; set; }
    }

    public class QuizQuestionList
    {
    public List<QuizQuestion> QuizQuestions { get; set; }
    }
}
