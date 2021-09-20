using System;
using System.Collections.Generic;
using System.Text;

namespace PeoopleAlive
{
    class People
    {
        public List<Data> data { get; set;}

    }
    class Data {
        public int birthYear { get; set; }
        public int deathYear { get; set; }
    }
}
