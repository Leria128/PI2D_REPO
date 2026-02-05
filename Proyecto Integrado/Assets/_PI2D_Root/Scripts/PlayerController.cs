using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement & Jump Configuration")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] bool isFacingRight; //Define la orientación
    [SerializeField] Transform groundCheck; // Posicion del detector de suelo
    [SerializeField] float groundCheckRadius; //Define el radio del círculo detector de suelo
    [SerializeField] LayerMask groundLayer; //Define la capa que puede tocar el detector de suelo

    [Header("Shoot Configuration")]
    [SerializeField] GameObject projectile; //Referencia al prefab de la bala
    [SerializeField] Transform shootPoint; //refrencia a la posición desde que se dispara
    [SerializeField] float shootCooldown = 1f; //cooldown es tiempo que tienes que esperar por ejemplo despues de atacar
    bool canShoot;


    //variables de referencia general
    Rigidbody2D playerRb; //Almacen del rigidbody del player
    Animator anim; //Almacén del controlador de animaciones del player
    PlayerInput input; //Almacén del controlador de inputs del player
    Vector2 moveInput;//Almacén del valor de los botones de movimiento
    bool canAttack; //Un bool de seguridad que define si se puede atacar o no 

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>(); //Autoreferenciar un componente propio 
        anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        canAttack = true;
        canShoot = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Lógica de detención de suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //Lógica de las animaciones
        Animationmanagement();
        //Lógica del Flip del personaje
        if (moveInput.x > 0 && !isFacingRight) Flip(); //! = falso, sin ! es verdadero
        if (moveInput.x < 0 && isFacingRight) Flip();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        //M0ver el motor de la aceleracion del rigidbody
        playerRb.linearVelocity = new Vector2(moveInput.x * speed, playerRb.linearVelocity.y);
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale; //Almacén temporal de la escala del objeto
        currentScale.x *= -1; //Invierte el valor en X del personaje
        transform.localScale = currentScale; //le devolvemos la escala al objeto con el valor x inverso, el personaje vuelve a la derecha
        isFacingRight = !isFacingRight; //Decirle al bool que cambie al valor contrario
    }

    void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }

    void Animationmanagement()
    {
        //Acción para gestionar los cambios de animación
        anim.SetBool("Jump", !isGrounded);
        if (moveInput.x != 0) anim.SetBool("Run", true);
        else anim.SetBool("Run", false);
    }


    #region InputMethods

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded) Jump();
    }

   





    #endregion


}
