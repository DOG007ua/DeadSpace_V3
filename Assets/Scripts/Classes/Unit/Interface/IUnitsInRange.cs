using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IUnitsInRange
{
    float Range { get; }
    List<Unit> ListUnits { get; }
    event Action<Unit> AddUnit;
    event Action<Unit> RemoveUnit;

    void Initialize(float range, TeamUnit filterNeedTeamUnit);
    void SetRange(float value);
    void AddObject(Unit unit);
    void RemoveObject(Unit unit);

}