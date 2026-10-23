using UnityEngine;

public class JugadorController : MonoBehaviour
{
    public float velocidad = 5;
    private Vector2 direccion;
    private Vector2 ultimaDireccion;


    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [Header("Interacción")]
    public float distanciaInteraccion = 1.5f;
    public LayerMask capaInteractuable; // Vital para ignorar el propio cuerpo del jugador

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

        // Detectar el botón de interacción
        if (Input.GetKeyDown(KeyCode.E))
        {
            IntentarInteractuar();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direccion * velocidad;
    }

    private void IntentarInteractuar()
    {
        // 1. Disparamos el Raycast desde la posición del jugador hacia su última dirección
        RaycastHit2D impacto = Physics2D.Raycast(transform.position, ultimaDireccion, distanciaInteraccion, capaInteractuable);

        // Opcional: Dibuja una línea roja en la pestaña Scene para que veas el láser (solo modo editor)
        Debug.DrawRay(transform.position, ultimaDireccion * distanciaInteraccion, Color.red, 2f);

        // 2. Si el láser golpea el colisionador de algo...
        if (impacto.collider != null)
        {
            // 3. Le preguntamos al objeto si tiene un script que use IInteractuable
            IInteractuable objetoInteractuable = impacto.collider.GetComponent<IInteractuable>();

            if (objetoInteractuable != null)
            {
                // Si lo tiene, ejecutamos su lógica
                objetoInteractuable.Interactuar();
            }
        }
    }
}