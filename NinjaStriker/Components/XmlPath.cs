using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;

namespace NinjaStriker.Components
{
    class XmlPath : ComponentPoolable
    {
        public string xmlPath;

        XmlPath(string xmlPath)
        {
            this.xmlPath = xmlPath;
        }
    }
}
