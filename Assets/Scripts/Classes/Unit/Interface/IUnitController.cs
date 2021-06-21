using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IUnitController
{
    void MoveToPosition(Vector3 position);
    void SelectUnit(bool value);
    void SetTarget(Unit target);
    Unit Target { get;}
    Unit Unit { get;}


}