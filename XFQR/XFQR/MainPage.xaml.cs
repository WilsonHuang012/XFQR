using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFQR
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnbuttonScanClicked(object sender, EventArgs e)
        {
            labelQRCode.Text = "";
            var fooQRCode = await DependencyService.Get<IQrCodeScanningService>().ScanAsync();
            if (string.IsNullOrEmpty(fooQRCode) == false)
            {
                labelQRCode.Text = fooQRCode;
            }
        }
    }
}