using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{

    public GameObject enemy;
    
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            if(enemy.transform.rotation.y == 0f){
                enemy.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
            } else {
                enemy.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            }
        }
    }
}
