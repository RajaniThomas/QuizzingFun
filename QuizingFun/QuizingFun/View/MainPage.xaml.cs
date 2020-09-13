// (c) Copyright Skillage I.T. 
// (c) This file is Skillage I.T. software and is made available under license. 
// (c) This software is developed by: Rajani Thomas 
// (c) Date: 15th May 2020 Time: 13.45 
// (c) File Name: MainPage.xaml.cs Version: 1-0

using Newtonsoft.Json;
using QuizingFun.Model;
using QuizingFun.View;
using QuizingFun.ViewModel;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using Xamarin.Forms;

namespace QuizingFun
{
   
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        QuizQuestionList quizQuestionList = new QuizQuestionList();
        string jsonURI = "https://my-json-server.typicode.com/Rthom82/mockJson/db";

        public MainPage()
        {
            InitializeComponent();
            GetJsonData(); 
        }

        /*When the start button is clicked it loads Page1 which contains the Quiz questions*/
        private async void Start_Button_Clicked(object sender, EventArgs e)
        {
           
            await Navigation.PushAsync(new Page1());
        }

        /*When the main page loads, it calls the GetJsonData() method which is defined. 
         * This method uses the HttpClient.getAsync method to the web API specified in the 
         * URL link to send a GET request. In response, the web API sends a HttpResponseMessage 
         * object. This response contains content which is then de-serialized into a list to get the actual 
         * question and options set which is used to load into the Page1.xaml
         */

        public async void GetJsonData()
        {    
            
        // If device is connected to the Internet
         if (NetworkCheck.IsInternet())
         {
                try
                {
                    HttpClient client = new System.Net.Http.HttpClient();
                    HttpResponseMessage response = await client.GetAsync(jsonURI);

                    // If HTTP response is succesful, seraialize the HTTP content to the the string - JsonString
                    if (response.IsSuccessStatusCode)
                    {
                        string JsonString = await response.Content.ReadAsStringAsync();
                        //Converting JSON array objects into generic list
                        quizQuestionList = JsonConvert.DeserializeObject<QuizQuestionList>(JsonString);
                    }
                }

                catch(Exception ex)
                {
                    Debug.WriteLine("\tERROR {0}", ex.Message);
                }
        }
        else
                //Device is not connected to the internet.
                await DisplayAlert("JSONParsing", "No Network is available.", "Ok");
            
            QuizPageViewModel.PopulateQuestionSet(quizQuestionList);  
        }
    }
}

