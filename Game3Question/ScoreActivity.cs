using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Game3Question
{
    [Activity(Label = "ScoreActivity")]
    public class ScoreActivity : Activity
    {
        TextView txt1;
        TextView txt2;
        TextView txt3;
        TextView txt4;
        TextView txt5;
        TextView txt6;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Scorelayout);

            Color color = new Color(255, 255, 255, 170);

            Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnBack.Click += BtnBack_Click;

            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.ScoreHome);
            linearLayout.SetBackgroundResource(Resource.Raw.Bcar9g4Ri);

            TextView score = FindViewById<TextView>(Resource.Id.txtScore);
            txt1 = FindViewById<TextView>(Resource.Id.txt1);
            txt2 = FindViewById<TextView>(Resource.Id.txt2);
            txt3 = FindViewById<TextView>(Resource.Id.txt3);
            txt4 = FindViewById<TextView>(Resource.Id.txt4);
            txt5 = FindViewById<TextView>(Resource.Id.txt5);
            txt6 = FindViewById<TextView>(Resource.Id.txt6);

            score.SetBackgroundColor(color);

            
            List<TextView> txts = new List<TextView>() {txt1,txt2,txt3,txt4,txt5,txt6 };
            UserParcelable parcelable;
            int i;
            for ( i = 0; i < (int)Intent.GetIntExtra("count", 0); i++)
            {
                 parcelable = (UserParcelable)Intent.GetParcelableExtra("per"+i);
                txts.ElementAt(i).Text=(i+1)+"-"+ parcelable.person.Name+"("+ parcelable.person.Score+")";
                txts.ElementAt(i).SetBackgroundColor(color);

            }
            for (int j = i; j < 6; j++)
            {
                txts.ElementAt(j).Visibility = ViewStates.Invisible;
            }


            // Create your application here
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}