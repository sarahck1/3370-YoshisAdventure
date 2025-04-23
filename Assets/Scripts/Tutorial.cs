using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tutorial : MonoBehaviour
{
    //public GameObject blankBlock;
   // public GameObject questionBlock;
    public GameObject messageText;
    public Sprite blankSprite; 
    private SpriteRenderer spriteRenderer;

    public float displayTime = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messageText.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {   
            StartCoroutine(ShowMessage()); //in order to wait before hiding the text
            SwapToBlankBlock();
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

     private void SwapToBlankBlock()
    {
        if (blankSprite != null)
        {
            spriteRenderer.sprite = blankSprite;
        }
    }
}
