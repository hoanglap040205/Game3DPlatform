using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandleOutPut : MonoBehaviour
{
    private Rigidbody body;
    private CapsuleCollider capSul;
    public Animator anim;
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private float jumpCounter = 2;
    private float timeCoolDown;
    
    
    private float inPutHor;
    private float inPutVer;
    
    public LayerMask groundLayer;
    [SerializeField] private float radius;
    [SerializeField] private Transform groundCheck;


    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        capSul = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsGrounded())
        {
            Movement();
            jumpCounter = 2;
        }
        anim.SetBool("IsGround",IsGrounded());

        Jump();
        Rotation();
        timeCoolDown += Time.deltaTime;
    }

    private void Movement()
    {
        inPutHor = Input.GetAxis("Horizontal");
        inPutVer = Input.GetAxis("Vertical");
        if (IsGrounded())
        {
            Sprint();
            Vector3 movement = new Vector3(inPutHor,0, inPutVer).normalized * moveSpeed;
            body.velocity = movement;
            anim.SetBool("isMoving",inPutHor != 0 || inPutVer != 0);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter > 1 )
        {
            //Loi double jump
            
            
            jumpCounter -= 1;
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump");
        }
        
    }

    private void Rotation()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 360 * Time.deltaTime);  
        }
        
    }

    private void Sprint()
    {
        bool inPutLeftShirt = Input.GetKey(KeyCode.LeftShift);
        anim.SetBool("GetKeyLeftShift",inPutLeftShirt);
        
        //Xu li tang toc
    }
    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position,radius,groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position,radius);
    }

}
