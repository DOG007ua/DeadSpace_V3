using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IControlerTarget
{
    Unit Target { get;}
    bool HasTarget { get; }
    void SetTarget(Unit unit);
    event Action<Unit> eventNewTarget;

}