using Plugin.TextToSpeech;
using ProfilesDemo.Models;
using ProfilesDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProfilesDemo.ViewModels
{
    class DetailViewModel : BaseViewModel
    {
        Profile profile;
        //private string happiness;

        public Command OpenWebsiteCommand { get; set; }
        public Command TextToSpeechCommand { get; set; }
        //public Command GetHappinessCommand { get; set; }

        public Profile Profile { get { return profile; } set { RaiseAndUpdate(ref profile, value); } }
        //public string Happiness { get { return happiness; } set { RaiseAndUpdate(ref happiness, value); } }

        public DetailViewModel(Profile profile)
        {
            Profile = profile;
            //happiness = "";

            OpenWebsiteCommand = new Command(() => OpenWebsite());
            TextToSpeechCommand = new Command(() => TextToSpeech());
            //GetHappinessCommand = new Command(); => GetHappiness());
        }

        /*
        private async void GetHappiness()
        {
            try
            {
                var score = await EmotionService.GetAverageHappinessScoreAsync(profile.Avatar);
                Happiness = EmotionService.GetHappinessMessage(score);
            }
            catch (Exception ex)
            {
                Happiness = ex.Message;
            }
        }
        */
        private void TextToSpeech()
        {
            CrossTextToSpeech.Current.Speak(this.profile.Description);
        }

        private void OpenWebsite()
        {
            if (profile.Website.StartsWith("http"))
                Device.OpenUri(new Uri(profile.Website));
        }

    }
}
