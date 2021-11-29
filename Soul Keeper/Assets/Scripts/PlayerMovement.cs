using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalMove = 0f;
    bool jump = false;
    public float runSpeed = 40f;

    public Animator animator;

    private bool cooling = false;
    public float cooldownTime = 2f;
    public float nextHit = 0f;

    public GameObject pointsManager;
    public AudioSource jumpSFX;
    public AudioSource swingSFX;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextHit && cooling){
            cooling = false;
            nextHit = Time.time + cooldownTime;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")){
            jump = true;
            jumpSFX.Play();
            animator.SetBool("isJumping", true);
        }
        if(Input.GetButtonDown("Attack") && !cooling){
            swingSFX.Play();
            animator.SetBool("canAttack", true);
            animator.SetBool("isJumping", false);
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void TriggerCooling(){
        cooling = true;
        animator.SetBool("canAttack", false);
    }
    public void Land(){
        animator.SetBool("isJumping", false);
    }

    public void GainPoints(int points){
        Debug.Log("Gaining Points");
        pointsManager.GetComponent<PointsManager>().AddPoints(points);
    }

    public int GetPoints(){
        return pointsManager.GetComponent<PointsManager>().GetPoints();
    }
}
