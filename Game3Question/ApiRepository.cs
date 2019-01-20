using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using Newtonsoft.Json;

namespace Game3Question
{
    class ApiRepository
    {
        public static string ApiUrl = "http://192.168.56.1:7574";
        public List<Question> GetQuestions(int id)
        {
           
            using (var client = new HttpClient())
            {
                var resualt = client.GetStringAsync(ApiUrl + "/questions/" + id).Result;
                var people = JsonConvert.DeserializeObject<List<Question>>(resualt);
                return people;
            }


        }
    }
}