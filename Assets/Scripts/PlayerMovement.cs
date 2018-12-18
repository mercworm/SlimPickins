using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Movement")]
    public KeyCode keyLeft, keyRight, keyJump, keyPeck;

    private Rigidbody2D rb2d;

    private bool grounded = false;
    public Transform groundCheck;
    public float jumpForce;

    public float maxSpeed;

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    [HideInInspector] public bool canMove = true;

    [Header("PlayerType")]
    public Data_Players playerType;
    private float speed;
    private float peckSpeed;
    private float pushForce;

    [Header("Audio")]
    public AudioSource source;
    public AudioClip soundLand, soundJump, soundPeck, soundWalk;

    [Header("Animation")]
    public Animator legAnim;
    public Animator headAnim;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        speed = playerType.speed;
        peckSpeed = playerType.peckSpeed;
        pushForce = playerType.pushForce;
    }

    private void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        Debug.Log(grounded);

        if (Input.GetKeyDown(keyJump) && grounded)
        {
            jump = true;
        }
    }

    private void FixedUpdate ()
    {
		if(canMove)
        {
            float h = Input.GetAxis("Horizontal");
            legAnim.SetFloat ("Speed", Mathf.Abs (h));

            if (h * rb2d.velocity.x < maxSpeed)
                rb2d.AddForce(Vector2.right * h * speed);

            if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
                rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

            if (h > 0 && !facingRight)
                Flip();
            else if (h < 0 && facingRight)
                Flip();

            if (jump)
            {
                //anim.SetTrigger ("Jump");
                rb2d.AddForce(new Vector2(0f, jumpForce));
                jump = false;
            }
        }
	}

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
