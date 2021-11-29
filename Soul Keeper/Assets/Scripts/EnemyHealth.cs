using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject enemy;

    public float cooldownTime = 2f;
    private float nextHit = 0f;

    public int health;


    public void takeDamage(int damage){
        if(Time.time > nextHit){
            health -= damage;
            nextHit = Time.time + cooldownTime;
            if (health <=0){
                Die();
            }
        }
    }
    void Die(){
        Destroy(enemy);
    }
}
