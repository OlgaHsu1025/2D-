using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2D : MonoBehaviour

{
    [SerializeField] float maxSpeed = 3;
    [SerializeField] float jumpForce = 8;
    [SerializeField] LayerMask whatIsGround;

    Animator animator;
    Rigidbody2D rigidbody;
    Transform grouncheck;
    AudioSource audioSource;
    float delaytime = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        grouncheck = transform.Find("GrounCheck");
        audioSource = GameObject.Find("Jump").GetComponent<AudioSource>();
    }
    public void Move(float speed, bool jump)
    {
        Collider2D[] colliders =  Physics2D.OverlapCircleAll(grouncheck.position, 0.02f, whatIsGround);
        bool isOnGround = false;
        if(colliders.Length > 0) {
            isOnGround = true;}

        animator.SetBool("Ground", isOnGround);
        if (isOnGround && delaytime < Time.time)
        {
            if (speed > 0) transform.rotation = Quaternion.identity;
            if (speed < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
      
            //transform.Translate(speedRate * maxSpeed * Time.deltaTime, 0, 0);
            rigidbody.velocity = transform.right * Mathf.Abs(speed) * maxSpeed;
            animator.SetFloat("Speed", Mathf.Abs(speed) , 0.1f , Time.deltaTime);

            if (jump)
            {
                audioSource.Play();
                delaytime = Time.time + 0.5f;
                rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                animator.SetTrigger("Jump");
            }
        }


        animator.SetFloat("vSpeed", rigidbody.velocity.y);

    }

}
