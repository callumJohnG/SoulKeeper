using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public GameObject player;
    public AudioSource hitSFX;

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Enemy"){
            hitSFX.Play();
            collider.GetComponent<EnemyHealth>().takeDamage(1);
            player.GetComponent<PlayerMovement>().GainPoints(25);
        }
    }
}
