using Foundation;
using System;
using UIKit;

namespace iOS.BlockChain
{
    public partial class ServicesViewController : UIViewController
    {
        public ServicesViewController (IntPtr handle) : base (handle)
        {
        }

        partial void SberbankButton_TouchUpInside(UIButton sender)
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = "Button",
                Message = "Sberbank API"
            };
            alert.AddButton("OK");
            alert.Show();
        }

        partial void AlfabankButton_TouchUpInside(UIButton sender)
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = "Button",
                Message = "Alfabank API"
            };
            alert.AddButton("OK");
            alert.Show();
        }

        partial void EmiasButton_TouchUpInside(UIButton sender)
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = "Button",
                Message = "Emias API"
            };
            alert.AddButton("OK");
            alert.Show();
        }
    }
}