using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] bool isGrounded;
    [SerializeField] bool isFacingRight;
    [SerializeField] enum FacingDirection { Left, Right, Up, Down }
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer; 


    //Referencias generales
    Rigidbody2D playerRb;
    Animator anim;
    PlayerInput input;
    Vector2 moveInput;
    FacingDirection facing;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>(); //Autoreferenciar componenete propio
        anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        isFacingRight = true;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //Animationmanagement();

        //direccion del personaje

        //Flip
        if (moveInput.x > 0)
            facing = FacingDirection.Right;
        else if(moveInput.x < 0)
            facing = FacingDirection.Left;
        if(moveInput.y > 0)
            facing = FacingDirection.Up;    
        else if (moveInput.y < 0)
            facing = FacingDirection.Down;  




    }

    
}
