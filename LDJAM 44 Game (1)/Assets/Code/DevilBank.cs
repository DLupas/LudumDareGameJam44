using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevilBank : MonoBehaviour
{

    //make values and their sliders public
    public int startingAge;
    public int startingWealth;
    public int startingHappiness;
    public int startingIQ;
    public int startingEQ;

    public Slider ageSlider;
    public Slider wealthSlider;
    public Slider happinessSlider;
    public Slider IQSlider;
    public Slider EQSlider;

    public bool lose;

    IEnumerator Deal()
    {
        yield return new WaitForSeconds(1.0f);

    }
    // Start is called before the first frame update
    void Start()
    {
        wealthSlider.value = startingWealth;
        ageSlider.value = startingAge;
        happinessSlider.value = startingHappiness;
        IQSlider.value = startingIQ;
        EQSlider.value = startingEQ;
    }

    // Update is called once per frame
    void Update()
    {

        if (wealthSlider.value <= 0 || ageSlider.value <= 0 || happinessSlider.value <= 0 || IQSlider.value <= 0 || EQSlider.value <= 0)
        {
            lose = true;
            Deal();
        }
    }
}
