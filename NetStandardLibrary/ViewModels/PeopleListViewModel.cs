using ProfilesDemo.Models;
using Xamarin.Forms;
using ProfilesDemo.Views;
using System.Collections.Generic;
using ProfilesDemo.Services;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace ProfilesDemo.ViewModels
{
    public class PeopleListViewModel : BaseViewModel
    {
        IList<Profile> profileList = new ObservableCollection<Profile>();
        private bool isBusy = false;

        public IList<Profile> ProfileList
        {
            get { return profileList; }
            set { RaiseAndUpdate(ref profileList, value); }
        }

        public Profile SelectedItem
        {
            set
            {
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(new DetailPage(value));
            }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set { RaiseAndUpdate(ref isBusy, value); }
        }

        public async void Initialize()
        {
            IsBusy = true;
            ProfileList = await AzureDataService.DefaultInstance.GetAllProfilesAsync();
            IsBusy = false;
        }
    }
}
