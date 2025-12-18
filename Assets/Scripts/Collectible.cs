using UnityEngine;

public class Collectible : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == GameObject.FindWithTag("Player"))
        {
            CollectibleManager.collectibleManager.IncreaseCount();
            Destroy(gameObject);
        }
    }
}
