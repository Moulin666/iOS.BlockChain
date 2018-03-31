using Foundation;
using System;
using System.IO;
using System.Drawing;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.Mobile;
using UIKit;
using iOS.BlockChain.ServerApi.Map;

using static iOS.BlockChain.ServerApi.ServerApi;

namespace iOS.BlockChain
{
    public partial class MainMenuViewController : UIViewController
    {
        public MainMenuViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Send qr code request.
            //var user = FetchObject<UserMap>("asdasd");

            // Handle qr code response

            // begin test str
            string str = "Lucifer Our Lord";
            // end test str

            // qr code generator
            Writer writer = new QRCodeWriter();
            BitMatrix bitMatrix = writer.encode(str, BarcodeFormat.QR_CODE, 340, 300);
            BitmapRenderer bitmapRenderer = new BitmapRenderer();
            UIImage image = bitmapRenderer.Render(bitMatrix, BarcodeFormat.QR_CODE, str);

            // Render image
            QrCodeImage.Image = image;
        }

        partial void LogOutButton_TouchUpInside(UIButton sender)
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = "Log Out",
                Message = "Do you really want to leave?"
            };
            alert.AddButton("Yes");
            alert.AddButton("No");
            alert.Clicked += delegate (object obj, UIButtonEventArgs eventArgs) {
                if (eventArgs.ButtonIndex == 0)
                {
                    var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    var fileName = Path.Combine(documents, "UserInfo.json");

                    File.Delete(fileName);

                    var view = Storyboard.InstantiateViewController("LoginViewController") as UIViewController;
                    var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

                    appDelegate.Window.RootViewController = view;
                }
            };
            alert.Show();
        }
    }
}