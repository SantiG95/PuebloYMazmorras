using UnityEngine;
using UnityEngine.UI;

public class UIVida : MonoBehaviour
{
    [Header("Referencias")]
    [Tooltip("Arrastra aquí a tu jugador desde la jerarquía")]
    public HealthComponent componenteVidaJugador;

    [Tooltip("Arrastra aquí la imagen de la barra (debe tener Image Type: Filled)")]
    public Image imagenBarraVida;

    // OnEnable se ejecuta cuando este objeto de UI se activa
    private void OnEnable()
    {
        if (componenteVidaJugador != null)
        {
            // NOS SUSCRIBIMOS AL EVENTO: Usamos +=
            componenteVidaJugador.OnSaludCambiada += ActualizarBarra;
        }
    }

    // OnDisable se ejecuta cuando la UI se destruye o desactiva (¡CRUCIAL PARA EVITAR ERRORES!)
    private void OnDisable()
    {
        if (componenteVidaJugador != null)
        {
            // NOS DESUSCRIBIMOS DEL EVENTO: Usamos -=
            componenteVidaJugador.OnSaludCambiada -= ActualizarBarra;
        }
    }

    // Esta función NO está en un Update. SOLO se llamará cuando el HealthComponent dispare el evento.
    private void ActualizarBarra(float saludActual, float saludMaxima)
    {
        // Calculamos el porcentaje (ej. 50 / 100 = 0.5f) para el Fill Amount
        imagenBarraVida.fillAmount = saludActual / saludMaxima;
    }
}