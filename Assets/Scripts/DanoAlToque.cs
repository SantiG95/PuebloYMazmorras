using UnityEngine;

public class DanoAlToque : MonoBehaviour
{
    [Header("Configuración del Daño")]
    [Tooltip("Cantidad de vida que quitará este objeto al tocarlo")]
    public float cantidadDeDano = 10f;

    // Esta función se ejecuta automáticamente cuando otro colisionador
    // entra en contacto con el colisionador de este objeto (si está marcado como Trigger)
    private void OnTriggerEnter2D(Collider2D otro)
    {
        // 1. Intentamos buscar el HealthComponent en el objeto que nos acaba de chocar (el jugador)
        HealthComponent componenteVida = otro.GetComponent<HealthComponent>();

        // 2. Si el objeto tiene un HealthComponent, procedemos a dañarlo
        if (componenteVida != null)
        {
            // Enviamos el daño como un número NEGATIVO para que la vida disminuya
            componenteVida.ModificarSalud(-cantidadDeDano);

            // Opcional: Mostrar un mensaje en consola para verificar
            Debug.Log("¡El jugador ha tocado el objeto y ha recibido " + cantidadDeDano + " de daño!");
        }
    }
}