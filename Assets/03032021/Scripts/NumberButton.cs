using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//whenever you click. applies the number

[RequireComponent(typeof(Button))] //any button components cannot be removed, it'll uto add a button if there isn't one.
[AddComponentMenu("UI/Number Button")]
public class NumberButton : MonoBehaviour
{
    [SerializeField, Range(0, 9)]
    private int number = 0;


    private TextMeshProUGUI buttonText;

    private Button button;

    private Calculator calculator;

    // Start is called before the first frame update
    void Start()
    {
        calculator = gameObject.GetComponentInParent<Calculator>(); 


        buttonText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = number.ToString();

        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);

    }

    // Update is called once per frame
    private void OnClickButton()
    {
        calculator.SetNumber(number);
    }
}