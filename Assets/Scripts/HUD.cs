using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

    public int hours;
    public int minutesTens;
    public int minutes;
    private int timeFrame;
    public Text time;
    private string timeAbberivation;
    public float elapsed;

    public GameObject[] livesSprites;
    public int lives;

    // Use this for initialization
    void Start () {
        lives = 7;
        hours = 7;
        minutesTens = 0;
        minutes = 0;
        timeAbberivation = "am";
        timeFrame = 0;
        displayTime();
        elapsed = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if(livesSprites[lives] != null)
        {
            Destroy(livesSprites[lives]);
        }

        elapsed += (Time.deltaTime);
        if(elapsed >= 3)
        {
            if (lives > 0)
                lives--;

                minutes++;
                elapsed = 0;
            if (minutes == 10)
            {
                minutes = 0;
                minutesTens++;
            }
            if(minutesTens == 6)
            {
                minutesTens = 0;
                hours++;
            }
            if(hours >= 13)
            {
                hours = 1;
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
        }
        displayTime();
    }

    void OnGUi()
    {
    }

    void displayTime()
    {
        time.text = "Time " + hours.ToString() + ":" + minutesTens.ToString() + minutes.ToString() + timeAbberivation;
    }
}
