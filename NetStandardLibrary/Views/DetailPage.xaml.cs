using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfilesDemo.ViewModels;
using ProfilesDemo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProfilesDemo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        DetailViewModel vm;

        public DetailPage(Profile profile)
        {
            InitializeComponent();
            vm = new DetailViewModel(profile);
            BindingContext = vm;
        }
    }
}