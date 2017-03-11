using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using XFQR.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(QrCodeScanningService))]
namespace XFQR.iOS
{
    public class QrCodeScanningService : IQrCodeScanningService
    {
        public async Task<string> ScanAsync()
        {
            #region �ϥ� ZXing.Mobile �� MobileBarcodeScanner
            // http://stackoverflow.com/questions/34582728/how-to-find-current-uiviewcontroller-in-xamarin

            #region ���o�̤W�h�� UIViewController
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            while (vc.PresentedViewController != null)
            {
                vc = vc.PresentedViewController;
            }

            UIViewController appController = null;
            foreach (var foowindow in UIApplication.SharedApplication.Windows)
            {
                if (foowindow.RootViewController != null)
                {
                    appController = foowindow.RootViewController;
                    break;
                }
            }
            #endregion

            #region QRCode ���y�]�w
            var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
            options.PossibleFormats = new List<ZXing.BarcodeFormat>()
            {
                 ZXing.BarcodeFormat.QR_CODE,
            };
            #endregion

            #region �i�� QRCode ���y
            var scanner = new ZXing.Mobile.MobileBarcodeScanner(vc)
            {
                TopText = "QRCode",
            };
            try
            {
                var scanResults = await scanner.Scan(options, true);
                if (scanner != null)
                {
                    return scanResults.Text;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            #endregion

            #endregion
        }
    }
}