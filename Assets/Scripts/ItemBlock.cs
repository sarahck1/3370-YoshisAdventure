using UnityEngine;

public class ItemBlock : MonoBehaviour
{
    public GameObject[] fruitPrefabs; 
    public Transform spawnPoint; 
    public Sprite blankSprite; 

    private SpriteRenderer spriteRenderer;
    private bool hasBeenHit = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasBeenHit) return;

        if (collision.collider.CompareTag("Player"))
        {
            Vector2 hitDirection = collision.contacts[0].normal;
            if (hitDirection.y > 0.5f)
            {
                SpawnRandomFruit();
                SwapToBlankBlock();
                hasBeenHit = true;
            }
        }
    }

    private void SpawnRandomFruit()
    {
         if (fruitPrefabs.Length > 0)
    {
        int index = Random.Range(0, fruitPrefabs.Length);
        Debug.Log("Spawning fruit: " + fruitPrefabs[index].name);
        Instantiate(fruitPrefabs[index], spawnPoint.position, Quaternion.identity);
    }
    else
    {
        Debug.LogError("Fruit Prefabs array is empty!");
    }
       
    }

    private void SwapToBlankBlock()
    {
        if (blankSprite != null)
        {
            spriteRenderer.sprite = blankSprite;
        }
    }
}
