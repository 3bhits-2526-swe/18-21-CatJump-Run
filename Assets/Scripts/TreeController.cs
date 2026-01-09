using UnityEngine;

public class TreeController : MonoBehaviour
{
    [SerializeField] private GameObject treeLocked;
    [SerializeField] private GameObject treeUnlocked;
    void Awake()
    {
        treeLocked = GameObject.FindWithTag("TreeLocked");
        treeUnlocked = GameObject.FindWithTag("TreeUnlocked");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindWithTag("Player") && CollectibleManager.collectibleManager.GotEverything)
        {
            treeLocked.SetActive(false);
            treeUnlocked.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
