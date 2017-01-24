using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
    public float speed = 1.0f;
    public string axisName = "Horizontal";
    public Animator anim;
    public bool OnGround;

    public bool on_rope = false;
    private GameObject parented_rope;

    private Rigidbody2D rigid_body;

    void Start() 
    {
        anim = GetComponent<Animator>();
        rigid_body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {  
        if (parented_rope)
        {
            transform.position = Vector3.MoveTowards(transform.position, parented_rope.transform.position, 1);
            parented_rope.GetComponent<Rigidbody2D>().AddForce(new Vector2(5 * Input.GetAxis(axisName), 0));
        }
        else
        {
            transform.position += transform.right * Input.GetAxis(axisName) * speed * Time.deltaTime;
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        OnGround = true;

        if (OnGround == true)
        {
            if (Input.GetKeyDown (KeyCode.Space)) 
            {  //makes player jump
                GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 3), ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (OnGround) 
        {
            OnGround = false;
        }
    }

    public void setParentedRope(GameObject rope)
    {
        if (rope)
        {
            parented_rope = rope;
            transform.SetParent(rope.transform);
            rigid_body.gravityScale = 0;
            on_rope = true;
        }
        else
        {
            parented_rope = rope;
            transform.SetParent(rope.transform);
            rigid_body.gravityScale = 0;
            on_rope = false;
        }
    }
}