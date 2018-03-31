using System;

namespace iOS.BlockChain.ServerApi.Map
{
    [Serializable]
    public class UserMap
    {
        public int id { get; set; }

        public string email { get; set; }
        public string password { get; set; }
    }
}
