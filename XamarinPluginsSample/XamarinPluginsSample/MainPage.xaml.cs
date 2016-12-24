using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinPluginsSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void TakePic(object sender, EventArgs args)
        {
            //  Inicializa los componentes de la cámara
            await Plugin.Media.CrossMedia.Current.Initialize();

            //  Verificar permisos y disponibilidad de cámara
            if (!Plugin.Media.CrossMedia.Current.IsTakePhotoSupported || !Plugin.Media.CrossMedia.Current.IsCameraAvailable)
                return;

            //  Tomar foto
            var file = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
            {
                SaveToAlbum = true,
                Name = "MyImage.jpg",
            });

            //  Mostrar imagen
            if(file != null)
                MyImage.Source = file.Path;
        }
    }
}
