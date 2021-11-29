using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReset : MonoBehaviour
{
    public Transform loadPos;
    

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            collider.GetComponent<Health>().takeDamage(1);
            collider.transform.position = loadPos.transform.position;
        }
    }
}
