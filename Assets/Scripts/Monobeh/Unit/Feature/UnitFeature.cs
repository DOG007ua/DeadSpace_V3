using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UnitFeature
{
    private Unit unit;
    public MainFeature Main;
    public GunFeature Gun;

    public UnitFeature(Unit unit)
    {
        this.unit = unit;
        Main = new MainFeature(unit);
        Gun = new GunFeature(unit);
    }
}