using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfilesDemo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProfilesDemo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeopleListPage : ContentPage
    {
        PeopleListViewModel vm;

        public PeopleListPage()
        {
            InitializeComponent();

            vm = new PeopleListViewModel();
            vm.Initialize();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}