using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
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
                // Change view
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

            if (LoginInput.Text.Length < 6 || LoginInput.Text.Length > 16)
            {
                ErrorLabel.Text = "Login not valid.";
                return;
            }

            string passwordHash = BitConverter.ToString(SHA256.Create().ComputeHash(
                Encoding.UTF8.GetBytes(PasswordInput.Text))).Replace("-", "");
            
            LoginAsync(LoginInput.Text, passwordHash);
        }

        partial void QrCodeLoginButton_TouchUpInside(UIButton sender)
        {
            QrCodeLoginAsync();
        }

        private async void LoginAsync(string login, string passwordHash)
        {
            // Send login request.
            string methodRequest = "login";
            string url = string.Format("http://blockchain.whisperq.ru/api/{0}?token={1}&login={2}&password={3}",
                                       methodRequest, Configuration.TokenApp, login, passwordHash);

            var response = await FetchObject<response_api>(url);

            // Handle login response
            if (response.request_Info.answer != "OK")
            {
                UIAlertView alert = new UIAlertView()
                {
                    Title = "Server",
                    Message = string.Format("Server response error. {0} : {1}",
                                            response.request_Info.code, response.request_Info.answer)
                };
                alert.AddButton("OK");
                alert.Show();

                return;
            }

            var user = response.send_data.user;
            var medicals = response.send_data.medicals;

            // Save data
            string jsonUser = JsonConvert.SerializeObject(user);
            string jsonMedicals = JsonConvert.SerializeObject(medicals);

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var userInfoFileName = Path.Combine(documents, "UserInfo.json");
            var medicalsInfoFileName = Path.Combine(documents, "MedicalsInfo.json");

            File.WriteAllText(userInfoFileName, jsonUser);
            File.WriteAllText(medicalsInfoFileName, jsonUser);

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

            UIAlertView alert = new UIAlertView()
            {
                Title = "Server",
                Message = string.Format("result = {0}", result)
            };
            alert.AddButton("OK");
            alert.Show();
        }
    }
}

