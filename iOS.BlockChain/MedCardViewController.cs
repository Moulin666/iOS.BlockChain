using Foundation;
using iOS.BlockChain.ServerApi.Map;
using Newtonsoft.Json;
using System;
using System.IO;
using UIKit;

namespace iOS.BlockChain
{
    public partial class MedCardViewController : UIViewController
    {
        public MedCardViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Init
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var userInfoFileName = Path.Combine(documents, "UserInfo.json");
            var medicalsInfoFileName = Path.Combine(documents, "MedicalsInfo.json");

            var user = JsonConvert.DeserializeObject<user>(File.ReadAllText(userInfoFileName));
            var medicals = JsonConvert.DeserializeObject<Medical>(File.ReadAllText(medicalsInfoFileName));

            // Set Up
            GroupBloodText.Text = string.Format("Группа крови: {0}", user.type_of_bloud);
            HashText.Text = string.Format("Hash: {0}", user.Hash);
        }
    }
}