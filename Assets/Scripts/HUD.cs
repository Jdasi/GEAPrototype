using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

    //Timer variables
    public int hours;
    public int minutesTens;
    public int minutes;
    private int timeFrame;
    private string timeAbberivation;
    public float elapsed;
    public float secondsPassed;
    int secondsPerMinute;
    bool displayColon;
    public Text timerText;

    //Life variables
    public GameObject[] livesSprites;
    private playerStats player_stats;

    //Collectible variables
    private Collectible collectible;
    private Text collectiblesText;

    void Start()
    {
        hours = 7;
        minutesTens = 0;
        minutes = 0;
        timeAbberivation = "am";
        timeFrame = 0;
        displayTime();
        elapsed = 0;
        secondsPerMinute = 60;
        displayColon = true;

        player_stats = GameObject.Find("Player").GetComponent<playerStats>();
        collectible = GameObject.Find("Collectible").GetComponent<Collectible>();

        collectiblesText = GameObject.Find("CollectiblesText").GetComponent<Text>();

        updateCountText();
    }
	
	void Update()
    {
        elapsed += (Time.deltaTime);
        secondsPassed += (Time.deltaTime);
        updateTime(); //Updates the time
        displayTime(); //Displays the time
        updateLives(); //Updates the lives
        updateCountText(); //Updates Collectibles
    }

    void updateLives()
    {
    if(livesSprites[player_stats.getLives()].gameObject)
       Destroy(livesSprites[player_stats.getLives()].gameObject);
    }
    void updateTime()
    {
        if (elapsed >= secondsPerMinute)
        {
            displayColon = true;
            minutes++;
            elapsed = 0;
            if (minutes == 10)
            {
                minutes = 0;
                minutesTens++;
                if (minutesTens == 6)
                {
                    minutesTens = 0;
                    hours++;
                    if (hours == 12)
                    {
                        if (timeFrame == 0)
                        {
                            timeAbberivation = "pm";
                            timeFrame = 1;
                            return;
                        }

                        if (timeFrame == 1)
                        {
                            timeAbberivation = "am";
                            timeFrame = 0;
                            return;
                        }
                    }
                    if (hours >= 13)
                        hours = 1;
                }
            }
        }
        if (secondsPassed >= 1)
        {
            secondsPassed = 0;
            switch (displayColon)
            {
                case true:
                    displayColon = false;
                    break;
                case false:
                    displayColon = true;
                    break;
            }
        }
    }

    void displayTime()
    {
        timerText.color = Color.white;

        if (displayColon == true)
        {
            timerText.text = "Time " + hours.ToString() + ":" + minutesTens.ToString() + minutes.ToString() + timeAbberivation;
        }
        else
        { 
            timerText.text = "Time " + hours.ToString() + " " + minutesTens.ToString() + minutes.ToString() + timeAbberivation;
        }
    }

    void updateCountText()
    {
        collectiblesText.color = Color.white;
        collectiblesText.text = "Items collected " + collectiblesToString();
    }

    string collectiblesToString()
    {
        string str = "";

        str += (player_stats.getCollectibles() / 100).ToString();
        str += (player_stats.getCollectibles() / 10).ToString();
        str += (player_stats.getCollectibles() / 1).ToString();

        return str;
    }
}