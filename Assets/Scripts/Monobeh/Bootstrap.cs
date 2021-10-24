using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private UIController uiController = null;
    public InputClick inputClick;
    private IInputController inputController;    
    

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
        uiController.Initialize(inputController);
    }

    private void Subscription()
    {
        inputClick.EventClickLeft += inputController.ReactionLeftClick;
        inputClick.EventClickRight += inputController.ReactionRightClick;
    }
}
