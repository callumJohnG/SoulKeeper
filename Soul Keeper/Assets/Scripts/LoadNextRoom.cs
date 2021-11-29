using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextRoom : MonoBehaviour
{
    public GameObject thisRoom;
    public List<GameObject> nextRooms;
    private int roomIndex;
    private int points;
    public int pointThreshold;

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            points = collider.GetComponent<PlayerMovement>().GetPoints();
            LoadRoom();
        }
    }

    void LoadRoom(){
        if(points >= pointThreshold){
            Instantiate(nextRooms[nextRooms.Count - 1],new Vector3(0,0,0), Quaternion.identity);
        } else {
            roomIndex = Random.Range(0, nextRooms.Count - 1);
            Instantiate(nextRooms[roomIndex],new Vector3(0,0,0), Quaternion.identity);
        }
        Destroy(thisRoom);
    }
}
