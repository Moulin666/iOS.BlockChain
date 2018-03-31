// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iOS.BlockChain
{
    [Register ("ServicesViewController")]
    partial class ServicesViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AlfabankButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton EmiasButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem InfoTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SberbankButton { get; set; }

        [Action ("AlfabankButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AlfabankButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("EmiasButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void EmiasButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("SberbankButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SberbankButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AlfabankButton != null) {
                AlfabankButton.Dispose ();
                AlfabankButton = null;
            }

            if (EmiasButton != null) {
                EmiasButton.Dispose ();
                EmiasButton = null;
            }

            if (InfoTitle != null) {
                InfoTitle.Dispose ();
                InfoTitle = null;
            }

            if (SberbankButton != null) {
                SberbankButton.Dispose ();
                SberbankButton = null;
            }
        }
    }
}