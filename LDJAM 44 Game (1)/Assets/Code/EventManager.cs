﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour

{
    public List<GameObject> people;
    public string currentPersonName;
    public int currentPersonNumber = 17;
    public bool firsttime = true;
    public int yearCounter;

    // Start is called before the first frame update
    void Start()
    {
        if (firsttime)
        {
            people[17].SetActive(true);
        }



}

    // Update is called once per frame
    void Update()
    {

    }
    public void Onclick()
    {
        if (firsttime)
        {
            people[17].SetActive(false);
            people.RemoveAt(17);
            firsttime = false;

        }
        GameObject system = GameObject.Find("EventSystem");
        DevilBank devilBank = system.GetComponent<DevilBank>();
        people[currentPersonNumber].SetActive(false);
        people.RemoveAt(currentPersonNumber);
        //if the game isn't over
        if (devilBank.lose != true)
        {
            currentPersonNumber = Random.Range(0, people.Count);
            people[currentPersonNumber].SetActive(true);
            currentPersonName = people[currentPersonNumber].name;
            yearCounter += 1;

        }

    }

}
