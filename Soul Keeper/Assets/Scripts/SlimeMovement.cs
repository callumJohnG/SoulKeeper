using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{   
    #region public variables
    public Transform rayCast;
    public LayerMask rayCastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public CharacterController2D controller;
    #endregion

    #region private variables
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    #endregion
    
    void Awake(){
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    void Update(){
        if(inRange){
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, rayCastMask);
            if(hit.collider == null){
                hit = Physics2D.Raycast(rayCast.position, Vector2.right, rayCastLength, rayCastMask);
            }
            RaycastDebugger();
        }

        if(hit.collider != null){
            EnemyLogic();
        } else if(hit.collider == null){
            inRange = false;
        }

        if (inRange == false){
            anim.SetBool("canWalk", false);
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D trig){
        if(trig.gameObject.tag == "Player"){
            target = trig.gameObject;
            inRange = true;
        }
    }

    void EnemyLogic(){
        distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance > attackDistance){
            Move();
            StopAttack();
        } else if(attackDistance >= distance && cooling == false){
            Attack();
        }

        if(cooling){
            anim.SetBool("Attack", false);
            Cooldown();
        }
    }

    void Move(){

        anim.SetBool("canWalk", true);

        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Slime_Attack")){
            float distance = target.transform.position.x - transform.position.x;
            float direction = distance/(Mathf.Abs(distance));
        
            //Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);

            //transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            controller.Move(direction * moveSpeed * Time.deltaTime, false, false);
        }
    }

    void Attack(){
        timer = intTimer;
        attackMode = true;

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);

    }

    void Cooldown(){
        timer -= Time.deltaTime;

        if(timer <= 0 && cooling && attackMode){
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack(){
        cooling = false;
        attackMode = false;

        anim.SetBool("Attack", false);
    }

    void RaycastDebugger(){
        if(distance > attackDistance){
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        } else if(attackDistance < distance){
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }

    public void TriggerCooling(){
        cooling = true;
    }

/*    public CharacterController2D controller;

    public float speed;

    private Transform target;

    bool moving = false;
    float xDiff;
    float yDiff;

    public float xSightRange = 5f;
    public float ySightRange = 2.5f;

    public float xAttackRange = 1f;
    public float yAttackRange = 1f;

    float horizontalMove = 0f;
    float direction = 0f;

    public float attackCoolDown = 2f;
    public float attackDuration = 1f;
    private float elapsedTime = 0f;
    private float elapsedAttack = 0f;
    public GameObject attack;

    bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();    
    }

    // Update is called once per frame
    void Update()
    {
        xDiff = target.position.x - transform.position.x;
        yDiff = target.position.y - transform.position.y;
        
        direction = xDiff / Mathf.Abs(xDiff);

        //Debug.Log("X:"+ xDiff+ "Y:"+ yDiff);

        if(inSightRange(xDiff, yDiff)){
            horizontalMove = direction * speed;
        }

        if(inAttackRange(xDiff, yDiff) && Time.time > elapsedTime){
            Debug.Log("Attacking!");
            elapsedTime = Time.time + attackCoolDown;
            elapsedAttack = Time.time + attackDuration;
            attacking = true;
            attack.SetActive(true);
        }

        if(attacking && Time.time > elapsedAttack){
            attacking = false;
            attack.SetActive(false);
        }

        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    bool inSightRange(float xDiff, float yDiff){
        return (Mathf.Abs(xDiff)<xSightRange && Mathf.Abs(yDiff)<ySightRange);
    }

    bool inAttackRange(float xDiff, float yDiff){
        return (Mathf.Abs(xDiff)<xAttackRange && Mathf.Abs(yDiff)<yAttackRange);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }*/
}
