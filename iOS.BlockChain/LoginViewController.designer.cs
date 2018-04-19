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
    [Register ("LoginViewController")]
    partial class LoginViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ErrorLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LoginButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField LoginInput { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PasswordInput { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton QrCodeLoginButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel QrTestResultLabel { get; set; }

        [Action ("LoginButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void LoginButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("QrCodeLoginButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void QrCodeLoginButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ErrorLabel != null) {
                ErrorLabel.Dispose ();
                ErrorLabel = null;
            }

            if (LoginButton != null) {
                LoginButton.Dispose ();
                LoginButton = null;
            }

            if (LoginInput != null) {
                LoginInput.Dispose ();
                LoginInput = null;
            }

            if (PasswordInput != null) {
                PasswordInput.Dispose ();
                PasswordInput = null;
            }

            if (QrCodeLoginButton != null) {
                QrCodeLoginButton.Dispose ();
                QrCodeLoginButton = null;
            }

            if (QrTestResultLabel != null) {
                QrTestResultLabel.Dispose ();
                QrTestResultLabel = null;
            }
        }
    }
}