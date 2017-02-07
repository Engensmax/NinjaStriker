using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;

namespace NinjaStriker.Components
{
    class Name : ComponentPoolable
    {
        public string name;

        Name(string name)
        {
            this.name = name;
        }
    }
}
