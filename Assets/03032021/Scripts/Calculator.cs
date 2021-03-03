using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to hold the outut
using TMPro;
public class Calculator : MonoBehaviour
{
    public float leftHandSide = 0;
    public float rightHandSide = float.PositiveInfinity;
    // The final value after operator has been applied
    public float calculatedValue = float.PositiveInfinity;

    // The function that is currently being applied the left and right hand side variables.
    [System.NonSerialized] // you don't want tis to reset everytime so you put this here(?)
    public FunctionalButton.Function currentFunction = FunctionalButton.Function.None;

    [SerializeField]
    private TextMeshProUGUI outputDisplay;


    public void Backspace()
    {
        string valueString = GetValueString();

        valueString = valueString.Substring(0, valueString.Length - 1);
        SetValue(valueString);
    }

    public string GetValueString()
    {
        //Get the current float value from the calc and turn it into a string
        float currentFloat = leftHandSide;
        if (currentFunction != FunctionalButton.Function.None)
        {
            // re are currently trying to apply an operatior so modify the second number
            currentFloat = rightHandSide;
        }
        return currentFloat.ToString();
    }

    private void SetValue(string _value)
    {
        //convert the string back into a float
        float currentFloat = float.Parse(_value);

        if (currentFunction != FunctionalButton.Function.None)
        {
            rightHandSide = currentFloat;
        }
        else
        {
            leftHandSide = currentFloat;
        }
       
    }
    public void ClearHistory()
    {
        leftHandSide = 0;
        rightHandSide = float.PositiveInfinity;
        calculatedValue = float.PositiveInfinity;
        currentFunction = FunctionalButton.Function.None;
    }

    public void SetFunction(FunctionalButton.Function _function)
    {
        currentFunction = _function;
        rightHandSide = 0;
    }

    public void SetNumber(int _number)
    {
        if (!float.IsPositiveInfinity(calculatedValue))
        {
            //reset values here
            leftHandSide = calculatedValue;
            rightHandSide = 0;
            calculatedValue = float.PositiveInfinity;

        }

        string lhsString = GetValueString();

        //if the string is already too long ignore
        if (lhsString.Replace(".", "").Length > 6)
            return;

        //add this number's value to the string as text
        lhsString += _number.ToString(); //

        //convert the string back into a float
        SetValue(lhsString);
    }

    public void Calculate()
    {
        switch (currentFunction)
        {
            case FunctionalButton.Function.Modulus:
                calculatedValue = leftHandSide % rightHandSide;
                break;
            case FunctionalButton.Function.Divide:
                calculatedValue = leftHandSide / rightHandSide;
                break;
            case FunctionalButton.Function.Multiply:
                calculatedValue = leftHandSide * rightHandSide;
                break;
            case FunctionalButton.Function.Subtract:
                calculatedValue = leftHandSide - rightHandSide;
                break;
            case FunctionalButton.Function.Add:
                calculatedValue = leftHandSide + rightHandSide;
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        outputDisplay.text = GetOutputDisplay();
    }

    private string GetOutputDisplay()
    {
    // is the right hand side non existant.
        if (float.IsPositiveInfinity(rightHandSide))
        {
            return leftHandSide.ToString();
        }
        //is the calculated value set? -
        else if (float.IsPositiveInfinity(calculatedValue) && !float.IsPositiveInfinity(rightHandSide))
        {
            return rightHandSide.ToString();
        }
        return calculatedValue.ToString();

    }
}
// righthandside refers to right sids of the equation
// same with lefthandside.




