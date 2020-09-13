
// (c) Copyright Skillage I.T. 
// (c) This file is Skillage I.T. software and is made available under license. 
// (c) This software is developed by: Rajani Thomas 
// (c) Date: 15th May 2020 Time: 13.45 
// (c) File Name: NetworkCheck.cs Version: 1-0

using Plugin.Connectivity;

namespace QuizingFun.Model
{
    public class NetworkCheck
    {
        public static bool IsInternet()
        {
            if (CrossConnectivity.Current.IsConnected)
                return true;
            else   
                return false;    
        }
    }
}
