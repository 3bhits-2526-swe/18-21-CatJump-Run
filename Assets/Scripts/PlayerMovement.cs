
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject player;
    [SerializeField] public Vector2 playerRespawnPos;
    [SerializeField] public static PlayerMovement playerManager {get; private set;}
    [SerializeField] private Animator animator;
    [Header("Movement AD")]
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float movementDirection;
    [Header("Jump")]
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private bool IsGrounded;
    [SerializeField] private float groundErrorMargin = 0.1f;
    [SerializeField] private LayerMask groundLayer;
    [Header("Dash")]
    [Tooltip("Geht nicht ist hardgecoded auf 100")]
    [SerializeField] private float dashForce = 10;
    [SerializeField] private bool IsDashing;
    [SerializeField] private float dashTimer;
    [SerializeField] private float dashSetBackTime;
    [Header("Debug")]
    [SerializeField] Vector2 vectorForDashMovement;
    [SerializeField] Vector2 vectorForNormalMovement;
    void Start()
    {
        playerManager = this;
        groundLayer = LayerMask.GetMask("Ground");
        player = GameObject.FindWithTag("Player");
        playerRespawnPos = player.transform.position;
    }

    void Update()
    {
        movementDirection = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.F) && !IsDashing)
        {
            IsDashing = true;
            dashTimer = dashSetBackTime;
        }
        if(player.transform.position.y < -8)
        {
            player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            player.transform.position = playerRespawnPos;
        }
    }
    void FixedUpdate()
    {
        IsGroundedCheck();
        if (!IsDashing)
        {
            vectorForNormalMovement = new Vector2(movementDirection * movementSpeed, player.GetComponent<Rigidbody2D>().linearVelocity.y);
            player.GetComponent<Rigidbody2D>().linearVelocity = vectorForNormalMovement;
        }
        else if (IsDashing)
        {
            vectorForDashMovement = new Vector2((movementSpeed + 50) * movementDirection, player.GetComponent<Rigidbody2D>().linearVelocity.y);
            player.GetComponent<Rigidbody2D>().linearVelocity = vectorForDashMovement;
            if (dashTimer < 0)
            {
                IsDashing = false;

            }
            else
            {
                dashTimer -= Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector3(1,1,1);
        }
        if(movementDirection != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }   
    private void IsGroundedCheck()
    {
        Vector2 origin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(
            origin,
            Vector2.down,
            groundErrorMargin,
            groundLayer
        );
        IsGrounded = hit.collider;
    }
}
