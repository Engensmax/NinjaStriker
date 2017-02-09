using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
namespace NinjaStriker.Components
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Health : ComponentPoolable
    {
        public float maxHealth {get; private set; }
        public float currentHealth;
        public Image healthBar;
        public Image healthBarFilling;

        public Health()
        {
            this.healthBar = new XmlManager<Image>().Load("Load/HealthBar.xml");
            this.healthBar.LoadContent();
            this.healthBarFilling = new XmlManager<Image>().Load("Load/HealthBarFilling.xml");
            this.healthBarFilling.LoadContent();
            this.maxHealth = 10;
            this.currentHealth = this.maxHealth;
        }
        //obligatory for poolable Components
        public void Cleanup()
        {
            this.healthBar.UnloadContent();
            this.healthBarFilling.UnloadContent();
        }
    }
}
