using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParcialMovil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemPage : ContentPage, INotifyPropertyChanged
    {
        public AddItemPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
          
            TipsModel newItem = new TipsModel
            {
                Titulo = TitleEntry.Text,
                Date = DatePicker.Date.ToString("dd/MM/yyyy"),
                Descripcion = DescriptionEditor.Text
            };
            

            App.TipsCollection.Add(newItem);
            Navigation.PopAsync();
            NotifyPropertyChanged();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }



}