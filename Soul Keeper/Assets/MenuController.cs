using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N)){
            SceneManager.LoadScene(1);
        }
    }

    public void a2(){
        anim.SetBool("a2", true);
    }

    public void a3(){
        anim.SetBool("a3", false);
    }
}
