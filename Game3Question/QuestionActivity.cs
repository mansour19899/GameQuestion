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

namespace Game3Question
{
    [Activity(Label = "QuestionActivity", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class QuestionActivity : Activity
    {
        Button btn;
        TextView txt;
        List<string> Persons;
        List<string> questions;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Questionlayout);
            Persons = new List<string>();
            questions = new List<string>();

            Persons.Add("منصور");
            Persons.Add("علی");
            Persons.Add("محمد");
            Persons.Add("مریم");

            questions.Add("نام سه کشوری که با الف شروع می شود");
            questions.Add("نام سه غذای مورد علاقه ت");
            questions.Add("نام سه تا از شهر های جنوبی ایران");



            btn = FindViewById<Button>(Resource.Id.btnPush);
             txt = FindViewById<TextView>(Resource.Id.txtQuestion);
      
       


            btn.Touch += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Event.Action == MotionEventActions.Down)
                {
                    txt.Text = questions.ElementAt(0);
                }
                else if (e.Event.Action == MotionEventActions.Up)
                {
                    txt.Text = "";

                }
            };




            // Create your application here
        }

   
      


    }
}