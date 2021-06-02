using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgBot.Models
{
    class GetTgImage
    {

        public class Rootobject
        {
       
            public Result result { get; set; }
        }

        public class Result
        {
            
            public string file_path { get; set; }
        }

    }
}
