using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IInputController
{
    void ReactionLeftClick(InfoClick info);
    void ReactionRightClick(InfoClick info);
    InfoClick InfoMousePostition { get; }
    event Action<Unit> eventSelectUnit;
}