using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Collectibles : MonoBehaviour {
    // Use this for initialization

    private int collectibles, hundreds, tens, units;
    public Text collectiblesText;
	void Start () {
        collectibles = 0;
        hundreds = 0;
        tens = 0;
        units = 0;
        updateCountText();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (gameObject)
            {
                Destroy(gameObject);
                collectibles++;
                units++;
                if (units > 9)
                {
                    units = 0;
                    tens++;
                    if(tens > 9)
                    {
                        tens = 0;
                        hundreds++;
                    }
                }
                updateCountText();
            }
        }
    }

    void updateCountText()
    {
        collectiblesText.color = Color.white;
        collectiblesText.text = "Items collected " + hundreds.ToString() + tens.ToString() + units.ToString();
    }
   
}
