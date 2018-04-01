using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace iOS.BlockChain.ServerApi.Map
{
    [Serializable]
    public class User
    {
        public int UserId { get; set; }

        [JsonProperty("Login")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Hash { get; set; }
        public string type_of_bloud { get; set; }
        public bool is_donor { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }

    [Serializable]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }

        public Role()
        {
            Users = new List<User>();
        }
    }
}
