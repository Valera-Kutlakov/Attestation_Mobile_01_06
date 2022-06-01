using IT_Notes.Models;
using IT_Notes.Pages;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IT_Notes
{
    public partial class App : Application
    {
        static NoteDataBase dataBase;
        public static NoteDataBase DataBase
        {
            get
            {
                if (dataBase == null)
                {
                    dataBase = new NoteDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return dataBase;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PageNotes());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
