using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables de control del jugador
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private bool isGrounded;
    private Rigidbody2D rb;

    // Variables para detectar a qué jugador pertenece
    public bool isPlayer1 = true; // True si es jugador 1, false si es jugador 2

    // Variables para el movimiento del jugador
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Comprobar si el jugador está en el suelo para poder saltar
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        // Llamada al movimiento y salto de los jugadores
        if (isPlayer1)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal"); // A/D o flechas
            if (Input.GetKeyDown(KeyCode.W) && isGrounded) // Salto con W
            {
                Jump();
            }
        }
        else
        {
            horizontalInput = Input.GetAxisRaw("Horizontal_P2"); // Flechas (modificar en los Input settings)
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) // Salto con Flecha arriba
            {
                Jump();
            }
        }

        Move();
    }

    // Función para mover al jugador
    void Move()
    {
        // Movimiento lateral
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    // Función para hacer que el jugador salte
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
