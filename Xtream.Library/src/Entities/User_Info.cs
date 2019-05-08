using System;
using System.Collections.Generic;

namespace Xtream.Client
{
    public class User_Info
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Auth { get; set; }
        public string Status { get; set; }
        public string Exp_date { get; set; }

        public DateTime? ExpirationDate { get { return Exp_date?.UnixTimeStampToDateTime(); } }

        public string Is_trial { get; set; }
        public bool IsTrial { get { return !string.IsNullOrEmpty(Is_trial) && Active_cons.Equals("1"); } }
        public string Active_cons { get; set; }

        public bool Active { get { return !string.IsNullOrEmpty(Active_cons) && Active_cons.Equals("1"); } }

        public string Created_at { get; set; }
        public DateTime? CreatedDate { get { return Created_at?.UnixTimeStampToDateTime(); } }

        public string Max_connections { get; set; }
        public List<string> Allowed_output_formats { get; set; }
    }
}
