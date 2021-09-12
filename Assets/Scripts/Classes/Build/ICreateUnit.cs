using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

interface ICreateUnit
{
    void SpawnUnit(GameObject prefab, float seconds);
}