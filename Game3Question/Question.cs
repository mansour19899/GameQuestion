using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net;
using SQLite.Net.Attributes;

namespace Game3Question
{
    class Question
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        [MaxLength(500)]
        public string question { get; set; }
        [NotNull]
        public int Level { get; set; }
        [NotNull]
        public int TypeQuestion { get; set; }
        [NotNull]
        public int Count { get; set; }
        [NotNull]
        public int Correct { get; set; }
        [NotNull]
        public int Wrong { get; set; }
        [NotNull]
        public int IdQuestion { get; set; }

    }

    class QuestionRepository
    {
        private string dbPath = "";
        private string dbName = "MyQuestionDb";
        private SQLiteConnection db;

        public QuestionRepository()
        {
            dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            db = new SQLiteConnection(platform, Path.Combine(dbPath, dbName));

            db.CreateTable<Question>();
        }

        public List<Question> GetAllQuestion()
        {
            return db.Table<Question>().ToList();
        }

        public Question GetQuestionById(int QuestionId)
        {
            return db.Table<Question>().SingleOrDefault(f => f.Id == QuestionId);
        }

        public int GetLastId()
        {            
            return db.Table<Question>().Max(p => p.IdQuestion);
        }
        public void InsertQuestion(Question question)
        {
            question.IdQuestion = question.Id;
            db.Insert(question);
        }

        public void UpdateQuestion(Question question)
        {
            db.Update(question);
        }

        public void DeleteQuestion(Question question)
        {
            db.Delete(question);
        }

        public bool HaveAnyQuestion()
        {
            return db.Table<Question>().Any();
        }
    }
}