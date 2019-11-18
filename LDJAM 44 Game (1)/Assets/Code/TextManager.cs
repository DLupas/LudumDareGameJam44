using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    public static int year;
    private int peopleInAYear;
    public GameObject infoText;
    public GameObject infoText2;
    public GameObject yearText;
    public Text Life;
    public Text Hap;
    public Text EQ;
    public Text IQ;
    public Text Money;

    // Use this for initialization
    void Start()
    {
        year = 1;
        peopleInAYear = Random.Range(2, 5);
    }

    void Death()
    {
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        GameObject people = GameObject.Find("People");
        canvas.enabled = false;
        infoText.SetActive(true);
        people.SetActive(false);

    }
    IEnumerator Info(int time)
    {
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        GameObject people = GameObject.Find("People");
        canvas.enabled = false;
        infoText2.SetActive(true);
        people.SetActive(false);
        yield return new WaitForSeconds(time);
        infoText2.SetActive(false);
        canvas.enabled = true;
        people.SetActive(true);
        infoText2.GetComponent<Text>().text = "";

    }

    // Update is called once per frame
    void Update()
    {
        GameObject system = GameObject.Find("EventSystem");
        EventManager Eventmanager = system.GetComponent<EventManager>();
        Offer offer = system.GetComponent<Offer>();
        DevilBank devilBank = system.GetComponent<DevilBank>();
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        //updates stats
        Money.text = "Money: " + devilBank.wealthSlider.value + "K";
        IQ.text = "IQ: " + devilBank.IQSlider.value;
        EQ.text = "EQ: " + devilBank.EQSlider.value;
        Hap.text = "Happiness: " + devilBank.happinessSlider.value;
        Life.text = "Life: " + devilBank.ageSlider.value;


        //gameover messages
        if (devilBank.wealthSlider.value <= 0)
        {
            Death();
            infoText.GetComponent<Text>().text = "You Went Bankrupt...";
        }
        
        else if (devilBank.ageSlider.value <= 0)
        {
            Death();
            infoText.GetComponent<Text>().text = "You Died...";
        }
        else if (devilBank.IQSlider.value <= 0)
        {
            Death();
            infoText.GetComponent<Text>().text = "Your to stupider to live...";
        }
        else if (devilBank.EQSlider.value <= 0)
        {
            Death();
            infoText.GetComponent<Text>().text = "Everyone Hates You...";
        }
        else if (devilBank.happinessSlider.value <= 0)
        {
            Death();
            infoText.GetComponent<Text>().text = "Now You're Depressed...";
        }
        else if (Eventmanager.people.Count == 0){
            Death();
            infoText.GetComponent<Text>().text = "Good Job you did so well everyone dumb enough to trust you is gone... ";
        }
        if (Eventmanager.yearCounter > peopleInAYear)
        {
            

            int events = Random.Range(0, 4);
            print(events);
            if (events == 0)
            {
                infoText2.GetComponent<Text>().text = "Time Passes... Suprise! God isn't happy with what you're doing. To spite you he steals some of your currency!";
                IEnumerator coroutine1 = Info(4);
                StartCoroutine(coroutine1);
                devilBank.wealthSlider.value -= 50;
                devilBank.ageSlider.value -= 20;
                devilBank.IQSlider.value -= 50;
                devilBank.EQSlider.value -= 50;
                devilBank.happinessSlider.value -= 25;

            }
            else if (events == 1)
            {
                infoText2.GetComponent<Text>().text = "Time Passes... Your clients defaulted on their loans, your going to lose some of your precious currency!";
                IEnumerator coroutine2 = Info(4);
                StartCoroutine(coroutine2);
                //if the clients have been lent something, take it back
                if (offer.IQChange > 0)
                {
                    devilBank.IQSlider.value -= offer.IQChange;
                }
                if (offer.EQChange > 0)
                {
                    devilBank.EQSlider.value -= offer.EQChange;
                }
                if (offer.ageChange > 0)
                {
                    devilBank.ageSlider.value -= offer.ageChange;
                }
                if (offer.wealthChange > 0)
                {
                    devilBank.wealthSlider.value -= offer.wealthChange;
                }
                if (offer.happinessChange > 0)
                {
                    devilBank.happinessSlider.value -= offer.happinessChange;
                }
            }
            else
            {
                infoText2.GetComponent<Text>().text = "Time Passes...";
                IEnumerator coroutine3 = Info(2);
                StartCoroutine(coroutine3);
            }

                
            year += 1;
            
            Eventmanager.yearCounter = 0;
            peopleInAYear = Random.Range(2, 5);
         
        }
        yearText.GetComponent<Text>().text = "Year: " + year;


  

    }
    public void Clicked()
    {
        print("new scene");
        SceneManager.LoadScene(sceneName:"test scene");
    }
}
