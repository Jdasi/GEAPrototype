using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
    public float walk_speed = 1.0f;
    public float climb_speed = 1.0f;

    public float jump_force = 3.0f;

    public string horizontal_axis = "Horizontal";
    public string vertical_axis = "Vertical";

    public Animator anim;
    public bool on_ground;

    public bool on_rope = false;
    private GameObject parented_rope;

    public bool ladder_in_reach = false;
    private bool on_ladder = false;

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
            parented_rope.GetComponent<Rigidbody2D>().AddForce(new Vector2(50f * Input.GetAxis(horizontal_axis), 0));
        }
        else
        {
            transform.position += transform.right * Input.GetAxis(horizontal_axis) * walk_speed * Time.deltaTime;
        }

        if (ladder_in_reach)
        {
            if (Input.GetAxis(vertical_axis) != 0)
            {
                on_ladder = true;
                rigid_body.velocity = Vector2.zero;
            }
        }
        else
        {
            on_ladder = false;
        }

        if (on_ladder)
        {
            rigid_body.gravityScale = 0;
            transform.position += transform.up * Input.GetAxis(vertical_axis) * climb_speed * Time.deltaTime;
        }
        else
        {
            rigid_body.gravityScale = 1;
        }

        if (on_ground && !on_ladder)
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, jump_force), ForceMode2D.Impulse);
            }
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
            rigid_body.gravityScale = 1;
            on_rope = false;
        }
    }
}