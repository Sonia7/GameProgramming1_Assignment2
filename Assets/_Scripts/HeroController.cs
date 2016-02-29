﻿using UnityEngine;
using System.Collections;
[System.Serializable]
public class VelocityRange
{
    public float minimum;
    public float maximum;
    public VelocityRange(float minimum, float maximum)//constructor
    {
        this.minimum = minimum;
        this.maximum = maximum;
    }
}

public class HeroController : MonoBehaviour
{

    //public instance variable
    public VelocityRange velocityRange;
    public float moveForce;
    public float jumpForce;
    public Transform groundCheck;
    // PRIVATE  INSTANCE VARIABLES
    private Animator _animator;
    private float _move;
    private float _jump;
    private bool _facingRight;
    private Transform _transform;
    private Rigidbody2D _rigidBody2D;
    private bool _isGrounded;
    // Test the awake method

    // Use this for initialization
    void Start()
    {
        //Initialise Public Variable
        this.velocityRange = new VelocityRange(300f, 1000f);
        this.moveForce = 1500f;
        this.jumpForce = 17000f;

        //Initialise Private Variable
        this._transform = gameObject.GetComponent<Transform>();
        this._animator = gameObject.GetComponent<Animator>();
        this._rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        this._move = 0f;
        this._jump = 0f;
        this._facingRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this._isGrounded = Physics2D.Linecast(this._transform.position, this.groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawLine(this.transform.position, this.groundCheck.position);


        float forceX = 0f;
        float forceY = 0f;

        float absVelX = Mathf.Abs(this._rigidBody2D.velocity.x);
        float absVelY = Mathf.Abs(this._rigidBody2D.velocity.y);

        //Debug.Log (this._jump);
        if (this._isGrounded)
        {
            this._move = Input.GetAxis("Horizontal");
            this._jump = Input.GetAxis("Vertical");
            if (this._move != 0)
            {
                if (this._move > 0)
                {
                    if (absVelX < this.velocityRange.maximum)
                    {
                        forceX = this.moveForce;
                    }
                    this._facingRight = true;
                    this._flip();
                }
                if (this._move < 0)
                {
                    if (absVelX < this.velocityRange.maximum)
                    {
                        forceX = -this.moveForce;
                    }
                    this._facingRight = false;
                    this._flip();
                }

                // call the walk clip
                this._animator.SetInteger("AnimState", 1);
            }
            else
            {

                // set default animation state to "idle"
                this._animator.SetInteger("AnimState", 0);
            }

            if (this._jump > 0)
            {
                // call the "jump" clip
                if (absVelY < this.velocityRange.maximum)
                {
                    forceY = this.jumpForce;
                }
            }
        }
        else
        {
            this._animator.SetInteger("AnimState", 2);
        }
        this._rigidBody2D.AddForce(new Vector2(forceX, forceY));
    }

    // PRIVATE METHODS
    private void _flip()
    {
        if (this._facingRight)
        {
            this._transform.localScale = new Vector2(1, 1);
        }
        else
        {
            this._transform.localScale = new Vector2(-1, 1);
        }
    }
}
