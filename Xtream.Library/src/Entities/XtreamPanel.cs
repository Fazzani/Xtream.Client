using System;
using System.Collections.Generic;
using System.Text;

namespace Xtream.Client
{
    public class XtreamPanel
    {
        public User_Info User_info { get; set; }
        public Server_Info Server_info { get; set; }
        public Categories Categories { get; set; }
        public List<Channels> Available_Channels { get; set; }

        public string GenerateUrlFrom(Channels channel, string protocol = "http", string outputFormat = "ts")
        {
            if (channel == null)
                return string.Empty;

            return $"{protocol}://{Server_info.Url}:{Server_info.Port}/live/{User_info.Username}/{User_info.Password}/{channel.Stream_id}.{outputFormat}";
        }
    }
}
