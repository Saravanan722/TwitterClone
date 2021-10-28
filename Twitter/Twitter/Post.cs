using System;
using System.Collections.Generic;
using System.Text;
using System.Text;
using Newtonsoft.Json;

namespace Twitter
{
    class Post
    {
        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}
