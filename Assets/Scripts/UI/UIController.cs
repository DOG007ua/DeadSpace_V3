using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public UISelectUnit uiSelectUnit;
    private IInputController inputController;



    public void Initialize(IInputController inputController)
    {
        uiSelectUnit = GetComponent<UISelectUnit>();
        this.inputController = inputController;
        inputController.eventSelectUnit += uiSelectUnit.SelectUnit;
    }
}
