using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private UISelectUnit uiSelectUnit;
    private UIPositionMouse uiPositionMouse;
    private IInputController inputController;

    public void Initialize(IInputController inputController)
    {
        this.inputController = inputController;
        uiSelectUnit = GetComponent<UISelectUnit>();
        uiPositionMouse = GetComponent<UIPositionMouse>();        
        inputController.eventSelectUnit += uiSelectUnit.SelectUnit;
        uiPositionMouse.Initialize(inputController.InfoMousePostition);

    }
}
