using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private GameObject player;
    public Transform spawnPoint;

    void Start(){
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        player.transform.position = spawnPoint.transform.position;
        player.GetComponent<PlayerMovement>().GainPoints(100);
    }
}
