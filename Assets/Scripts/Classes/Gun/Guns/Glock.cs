using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Classes.Gun.Guns
{
    class Glock : Pistols
    {
        public InputPropertyGun InputProperty;
        private void Start()
        {
            Initialize(transform, InputProperty);
        }

        private void Update()
        {
            Execute();
        }
    }
}
