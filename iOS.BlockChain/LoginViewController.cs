using System;
using System.IO;
using System.ComponentModel.DataAnnotations;
using iOS.BlockChain.ServerApi.Map;
using Newtonsoft.Json;
using UIKit;

using static iOS.BlockChain.ServerApi.ServerApi;

namespace iOS.BlockChain
{
    public partial class LoginViewController : UIViewController
    {
        public LoginViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Check login, if we already log in
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fileName = Path.Combine(documents, "UserInfo.json");

            if (File.Exists(fileName))
            {
                var info = File.ReadAllText(fileName);
                var userMap = JsonConvert.DeserializeObject<UserMap>(info);

                var tabBar = Storyboard.InstantiateViewController("MainTabBar") as UITabBarController;
                var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

                appDelegate.Window.RootViewController = tabBar;
            }
        }

        partial void LoginButton_TouchUpInside(UIButton sender)
        {
            // Check validation
            if (PasswordInput.Text.Length < 6 || PasswordInput.Text.Length > 16)
            {
                ErrorLabel.Text = "Password not valid.";
                return;
            }

            var checkMail = new EmailAddressAttribute();
            if (!checkMail.IsValid(EmailInput.Text))
            {
                ErrorLabel.Text = "Email address not valid.";
                return;
            }

            // Send login request.
            var user = FetchObject<UserMap>("asdasd");

            // to do login response
            // Handle login response

            // begin test model
            var testUser = new ServerApi.Map.UserMap();
            testUser.id = 12;
            testUser.email = EmailInput.Text;
            testUser.password = PasswordInput.Text;
            // end test model

            // Save data
            string jsonUser = JsonConvert.SerializeObject(testUser);

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fileName = Path.Combine(documents, "UserInfo.json");

            File.WriteAllText(fileName, jsonUser);

            // Change view
            var tabBar = Storyboard.InstantiateViewController("MainTabBar") as UITabBarController;
            var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

            appDelegate.Window.RootViewController = tabBar;
        }

        partial void QrCodeLoginButton_TouchUpInside(UIButton sender)
        {
            QrTestButtonClickAsync();
        }

        private async void QrTestButtonClickAsync()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();

            if (result != null)
                QrTestResultLabel.Text = result.ToString();
        }
    }
}

