using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace iOS.BlockChain.ServerApi.Map
{
    [Serializable]
    public class request_info
    {
        public string code;
        public string answer;
    }

    [Serializable]
    public class send_data
    {
        public List<Medical> medicals;
        public List<Contract> contracts;
        public user user;
    }

    [Serializable]
    public class response_api
    {
        public request_info request_Info;
        public send_data send_data;
    }

    public class Medical
    {
        public int medId { get; set; }
        public string diagnosis { get; set; }
        public string diagnosis_fully { get; set; }
        public string first_aid { get; set; }
        public string drugs { get; set; }
        public bool is_important { get; set; }
    }

    public class Contract
    {
        public string contractID;
        public string hash_сustomer;
        public string hash_еxecutor;
        public float order_sum;
        public string condition;
        public string prepaid_expense;
        public bool is_Done;
        public bool is_freze;
    }

    [Serializable]
    public class user
    {
        public int UserId { get; set; }

        [JsonProperty("Login")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Hash { get; set; }
        public string type_of_bloud { get; set; }
        public bool is_donor { get; set; }
        public float balance { get; set; }
        public string token { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }

    [Serializable]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<user> Users { get; set; }

        public Role()
        {
            Users = new List<user>();
        }
    }
}
