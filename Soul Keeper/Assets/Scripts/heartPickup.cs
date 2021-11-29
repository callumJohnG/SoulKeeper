using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartPickup : MonoBehaviour
{
    public GameObject me;

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            collider.GetComponent<Health>().gainHealth(1);
            Destroy(me);
        }
    }
}
