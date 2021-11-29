using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitBox : MonoBehaviour
{

    public int damage = 1;

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            Debug.Log("Hit the player");
            collider.gameObject.GetComponent<Health>().takeDamage(damage);
        }
    }
}
