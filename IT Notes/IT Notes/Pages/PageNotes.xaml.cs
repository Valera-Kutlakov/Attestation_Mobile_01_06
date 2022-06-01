using IT_Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IT_Notes.Pages
{
    public partial class PageNotes : ContentPage
    {
        public PageNotes()
        {
            InitializeComponent();

            Title = "IT Notes";
        }

        protected override async void OnAppearing()
        {
            colViewNotes.ItemsSource = await App.DataBase.GetNotes();
            base.OnAppearing();
        }

        private async void itemAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageNotesSave(null));
        }

        private async void itemEdit_Clicked(object sender, EventArgs e)
        {
            if (colViewNotes.SelectedItem == null) 
            {
                await DisplayAlert("Внимание", "Выберите заметку для редактирования", "OK");
                return;
            }
            else await Navigation.PushAsync(new PageNotesSave(colViewNotes.SelectedItem as Note));
        }
    }
}