using UnityEngine;

[ExecuteAlways]
public class SnapAGrillaMultiCelda : MonoBehaviour
{
    [Header("Referencia a la Grilla")]
    [Tooltip("Arrastra aquí el GameObject que tiene tu script SistemaDeGrilla2D")]
    public SistemaDeGrilla2D sistemaGrilla;

    [Header("Dimensiones del Objeto (en celdas)")]
    [Min(1)] public int celdasAncho = 4;
    [Min(1)] public int celdasAlto = 2;

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

        // Calculamos el ajuste para X e Y de forma independiente
        float xAjustado = CalcularSnap(posicionActual.x, tamano, celdasAncho);
        float yAjustado = CalcularSnap(posicionActual.y, tamano, celdasAlto);

        // Aplicamos la posición corregida, manteniendo el eje Z original
        transform.position = new Vector3(xAjustado, yAjustado, posicionActual.z);
    }

    private float CalcularSnap(float posicion, float tamanoCelda, int cantidadCeldas)
    {
        // Si la cantidad de celdas es impar, el centro del objeto va en el centro de la celda
        if (cantidadCeldas % 2 != 0)
        {
            return Mathf.Floor(posicion / tamanoCelda) * tamanoCelda + (tamanoCelda / 2f);
        }
        // Si la cantidad de celdas es par, el centro del objeto va sobre la línea de la grilla
        else
        {
            return Mathf.Round(posicion / tamanoCelda) * tamanoCelda;
        }
    }
}