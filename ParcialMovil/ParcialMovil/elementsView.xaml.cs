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
        private List<TipsModel> filteredTips;
        private bool isFilterApplied = false;

        public elementsView()
        {
            InitializeComponent();

        }

        private async void agregarTip(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage());

        }


        

        private async void verDetallesTip(object sender, EventArgs e)
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

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = e.NewTextValue;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                isFilterApplied = false;
                cv.ItemsSource = App.TipsCollection;
            }
            else

            {
                isFilterApplied = true;
                filteredTips = App.TipsCollection.Where(tip => tip.Titulo.ToLower().Contains(searchText)).ToList();
                cv.ItemsSource = filteredTips;
              
            }
        }

        private void borrarTip(object sender, EventArgs e)
        {


            var button = (Button)sender;
            var item = (TipsModel)button.BindingContext;
            App.TipsCollection.Remove(item);

            cv.ItemsSource = App.TipsCollection;

            if (isFilterApplied)
            {
               
                filteredTips.Remove(item);
                cv.ItemsSource = filteredTips;
                NotifyPropertyChanged();
            }

        }




    }

}
