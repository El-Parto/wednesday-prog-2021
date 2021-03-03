using UnityEngine;
using UnityEngine.UI;

//handles anything that isn't a number
[RequireComponent(typeof(Button))]
[AddComponentMenu("UI/Functional Button")]
public class FunctionalButton : MonoBehaviour
{
    public enum Function
    {
        Modulus,
        ClearHistory,
        Clear,
        Delete,
        Divide,
        Multiply,
        Subtract,
        Add,
        Equals,
        Decimal,
        None = -1
    }

    [SerializeField]
    private Function function = Function.Equals;

    private Button button;
    private Calculator calculator;
    // Start is called before the first frame update
    void Start()
    {
        calculator = gameObject.GetComponentInParent<Calculator>();

        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnClickButton); 
    }

    private void OnClickButton()
    {
        switch (function)
        {
            case Function.Equals:
                calculator.Calculate();
                break;
            case Function.ClearHistory:
                calculator.ClearHistory();
                break;
            case Function.Delete:
                calculator.ClearHistory();
                break;
            default:
                calculator.SetFunction(function);
                break;
            

        }
    }
    
}
