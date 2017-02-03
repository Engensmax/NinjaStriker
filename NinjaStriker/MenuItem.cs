using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NinjaStriker
{
    public class MenuItem
    {
        [XmlIgnore]
        public string LinkType;
        [XmlIgnore]
        public string LinkID;
        public Image Image;
    }
}
