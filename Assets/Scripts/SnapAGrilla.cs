using UnityEngine;

[ExecuteAlways]
public class SnapAGrilla : MonoBehaviour
{
    [Header("Referencia a la Grilla")]
    [Tooltip("Arrastra aquí el GameObject que tiene tu script SistemaDeGrilla2D")]
    public SistemaDeGrilla2D sistemaGrilla;

    [Header("Configuración del Pivote")]
    [Tooltip("Marca esta casilla si el pivote de tu sprite está en el Centro. Déjala desmarcada si está abajo a la izquierda.")]
    public bool centrarEnCelda = true;

    private void Update()
    {
        // Si no hemos asignado la grilla, no hacemos nada
        if (sistemaGrilla == null) return;

        AjustarPosicion();
    }

    private void AjustarPosicion()
    {
        Vector3 posicionActual = transform.position;
        float tamano = sistemaGrilla.tamanoCelda;

        // Calculamos la coordenada exacta de la celda (Snap)
        float xAjustado = Mathf.Floor(posicionActual.x / tamano) * tamano;
        float yAjustado = Mathf.Floor(posicionActual.y / tamano) * tamano;

        // Si el pivote de tu imagen está en el centro, sumamos la mitad de la celda para que encaje perfecto
        if (centrarEnCelda)
        {
            xAjustado += tamano / 2f;
            yAjustado += tamano / 2f;
        }

        // Aplicamos la posición corregida, manteniendo el eje Z original (útil para el orden de las capas)
        transform.position = new Vector3(xAjustado, yAjustado, posicionActual.z);
    }
}