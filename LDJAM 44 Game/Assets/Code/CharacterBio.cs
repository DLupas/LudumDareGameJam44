using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class CharacterBio : MonoBehaviour
{
    public EventManager eventManager;
        
    public string Cname;
    public string CAge;
    public string CJob;
    public string CNationality;
    public string CBio;
    public string CGender;
    public int EQValue;
    public int IQValue;
    public int HappinessValue;
    public int AgeValue;
    public int WealthValue;

    void Start()
    {

        TextMeshPro textName = GameObject.Find("Name").GetComponent<TextMeshPro>(); ;
        TextMeshPro textAge = GameObject.Find("Age").GetComponent<TextMeshPro>(); ;
        TextMeshPro textGender = GameObject.Find("Gender").GetComponent<TextMeshPro>(); ;
        TextMeshPro textJob= GameObject.Find("Job").GetComponent<TextMeshPro>(); ;
        TextMeshPro textNationality = GameObject.Find("Nationality").GetComponent<TextMeshPro>(); ;
        TextMeshPro textBio = GameObject.Find("Bio").GetComponent<TextMeshPro>(); ;
        textName.GetComponent<TextMeshPro>().text = "Name: " + Cname;
        textAge.GetComponent<TextMeshPro>().text = "Age: " + CAge;
        textGender.GetComponent<TextMeshPro>().text = "Gender: " + CGender;
        textJob.GetComponent<TextMeshPro>().text = "Job: " + CJob;
        textNationality.GetComponent<TextMeshPro>().text = "Nationality: " + CNationality;
        textBio.GetComponent<TextMeshPro>().text = "Bio: " + CBio;


    }
}
