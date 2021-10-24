using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private IInputController inputController;
    public InputClick inputClick;

    void Start()
    {
        Initialized();
        Subscription();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialized()
    {
        inputController = new InputController();
    }

    private void Subscription()
    {
        inputClick.EventClickLeft += inputController.ReactionLeftClick;
        inputClick.EventClickRight += inputController.ReactionRightClick;
    }
}
