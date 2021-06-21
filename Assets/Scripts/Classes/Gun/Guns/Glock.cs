using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Classes.Gun.Guns
{
    class Glock : Pistols
    {
        private void Start()
        {
            Initialize(transform);
        }

        private void Update()
        {
            Execute();
        }
    }
}
