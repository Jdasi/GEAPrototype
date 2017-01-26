using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

    public int hours;
    public int minutesTens;
    public int minutes;
    public Text time;
    public float elapsed;
    // Use this for initialization
    void Start () {
        hours = 7;
        minutesTens = 0;
        minutes = 0;
        displayTime();
        elapsed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        elapsed += (Time.deltaTime);
        if(elapsed >= 30)
        {

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
        }
        displayTime();
    }

    void OnGUi()
    {
    }

    void displayTime()
    {
        time.text = "Time " + hours.ToString() + ":" + minutesTens.ToString() + minutes.ToString() + "am";
    }
}
