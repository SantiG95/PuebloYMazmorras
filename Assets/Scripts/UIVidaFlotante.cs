using UnityEngine;
using UnityEngine.UI;

public class UIVidaFlotante : MonoBehaviour
{
    [Header("Visuales")]
    public Image imagenBarraVida;

    // Referencia interna al componente de salud del personaje
    private HealthComponent componenteVida;

    private void Awake()
    {
        // Busca automáticamente el HealthComponent en el objeto padre (el personaje)
        componenteVida = GetComponentInParent<HealthComponent>();
    }

    private void OnEnable()
    {
        if (componenteVida != null)
        {
            // Nos suscribimos al evento
            componenteVida.OnSaludCambiada += ActualizarBarra;
        }
    }

    private void OnDisable()
    {
        if (componenteVida != null)
        {
            // Nos desuscribimos para evitar errores cuando el enemigo/jugador sea destruido
            componenteVida.OnSaludCambiada -= ActualizarBarra;
        }
    }

    private void ActualizarBarra(float saludActual, float saludMaxima)
    {
        // Actualizamos el Fill Amount de la imagen (debe estar entre 0 y 1)
        if (imagenBarraVida != null)
        {
            imagenBarraVida.fillAmount = saludActual / saludMaxima;
        }
    }
}