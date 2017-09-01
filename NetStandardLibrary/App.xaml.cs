using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProfilesDemo.Services;

using Xamarin.Forms;
using ProfilesDemo.Views;

namespace ProfilesDemo
{
	public partial class App : Application
	{
        public AzureDataService DataService { get; set; }

        public App ()
		{
			InitializeComponent();
            AzureDataService.DefaultInstance.Initialize();
            var content = new PeopleListPage();
            MainPage = new NavigationPage(content);
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
