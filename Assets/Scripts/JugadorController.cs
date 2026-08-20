using UnityEngine;

public class JugadorController : MonoBehaviour
{
    public float velocidad = 5;
    private Vector2 direccion;
    private Vector2 ultimaDireccion;


    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        ultimaDireccion = Vector2.down;
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        direccion = new Vector2(inputX, inputY).normalized;

        // Si hay movimiento, actualizamos la última dirección
        if (direccion.magnitude > 0)
        {
            ultimaDireccion = direccion;
        }

        // 1. Lógica de Espejado (Flip)
        if (inputX < 0) // Izquierda
        {
            spriteRenderer.flipX = true;
        }
        else if (inputX > 0) // Derecha
        {
            spriteRenderer.flipX = false;
        }

        // 2. Comunicarnos con el Animator
        // Usamos Mathf.Abs en X porque la animación "Derecha" sirve para la "Izquierda"
        animator.SetFloat("Horizontal", Mathf.Abs(ultimaDireccion.x));
        animator.SetFloat("Vertical", ultimaDireccion.y);
        animator.SetFloat("Velocidad", direccion.magnitude);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direccion * velocidad;
    }
}