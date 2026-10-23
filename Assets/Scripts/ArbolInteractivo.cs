using UnityEngine;

// Agregamos ", IInteractuable" para firmar el contrato
public class ArbolInteractivo : MonoBehaviour, IInteractuable
{
    public int maderaRestante = 3;

    // Estamos obligados a usar este método exacto
    public void Interactuar()
    {
        if (maderaRestante > 1)
        {
            maderaRestante--;
            Debug.Log("¡Has golpeado el árbol! Queda " + maderaRestante + " de madera.");

            // Aquí puedes instanciar el sprite de un tronco, reproducir sonido o partículas
        }
        else
        {
            Debug.Log("El árbol ha sido talado por completo.");
            Destroy(gameObject);
        }
    }
}