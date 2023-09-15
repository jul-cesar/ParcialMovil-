using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParcialMovil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsTipPage : ContentPage
    {
        public TipsModel Tips { get; set; }
        public DetailsTipPage(TipsModel tips)
        {
            InitializeComponent();
            this.Tips = tips;    
            this.BindingContext = this; 
        }
    }
}