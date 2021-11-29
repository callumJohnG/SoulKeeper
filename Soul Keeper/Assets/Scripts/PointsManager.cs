using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    private int points = -100;
    public GameObject textField;
    private Text myText;
    private string point;


    void Start(){
        myText = textField.GetComponent<Text>();
    }

    public void AddPoints(int n){
        Debug.Log("1");
        points += n;
        Debug.Log("2");
        myText.text = points.ToString();
    }

    public int GetPoints(){
        return points;
    }
}
