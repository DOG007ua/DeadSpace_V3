using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.InputController
{
    interface IInputController
    {
        void ReactionLeftClick(InfoClick info);
        void ReactionRightClick(InfoClick info);
    }
}
