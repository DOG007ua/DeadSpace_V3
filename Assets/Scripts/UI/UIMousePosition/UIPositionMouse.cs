using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

class UIPositionMouse : MonoBehaviour
{
    [SerializeField] private RectTransform panelTransform;
    [SerializeField] private Image panelImage;
    [SerializeField] private TextMeshProUGUI nameUnit;
    [SerializeField] private TextMeshProUGUI hp;
    private Dictionary<TeamUnit, Color> colors = new Dictionary<TeamUnit, Color>
    {
        {TeamUnit.Blue, new Color(0, 0, 1, 0.4f) },
        {TeamUnit.Red, new Color(1, 0, 0, 0.4f) }
    };
    private bool isVisible;
    private InfoClick infoMouse;
    private Vector2 sizePanel;

    public void Initialize(InfoClick infoMousePosition)
    {
        infoMouse = infoMousePosition;
        sizePanel = new Vector2(panelTransform.rect.width, panelTransform.rect.height);
    }

    private void Update()
    {
        if (infoMouse == null) return;

        NeedVissible();
        PositionPanel();
        TextInfo();
    }

    private void PositionPanel()
    {
        if (!isVisible) return;

        var positionGOScreen = Camera.main.WorldToScreenPoint(infoMouse.GameObjectClick.transform.position);
        panelTransform.SetPositionX(positionGOScreen.x);
        panelTransform.SetPositionY(positionGOScreen.y + sizePanel.y);
    }

    private void TextInfo()
    {
        if (!isVisible) return;

        nameUnit.text = infoMouse.Unit.UnitFeature.Main.Name;
        hp.text = infoMouse.Unit.UnitFeature.Main.HP.ToString();
    }

    private void NeedVissible()
    {
        if (infoMouse.Unit != null)
            Visible(true);
        else
            Visible(false);
    }

    private void Visible(bool value)
    {
        if (value == isVisible) return;

        isVisible = value;
        panelTransform.gameObject.SetActive(value);
        if(value)
        {
            PaintPanel();
        }
    }

    private void PaintPanel()
    {
        panelImage.color = colors[infoMouse.Unit.Team];
       /* switch (infoMouse.Unit.Team)
        {
            case TeamUnit.Blue:
                panelImage.color = li
                break;
            case TeamUnit.Red:
                break;
        }*/
    }

}