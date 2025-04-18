using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tutorial : MonoBehaviour
{
    public GameObject blankBlock;
    public GameObject questionBlock;
    public GameObject messageText;

    public float displayTime = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //hide blank, show question
        if(blankBlock && questionBlock && messageText != null)
        {
            messageText.SetActive(false);
            blankBlock.SetActive(false);
            questionBlock.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ItemBlock"))
        {   
            StartCoroutine(ShowMessage()); //in order to wait before hiding the text
            blankBlock.SetActive(true);
            questionBlock.SetActive(false);
        }
    }

    private IEnumerator ShowMessage()
    {
        messageText.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        messageText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
