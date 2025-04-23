using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    public GameObject winningCanvas; //displays you win, restart, and quit


    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(winningCanvas != null)
        {
            winningCanvas.SetActive(false);
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
             Time.timeScale = 0;
            winningCanvas.SetActive(true); //display you win screen
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Allows level progression if neccessary
        }
    }
}
