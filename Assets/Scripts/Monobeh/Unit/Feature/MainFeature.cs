﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MainFeature
{
    private Unit unit;
   
    public MainFeature(Unit unit)
    {
        this.unit = unit;
    }

    public float HP => unit.HP;
    public string Name => unit.Name;
}