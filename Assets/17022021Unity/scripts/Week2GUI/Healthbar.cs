using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // using means accessing this part of the code.
using TMPro;
[ExecuteInEditMode] //allows you to edit in the editor without having to press play all the time
//needs to keep track of the slider's value
//needs to transition the colour from one to the other based on how much health
//and edit the text while doing this.

public class Healthbar : MonoBehaviour
{
    /* 4 variables */
    [SerializeField]
    private Color fullColor = Color.green;
    [SerializeField]
    private Color emptyColor = Color.red;
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private Image healthDisplay;
    /*
    public void Damage(float _amount)
    {
        healthSlider.value -= _amount;
    }
     */
    
    
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = healthSlider.maxValue; //leaves the default at max value. healthslider being called out as a value
    }

    // Update is called once per frame
    void Update()
    {
        /*interpolation exists in games as well as pretty much any animation that one encounters.
        linear interpolation usually refered to lerp, one value to another.
        Current / Max is an equation to see crrent health*/
        healthDisplay.color = Color.Lerp(emptyColor, fullColor, Mathf.Clamp01(healthSlider.value / healthSlider.maxValue)); //this line will give you the exact amount between a and b 

        healthText.text = healthSlider.value.ToString("0.0") + "%"; // 0.0 puts it to 1 decimal 
    }
}
