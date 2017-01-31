using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Collectible : MonoBehaviour
{
    private int hundreds, tens, units;
    private Text collectiblesText;

	void Start()
    {
        hundreds = 0;
        tens = 0;
        units = 0;

        collectiblesText = GameObject.Find("CollectiblesText").GetComponent<Text>();
        updateCountText();
	}
	
	void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        units++;

        if (units > 9)
        {
            units = 0;
            tens++;

            if (tens > 9)
            {
                tens = 0;
                hundreds++;
            }
        }

        Destroy(gameObject);
        updateCountText();
    }

    void updateCountText()
    {
        collectiblesText.color = Color.white;
        collectiblesText.text = "Items collected " + hundreds.ToString() + tens.ToString() + units.ToString();
    }
   
}
