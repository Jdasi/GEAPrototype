using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Collectible : MonoBehaviour
{
    private int hundreds, tens, units;
    void Start()
    {
        hundreds = 0;
        tens = 0;
        units = 0;
    }
	
	void Update()
    {

    }

    public string getHundreds()
    {
        return hundreds.ToString();
    }
    public string getTens()
    {
        return tens.ToString();
    }
    public string getUnits()
    {
        return units.ToString();
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
    }
   
}
