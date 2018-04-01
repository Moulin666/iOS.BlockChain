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
                //var userMap = JsonConvert.DeserializeObject<UserMap>(info);

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

            LoginAsync();
        }

        partial void QrCodeLoginButton_TouchUpInside(UIButton sender)
        {
            QrCodeLoginAsync();
        }

        private async void LoginAsync()
        {
            // Send login request.
            string url = string.Format("");
            //var user = await FetchObject<User>(url);

            // Handle login response
            // check response code

            var user = new User();
            // Save data
            string jsonUser = JsonConvert.SerializeObject(user);

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fileName = Path.Combine(documents, "UserInfo.json");

            File.WriteAllText(fileName, jsonUser);

            // Change view
            var tabBar = Storyboard.InstantiateViewController("MainTabBar") as UITabBarController;
            var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

            appDelegate.Window.RootViewController = tabBar;
        }

        private async void QrCodeLoginAsync()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();

            if (result == null)
                return;

            // Send login request.
            string url = string.Format("");
            //var user = await FetchObject<User>(url);

            // Handle login response
            // check response code

            // Save data
            var user = new User();
            string jsonUser = JsonConvert.SerializeObject(user);

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fileName = Path.Combine(documents, "UserInfo.json");

            File.WriteAllText(fileName, jsonUser);

            // Change view
            var tabBar = Storyboard.InstantiateViewController("MainTabBar") as UITabBarController;
            var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

            appDelegate.Window.RootViewController = tabBar;
        }
    }
}

