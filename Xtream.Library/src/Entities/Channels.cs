using System;

namespace Xtream.Client
{
    public class Channels
    {
        public int Num { get; set; }
        public string Name { get; set; }
        public string Stream_type { get; set; }
        public string Type_name { get; set; }
        public string Stream_id { get; set; }
        public int StreamId => Convert.ToInt32(Stream_id);
        public string Stream_icon { get; set; }
        public string Epg_channel_id { get; set; }
        public string Added { get; set; }
        public string Category_name { get; set; }
        public string Category_id { get; set; }
        public int CategoryId => Convert.ToInt32(Category_id);
        public string Series_no { get; set; }
        public string Live { get; set; }

        public MediaType MediaType
        {
            get
            {
                if (string.IsNullOrEmpty(Stream_type))
                    return MediaType.LiveTv;
                switch (Live)
                {
                    case "Live":
                        return MediaType.LiveTv;
                    case "Vod":
                        return MediaType.Video;
                    default:
                        return MediaType.LiveTv;
                }
            }
        }

        public string Container_extension { get; set; }
        public string Custom_sid { get; set; }
        public int Tv_archive { get; set; }
        public string Direct_source { get; set; }
        public int Tv_archive_duration { get; set; }
    }

    public enum MediaType : Byte
    {
        LiveTv = 0,
        Radio,
        /// <summary>
        /// video file
        /// </summary>
        Video,
        /// <summary>
        /// audio file
        /// </summary>
        Audio,
        Other
    }
}
