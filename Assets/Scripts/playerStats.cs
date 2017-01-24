using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {
    public int lives = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.tag == "Enemy")
        //{
        //    Debug.Log("hit player");
            
        //}
    }

    public void Respawn()
    {
        this.transform.position = new Vector3(0.0f, -0.5f, 0.0f);
    }
}
