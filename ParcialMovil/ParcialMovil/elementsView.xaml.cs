using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;




namespace ParcialMovil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class elementsView : ContentPage, INotifyPropertyChanged
    {
        public elementsView()
        {
            InitializeComponent();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage());

        }


        private void Button_Clicked_2(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (TipsModel)button.BindingContext;
            App.TipsCollection.Remove(item);

        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {


            var button = (Button)sender;
            var itemSelected = (TipsModel)button.BindingContext;


            if (itemSelected != null)
            {
                await Navigation.PushAsync(new DetailsTipPage(itemSelected));
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}