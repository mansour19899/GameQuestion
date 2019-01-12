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

namespace Game3Question
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
        
        EditText per1;
        EditText per2;
        EditText per3;
        EditText per4;
        EditText per5;
        EditText per6;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);

            per1 = FindViewById<EditText>(Resource.Id.txtName1);
            per2 = FindViewById<EditText>(Resource.Id.txtName2);
            per3 = FindViewById<EditText>(Resource.Id.txtName3);
            per4= FindViewById<EditText>(Resource.Id.txtName4);
            per5 = FindViewById<EditText>(Resource.Id.txtName5);
            per6 = FindViewById<EditText>(Resource.Id.txtName6);

            Button btnstart= FindViewById<Button>(Resource.Id.btnStart);
            btnstart.Click += Btnstart_Click;


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


    }
}

