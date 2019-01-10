using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
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
        int j = 0;

        private MediaPlayer _player;
        private Timer timer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Questionlayout);
            Persons = new List<Person>();
            questions = new List<string>();

            Persons.Add(new Person() { Id = 0, Name = "احمد", Score = 0 });
            Persons.Add(new Person() { Id = 0, Name = "علی", Score = 0 });
            Persons.Add(new Person() { Id = 0, Name = "محمد", Score = 0 });
            Persons.Add(new Person() { Id = 0, Name = "مریم", Score = 0 });

            j = i % 4;
            _player = MediaPlayer.Create(this, Resource.Raw.soundEnd1);


            LinearLayout home = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            home.SetBackgroundResource(Resource.Raw.Bcar9g4Ri);



            timer = new Timer();
            timer.Interval = 5000;
            timer.Elapsed += Timer_Elapsed;


            questions.Add("نام سه کشوری که با الف شروع می شود");
            questions.Add("نام سه غذای مورد علاقه ت");
            questions.Add("نام سه تا از شهر های جنوبی ایران");
            questions.Add("نام سه تا از کشورهای اروپا");
            questions.Add("نام سه کشوری که با الف شروع می شود");
            questions.Add("نام سه غذای مورد علاقه ت");
            questions.Add("نام سه تا از شهر های جنوبی ایران");
            questions.Add("نام سه تا از کشورهای اروپا");
            questions.Add("نام سه کشوری که با الف شروع می شود");
            questions.Add("نام سه غذای مورد علاقه ت");
            questions.Add("نام سه تا از شهر های جنوبی ایران");
            questions.Add("نام سه تا از کشورهای اروپا");
            questions.Add("نام سه کشوری که با الف شروع می شود");
            questions.Add("نام سه غذای مورد علاقه ت");
            questions.Add("نام سه تا از شهر های جنوبی ایران");
            questions.Add("نام سه تا از کشورهای اروپا");
            questions.Add("نام سه کشوری که با الف شروع می شود");
            questions.Add("نام سه غذای مورد علاقه ت");
            questions.Add("نام سه تا از شهر های جنوبی ایران");
            questions.Add("نام سه تا از کشورهای اروپا");
            questions.Add("نام سه کشوری که با الف شروع می شود");
            questions.Add("نام سه غذای مورد علاقه ت");
            questions.Add("نام سه تا از شهر های جنوبی ایران");
            questions.Add("نام سه تا از کشورهای اروپا");



            btnPush = FindViewById<Button>(Resource.Id.btnPush);
            btnWrong = FindViewById<Button>(Resource.Id.btnWrong);
            btnCorrect = FindViewById<Button>(Resource.Id.btnCorrect);

            txtQuestion = FindViewById<TextView>(Resource.Id.txtQuestion);
            txtName = FindViewById<TextView>(Resource.Id.txtPersonName);

            txtName.Text = Persons.ElementAt(i).Name + "    (0)";
            txtQuestion.Text = "";

            btnCorrect.Visibility = ViewStates.Invisible;
            btnWrong.Visibility = ViewStates.Invisible;

            btnCorrect.Click += BtnCorrect_Click;
            btnWrong.Click += BtnWrong_Click;


            Color color = new Color(255, 255, 255, 170);
            txtName.SetBackgroundColor(color);

            btnPush.Touch += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Event.Action == MotionEventActions.Down)
                {
                    txtQuestion.Text = questions.ElementAt(i);
                    txtQuestion.SetBackgroundColor(color);
                }
                else if (e.Event.Action == MotionEventActions.Up)
                {
                    txtQuestion.Text = "";
                    btnCorrect.Visibility = ViewStates.Visible;
                    btnWrong.Visibility = ViewStates.Visible;
                    btnPush.Visibility = ViewStates.Invisible;
                    timer.Start();
                    _player = MediaPlayer.Create(this, Resource.Raw.soundEnd1);
                    //  _player.Start();
                    txtQuestion.SetBackgroundColor(new Color(255, 255, 255, 0));
                }
            };


            txtName.Click += TxtName_Click;



            // Create your application here
        }

        private void TxtName_Click(object sender, EventArgs e)
        {
            Android.Content.Intent intent = new Intent(this, typeof(ScoreActivity));
            UserParcelable parcelable = new UserParcelable();

            parcelable.person = Persons.ElementAt(0);
            int i = 0;
            foreach (var item in Persons.OrderByDescending(p=>p.Score))
            {
                intent.PutExtra("per"+i, new UserParcelable() { person = item });
                i++;
            }
            intent.PutExtra("count", Persons.Count());

            StartActivity(intent);
    }

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        RunOnUiThread(() => txtQuestion.Text = "زمان تمام شد");
        timer.Stop();

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
        _player.Stop();
        timer.Stop();
        txtQuestion.Text = "";
        btnCorrect.Visibility = ViewStates.Invisible;
        btnWrong.Visibility = ViewStates.Invisible;
        btnPush.Visibility = ViewStates.Visible;
        if (isCorrect)
            Persons.ElementAt(j).Score = Persons.ElementAt(j).Score + 1;
        i++;
        j = i % 4;
        txtName.Text = Persons.ElementAt(j).Name + "    (" + Persons.ElementAt(j).Score + ")";
    }

    protected override void OnDestroy()
    {
        _player.Stop();
        _player = null;
        base.OnDestroy();
    }
}
}





//https://github.com/damienaicheh/XamarinAndroidParcelable/tree/final/Droid