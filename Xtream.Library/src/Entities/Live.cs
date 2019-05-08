using System;
namespace Xtream.Client
{
    public class Live
    {
        public string Category_id { get; set; }
        public int CategoryId { get { return Convert.ToInt32(Category_id); } }
        public string Category_name { get; set; }
        public int Parent_id { get; set; }
    }
}
