using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Game3Question
{
	[Activity(Label = "مسابقه سه سوالی", Theme = "@style/Theme.AppCompat.Light.DarkActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
       ProgressDialog progress;

        EditText per1;
        EditText per2;
        EditText per3;
        EditText per4;
        EditText per5;
        EditText per6;

        int level = 1;
        int CountQuestion = 10;
        Spinner spinner1;
        Spinner spinner2;

        ApiRepository api = new ApiRepository();
        QuestionRepository db = new QuestionRepository();

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);

           

           TextView Update = FindViewById<TextView>(Resource.Id.textView1);
            Update.Click += Update_Click;

            per1 = FindViewById<EditText>(Resource.Id.txtName1);
            per2 = FindViewById<EditText>(Resource.Id.txtName2);
            per3 = FindViewById<EditText>(Resource.Id.txtName3);
            per4= FindViewById<EditText>(Resource.Id.txtName4);
            per5 = FindViewById<EditText>(Resource.Id.txtName5);
            per6 = FindViewById<EditText>(Resource.Id.txtName6);

            spinner1= FindViewById<Spinner>(Resource.Id.spinner1);
            spinner2 = FindViewById<Spinner>(Resource.Id.spinnerCount);

            Button btnstart= FindViewById<Button>(Resource.Id.btnStart);
            btnstart.Click += Btnstart_Click;

            spinner1.ItemSelected += (s, e) =>
            {
               level = e.Position+1;
            };
            spinner2.ItemSelected += (s, e) =>
            {
                CountQuestion = e.Position + 1;
                switch (e.Position)
                {
                    case 0:
                        CountQuestion = 5;
                        break;
                    case 1:
                        CountQuestion = 10;
                        break;
                    default:
                        CountQuestion = 5;
                        break;
                }
            };
        }

        private void Update_Click(object sender, EventArgs e)
        {
            //var progressDialog = ProgressDialog.Show(this, "Please wait...", "Checking account info...", true);
            //new Thread(new ThreadStart(delegate { RunOnUiThread(() => Toast.MakeText(this, "Toast within progress dialog.", ToastLength.Long).Show());
            //    RunOnUiThread(() => progressDialog.Hide()); })).Start();



        }

        private void Btnstart_Click(object sender, EventArgs e)
        {
            Android.Content.Intent intent = new Intent(this, typeof(QuestionActivity));
            UserParcelable parcelable = new UserParcelable();

            List<Person> list = new List<Person>();

            

            if(!string.IsNullOrEmpty(per1.Text))
            {
                list.Add(new Person() {Name=per1.Text,Score=0,Level=1 });
            }
            if (!string.IsNullOrEmpty(per2.Text))
            {
                list.Add(new Person() { Name = per2.Text, Score = 0, Level = 1 });
            }
            if (!string.IsNullOrEmpty(per3.Text))
            {
                list.Add(new Person() { Name = per3.Text, Score = 0, Level = 1 });
            }
            if (!string.IsNullOrEmpty(per4.Text))
            {
                list.Add(new Person() { Name = per4.Text, Score = 0, Level = 1 });
            }
            if (!string.IsNullOrEmpty(per5.Text))
            {
                list.Add(new Person() { Name = per5.Text, Score = 0, Level = 1 });
            }
            if (!string.IsNullOrEmpty(per6.Text))
            {
                list.Add(new Person() { Name = per6.Text, Score = 0, Level = 1 });
            }


            int i = 0;
            foreach (var item in list)
            {
                intent.PutExtra("per" + i, new UserParcelable() { person = item });
                i++;
            }
            intent.PutExtra("count", list.Count());
            intent.PutExtra("Level", level);
            intent.PutExtra("countQuestin", CountQuestion);
            if (list.Count()<2)
            {
                Toast.MakeText(this, "حداقل نام دو نفر را برای شروع بازی وارد کنید", ToastLength.Long).Show();
            }
            else
            StartActivity(intent);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.ListViewMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.actionRefresh:
                    UpdateQuestion();
                    break;
                
            }
            return base.OnOptionsItemSelected(item);
        }

        public void UpdateQuestion()
        {
            progress = new Android.App.ProgressDialog(this);
            progress.Indeterminate = true;
            progress.SetProgressStyle(Android.App.ProgressDialogStyle.Spinner);
            progress.SetMessage("در حال به روزرسانی سوالات...\nکمی صبر کنید");
            progress.SetCancelable(false);
            progress.Show();

            int count = 0;

            Handler h = new Handler();
            Action myAction = () =>
            {
                int lastId = db.GetLastId();

                var list = api.GetQuestions(lastId);
               
                foreach (var item in list)
                {
                    db.InsertQuestion(item);
                    count++;
                }
                RunOnUiThread(() => progress.Hide());
                Toast.MakeText(this, count.ToString() + " عدد اضافه شد", ToastLength.Long).Show();
            };

            h.PostDelayed(myAction, 1000);
       

      
        }
    }
}

