using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private bool IsCheckpointActivated;
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindWithTag("Player") && !IsCheckpointActivated)
        {
            PlayerMovement.playerManager.playerRespawnPos = GameObject.FindWithTag("Player").transform.position;
            IsCheckpointActivated = true;
        }
    }
}
