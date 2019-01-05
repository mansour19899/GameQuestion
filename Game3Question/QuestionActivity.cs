﻿using System;
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
        Button btnPush;
        Button btnWrong;
        Button btnCorrect;

        TextView txtQuestion;
        TextView txtName;

        List<Person> Persons;
        List<string> questions;

        int i = 0;
        int j =0;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Questionlayout);
            Persons = new List<Person>();
            questions = new List<string>();

            Persons.Add(new Person() {Id=0,Name="منصور",Score=0 });
            Persons.Add(new Person() { Id = 0, Name = "علی", Score = 0 });
            //Persons.Add(new Person() { Id = 0, Name = "محمد", Score = 0 });
            //Persons.Add(new Person() { Id = 0, Name = "مریم", Score = 0 });

            j = i % 2;


            questions.Add("نام سه کشوری که با الف شروع می شود");
            questions.Add("نام سه غذای مورد علاقه ت");
            questions.Add("نام سه تا از شهر های جنوبی ایران");
            questions.Add("نام سه تا از کشورهای اروپا");



            btnPush = FindViewById<Button>(Resource.Id.btnPush);
            btnWrong = FindViewById<Button>(Resource.Id.btnWrong);
            btnCorrect = FindViewById<Button>(Resource.Id.btnCorrect);

            txtQuestion = FindViewById<TextView>(Resource.Id.txtQuestion);
            txtName = FindViewById<TextView>(Resource.Id.txtPersonName);

            txtName.Text = Persons.ElementAt(i).Name+"    (0)";


            btnCorrect.Visibility = ViewStates.Invisible;
            btnWrong.Visibility = ViewStates.Invisible;

            btnCorrect.Click += BtnCorrect_Click;
            btnWrong.Click += BtnWrong_Click;
      
       


            btnPush.Touch += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Event.Action == MotionEventActions.Down)
                {
                    txtQuestion.Text = questions.ElementAt(i);
                }
                else if (e.Event.Action == MotionEventActions.Up)
                {
                    txtQuestion.Text = "";
                    btnCorrect.Visibility = ViewStates.Visible;
                    btnWrong.Visibility = ViewStates.Visible;
                    btnPush.Visibility = ViewStates.Invisible;

                }
            };




            // Create your application here
        }

        private void BtnWrong_Click(object sender, EventArgs e)
        {
            SetAnser(false);
        }

        private void BtnCorrect_Click(object sender, EventArgs e)
        {
            SetAnser(true);
        }

        public void SetAnser(bool isCorrect)
        {
           
            btnCorrect.Visibility = ViewStates.Invisible;
            btnWrong.Visibility = ViewStates.Invisible;
            btnPush.Visibility = ViewStates.Visible;
            if (isCorrect)
                Persons.ElementAt(j).Score = Persons.ElementAt(j).Score + 1;
            i++;
            j = i % 2;
            txtName.Text = Persons.ElementAt(j).Name+"    ("+ Persons.ElementAt(j).Score+")";
        }
    }
}