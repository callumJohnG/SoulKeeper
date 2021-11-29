using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float cooldownTime = 2f;
    private float nextHit = 0f;

    public int health;
    public int maxHeath;

    public Image[] hearts;
    public Sprite fullHeart;
    public AudioSource damageSFX;
    public AudioSource healthSFX;


    void Update(){
        for (int i = 0; i<hearts.Length; i++){
            if(i<health){
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }

    public void takeDamage(int damage){
        if(Time.time > nextHit){
            damageSFX.Play();
            health -= damage;
            nextHit = Time.time + cooldownTime;
            if (health <=0){
                GameOver();
            }
        }
    }

    public void gainHealth(int damage){
        healthSFX.Play();
        health += damage;
        if(health>maxHeath){
            health = maxHeath;
        }
    }

    void GameOver(){
        SceneManager.LoadScene(2);
    }
}
