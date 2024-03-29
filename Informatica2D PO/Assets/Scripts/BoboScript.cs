using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoboScript : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;

    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode jump;

    private Rigidbody2D rb;

    [SerializeField] private Transform groundCheckPoint;

    [SerializeField] private bool isOnGround;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundCheckLayerMask;

    [SerializeField] private LayerMask bibiCheckLayerMask;
    [SerializeField] private bool isOnBibi;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        MovementManager();
    }

    private void MovementManager()
    {

        isOnGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundCheckLayerMask);
        isOnBibi = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, bibiCheckLayerMask);
        

        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(jump) && isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        if (isOnBibi)
        {
            //Bibi splets uit elkaar, spel overnieuw
        }
    }

}
