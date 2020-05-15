using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace tcc_qrcode_flashlight_poc {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage {

        private bool isLightOn;
        public MainPage() {
            InitializeComponent();
            isLightOn = false;
        }

        async void Handle_Clicked(object sender, System.EventArgs e) {
            try {
                isLightOn = !isLightOn;
                if (isLightOn) {
                    await Flashlight.TurnOnAsync();
                } else {
                    await Flashlight.TurnOffAsync();
                }
                string message = isLightOn ? "Luz acesa" : "Luz apagada";
                await DisplayAlert("OK", $"{message} com sucesso.", "OK");
            } catch (FeatureNotSupportedException fnsEx) {
                await DisplayAlert("Erro", fnsEx.Message, "OK");
            } catch (PermissionException pEx) {
                await DisplayAlert("Erro", pEx.Message, "OK");
            } catch (Exception ex) {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
