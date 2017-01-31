using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
    public float walk_speed = 1.0f;
    public float climb_speed = 1.0f;

    public float jump_force = 3.0f;
    public float swing_force = 50.0f;

    public string horizontal_axis = "Horizontal";
    public string vertical_axis = "Vertical";

    public Animator anim;
    public bool on_ground;
    public bool on_ice;

    public GameObject rope_in_reach = null;
    private bool on_rope = false;

    public bool ladder_in_reach = false;
    private bool on_ladder = false;

    private Rigidbody2D rigid_body;

	public AudioSource jump;


    void Start() 
    {
        anim = GetComponent<Animator>();
        rigid_body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ladder_movement();
        rope_movement();

        if (!on_ladder && !on_rope)
        {
            rigid_body.gravityScale = 1;
        }

        if (!on_rope)
        {
            rigid_body.isKinematic = false;

            transform.position += transform.right * Input.GetAxis(horizontal_axis) * walk_speed * Time.deltaTime;
        }

        if ((on_ground && !on_ladder) || on_rope)
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                on_rope = false;
                rigid_body.isKinematic = false;
                transform.SetParent(null);

				jump.Play();

                rigid_body.gravityScale = 1;
                GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, jump_force), ForceMode2D.Impulse);
            }
        }

    }

    void ladder_movement()
    {
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
    }

    void rope_movement()
    {
        if (rope_in_reach)
        {
            if (Input.GetAxis(vertical_axis) != 0)
            {
                transform.SetParent(rope_in_reach.transform);

                on_rope = true;
                rigid_body.velocity = Vector2.zero;
            }
        }
        else
        {
            if (on_rope)
            {
                transform.SetParent(null);
            }

            on_rope = false;
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        if (on_rope)
        {
            rigid_body.gravityScale = 0;
            rigid_body.isKinematic = true;

            rope_in_reach.GetComponent<Rigidbody2D>().AddForce(new Vector2(swing_force * Input.GetAxis(horizontal_axis), 0));
            transform.position += transform.up * Input.GetAxis(vertical_axis) * climb_speed * Time.deltaTime;
        }
    }




}