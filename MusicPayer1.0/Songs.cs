using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPayer1._0
{
    internal class Songs //we crete this new class to store all the data and to clean the code 
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Songs()
        {

        }
        public Songs(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}
