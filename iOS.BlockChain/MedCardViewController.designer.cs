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
    [Register ("MedCardViewController")]
    partial class MedCardViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel GroupBloodText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel HashText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem InfoTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (GroupBloodText != null) {
                GroupBloodText.Dispose ();
                GroupBloodText = null;
            }

            if (HashText != null) {
                HashText.Dispose ();
                HashText = null;
            }

            if (InfoTitle != null) {
                InfoTitle.Dispose ();
                InfoTitle = null;
            }
        }
    }
}