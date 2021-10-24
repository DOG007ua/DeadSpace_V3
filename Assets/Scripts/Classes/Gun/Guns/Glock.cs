using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Classes.Gun.Guns
{
    class Glock : Pistols
    {
        public InputPropertyGun InputProperty = null;
        private void Start()
        {
            Initialize(transform, InputProperty);
            Name = "Glock";
        }

        private void Update()
        {
            Execute();
        }
    }
}
