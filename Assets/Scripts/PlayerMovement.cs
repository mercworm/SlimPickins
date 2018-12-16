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

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = true;
    [HideInInspector] public bool canMove = true;

    [Header("PlayerType")]
    public Data_Players playerType;
    private float speed;
    private float peckSpeed;
    private float pushForce;

    [Header("Audio")]
    public AudioSource source;
    public AudioClip soundLand, soundJump, soundPeck, soundWalk;

    private void Start()
    {
        rb2d.GetComponent<Rigidbody2D>();

        speed = playerType.speed;
        peckSpeed = playerType.peckSpeed;
        pushForce = playerType.pushForce;
    }

    private void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetKeyDown(keyJump) && grounded)
        {
            jump = true;
        }
    }

    private void FixedUpdate ()
    {
		if(canMove)
        {
            if(Input.GetKey(keyLeft))
            {

            }
            if(Input.GetKey(keyRight))
            {

            }
        }
	}
}
