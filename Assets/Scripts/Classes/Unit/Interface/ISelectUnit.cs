using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ISelectUnit
{
    bool IsSelect { get; set; }
    void Select();
    void UnSelect();
}