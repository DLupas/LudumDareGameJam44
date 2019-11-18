using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Offer : MonoBehaviour
{

    public Slider ageOffer;
    public Slider wealthOffer;
    public Slider happinessOffer;
    public Slider IQOffer;
    public Slider EQOffer;
    private string Change1;
    private string Change2;
    private string Change3;
    private string Change4;
    private string Change5;
    public int IQValue;
    public int EQValue;
    public int AgeValue;
    public int WealthValue;
    public int HappinessValue;

    //stores the change in values
    public float IQChange;
    public float EQChange;
    public float ageChange;
    public float wealthChange;
    public float happinessChange;
    public int totalValue;
    public int threshold;

    // Start is called before the first frame update
    IEnumerator Deal()
    {
        yield return new WaitForSeconds(1.0f);

    }
        void Start()
    {
        Text EQAmount = GameObject.Find("EQAmount").GetComponent<Text>();
        Text IQAmount = GameObject.Find("IQAmount").GetComponent<Text>();
        Text AgeAmount = GameObject.Find("AgeAmount").GetComponent<Text>();
        Text WealthAmount = GameObject.Find("WealthAmount").GetComponent<Text>();
        Text HappinessAmount = GameObject.Find("HappinessAmount").GetComponent<Text>();

        EQAmount.text = "0 EQ";
        IQAmount.text = "0 IQ";
        AgeAmount.text = "0 Years";
        WealthAmount.text = "0K Dollars";
        HappinessAmount.text = "0 Happiness";


    }

    // Update is called once per frame
    void Update()
    {
        GameObject system = GameObject.Find("EventSystem");
        EventManager Eventmanager = system.GetComponent<EventManager>();


        //get the active person's stats
        GameObject theScript = GameObject.Find(Eventmanager.currentPersonName);
        CharacterBio stats = theScript.GetComponent<CharacterBio>();

        //EQ
        Text EQAmount = GameObject.Find("EQAmount").GetComponent<Text>();
        if (EQOffer.value > 0)
        {
            Change1 = "Give";
            EQValue = stats.EQValue;
        }
        else if (EQOffer.value < 0)
        {
            Change1 = "Take";
            EQValue = stats.EQValue * 2;
        }
        else
        {
            Change1 = "";
            EQValue = 0;
        }

        EQAmount.text = Change1 + $" {Mathf.Abs((int)EQOffer.value)}" + " EQ";

        //IQ
        Text IQAmount = GameObject.Find("IQAmount").GetComponent<Text>();
        if (IQOffer.value > 0)
        {
            Change2 = "Give";
            print("give");
            IQValue = stats.IQValue;
        }
        else if (IQOffer.value < 0)
        {
            Change2 = "Take";
            print("take");
            IQValue = stats.IQValue * 2;
        }
        else
        {
            Change2 = "";
        }

        IQAmount.text = Change2 + $" {Mathf.Abs((int)IQOffer.value)}" + " IQ";

        //Age
        Text AgeAmount = GameObject.Find("AgeAmount").GetComponent<Text>();
        if (ageOffer.value > 0)
        {
            Change3 = "Give";
            AgeValue = stats.AgeValue;
        }
        else if (ageOffer.value < 0)
        {
            Change3 = "Take";
            AgeValue = stats.AgeValue * 2;
        }
        else
        {
            Change3 = "";
            AgeValue = 0;
        }

        AgeAmount.text = Change3 + $" {Mathf.Abs((int)ageOffer.value)}" + " Years";

        //Wealth
        Text WealthAmount = GameObject.Find("WealthAmount").GetComponent<Text>();
        if (wealthOffer.value > 0)
        {
            Change4 = "Give";
            WealthValue = stats.WealthValue;
        }
        else if (wealthOffer.value < 0)
        {
            Change4 = "Take";
            WealthValue = stats.WealthValue * 2;
        }
        else
        {
            Change4 = "";
            WealthValue = 0;
        }

        WealthAmount.text = Change4 + $" {Mathf.Abs((int)wealthOffer.value)}" + "K Dollars";

        //Happiness
        Text HappinessAmount = GameObject.Find("HappinessAmount").GetComponent<Text>();
        if (happinessOffer.value > 0)
        {
            Change5 = "Give";
            HappinessValue = stats.HappinessValue;
        }
        else if (happinessOffer.value < 0)
        {
            Change5 = "Take";
            HappinessValue = stats.HappinessValue * 2;
        }
        else
        {
            Change5 = "";
            HappinessValue = 0;
        }

        HappinessAmount.text = Change5 + $" {Mathf.Abs((int)happinessOffer.value)}" + " Happiness";
    }
        

    public void Onclick()
    {

        GameObject system = GameObject.Find("EventSystem");
        EventManager Eventmanager = system.GetComponent<EventManager>();
        TextManager textmanager = system.GetComponent<TextManager>();
        DevilBank devilBank = system.GetComponent<DevilBank>();
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();


        totalValue = (EQValue*(int)EQOffer.value  + IQValue*(int)IQOffer.value + AgeValue* (int)ageOffer.value*2 + WealthValue*(int)wealthOffer.value/10 + HappinessValue*(int)happinessOffer.value);

        if (Eventmanager.currentPersonName == "Robber")
        {
            threshold = 100; //robber charges you more
        }
        else
        {
            threshold = 0;
        }


        if (totalValue >= threshold)
        {
            

            devilBank.EQSlider.value -= EQOffer.value;
            devilBank.IQSlider.value -= IQOffer.value;
            devilBank.ageSlider.value -= ageOffer.value;
            devilBank.wealthSlider.value -= wealthOffer.value;
            devilBank.happinessSlider.value -= happinessOffer.value;

            IQChange += IQOffer.value/2;
            EQChange += EQOffer.value/2;
            ageChange += ageOffer.value/2;
            wealthChange += wealthOffer.value/2;
            happinessChange += happinessOffer.value/2;
        }
        else
        {
            if (Eventmanager.currentPersonName == "Robber")
            {
                //if you no-deal a robber, they kill you
                devilBank.ageSlider.value = 0;
                devilBank.lose = true;
            }
            
            print("its not a deal");
            //if no deal, take 10%
            devilBank.EQSlider.value *= 0.9f;
            devilBank.IQSlider.value *= 0.9f;
            devilBank.ageSlider.value *= 0.9f;
            devilBank.wealthSlider.value *= 0.9f;
            devilBank.happinessSlider.value *= 0.9f;
        }

        EQOffer.value = 0;
        IQOffer.value = 0;
        ageOffer.value = 0;
        wealthOffer.value = 0;
        happinessOffer.value = 0;
        Change1 = "";
        Change2 = "";
        Change3 = "";
        Change4 = "";
        Change5 = "";

    }
}
