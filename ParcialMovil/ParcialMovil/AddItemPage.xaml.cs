using Plugin.Media.Abstractions;
using Plugin.Media;
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
        private MediaFile miFoto; 

        public AddItemPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked1(object sender, EventArgs e)
        {
            try
            {
                miFoto = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                    Name = DateTime.Now.ToString(),
                    Directory = "FotosXamarin",
                    SaveToAlbum = true
                });

                if (miFoto != null)
                {
                    imageCamara.Source = ImageSource.FromStream(() =>
                    {
                        return miFoto.GetStream();
                    });
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }


        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var mediaOptions = new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Small 
                };

                var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

                if (selectedImageFile != null)
                {
                    imageCamara.Source = ImageSource.FromFile(selectedImageFile.Path);
                    miFoto = selectedImageFile;

                    NotifyPropertyChanged();
                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            TipsModel newItem = new TipsModel
            {
                Titulo = TitleEntry.Text,
                Date = DatePicker.Date.ToString("dd/MM/yyyy"),
                Descripcion = DescriptionEditor.Text,
                Foto = miFoto != null ? miFoto.Path : null 
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

