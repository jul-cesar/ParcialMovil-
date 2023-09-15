using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ParcialMovil
{
    public partial class App : Application
    {
        public static ObservableCollection<TipsModel> TipsCollection { get; set; } = new ObservableCollection<TipsModel>();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new elementsView());


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
