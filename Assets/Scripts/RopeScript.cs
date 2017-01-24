using UnityEngine;
using System.Collections;

public class RopeScript : MonoBehaviour
{
    private GameObject player;
    private MovementScript movement_script;

	void Start()
    {
	    player = GameObject.FindGameObjectWithTag("Player");
        movement_script = player.GetComponent<MovementScript>();

        GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 0));
	}
	
	void Update()
    {

	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        if (!movement_script.on_rope)
        {
            movement_script.setParentedRope(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        if (player.transform.parent == transform)
        {
            movement_script.setParentedRope(null);
        }
    }
}
