using UnityEngine;

public class ObstacleRunInDeath : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player)
        {
            player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            player.GetComponent<Transform>().position = PlayerMovement.playerManager.playerRespawnPos;
        }
    }
}
