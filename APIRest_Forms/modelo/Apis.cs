using System;
using System.Collections.Generic;
using System.Text;

namespace APIRest_Forms.modelo
{
    public class Apis
    {
        public string UrlPost { get; set; }
        public Apis()
        {
            UrlPost = "https://jsonplaceholder.typicode.com/posts";
        }
    }
}

