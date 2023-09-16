using Plugin.Media.Abstractions;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace ParcialMovil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class editTipPage : ContentPage
    {
        public TipsModel EditTips { get; set; }
        private MediaFile miFoto;
        public editTipPage(TipsModel tips)
        {
            InitializeComponent();
            EditTips = tips;
        }


        private async void Button_Clicked_2(object sender, EventArgs e)
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

                   
                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", ex.Message, "OK");
            }
        }


        private async void Button_Clicked_1(object sender, EventArgs e)
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
        private async void Button_Clicked(object sender, EventArgs e)
        {

            this.EditTips.Titulo = TitleEntry.Text;
            this.EditTips.Date = DatePicker.Date.ToString("dd/MM/yyyy");
            this.EditTips.Descripcion = DescriptionEditor.Text;
            this.EditTips.Foto = miFoto != null ? miFoto.Path : null;
            await Navigation.PushAsync(new elementsView());

        }
    }
}