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

    void FixedUpdate()
    {
        playerRb.linearVelocity = new Vector2(moveInput.x * speed, moveInput.y * speed);
        
    }

    #region InputMethods

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            InteractuarPanel panel = FindFirstObjectByType<InteractuarPanel>();
            if (panel != null)
                panel.OnInteract();
        }
    }


    #endregion

}
