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
                Title = "Integrate with",
                Message = "Sberbank API"
            };
            alert.AddButton("OK");
            alert.Show();
        }

        partial void AlfabankButton_TouchUpInside(UIButton sender)
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = "Integrate with",
                Message = "Alfabank API"
            };
            alert.AddButton("OK");
            alert.Show();
        }

        partial void EmiasButton_TouchUpInside(UIButton sender)
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = "Integrate with",
                Message = "Emias API"
            };
            alert.AddButton("OK");
            alert.Show();
        }

        partial void UIButton17047_TouchUpInside(UIButton sender)
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = "Integrate with",
                Message = "Invitro API"
            };
            alert.AddButton("OK");
            alert.Show();
        }
    }
}