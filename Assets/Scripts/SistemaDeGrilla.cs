using UnityEngine;

[ExecuteAlways]
public class SistemaDeGrilla2D : MonoBehaviour
{
    [Header("Configuración de Grilla (Estilo Stardew)")]
    [Min(1)] public int celdasAncho = 10;
    [Min(1)] public int celdasLargo = 10;
    [Min(0.1f)] public float tamanoCelda = 1f;
    public Color colorGrilla = Color.green;

    private void OnDrawGizmos()
    {
        Gizmos.color = colorGrilla;
        Vector3 posicionInicial = transform.position;

        // Dibujar líneas verticales (Eje Y)
        for (int x = 0; x <= celdasAncho; x++)
        {
            Vector3 puntoInicio = posicionInicial + new Vector3(x * tamanoCelda, 0, 0);
            Vector3 puntoFin = posicionInicial + new Vector3(x * tamanoCelda, celdasLargo * tamanoCelda, 0);
            Gizmos.DrawLine(puntoInicio, puntoFin);
        }

        // Dibujar líneas horizontales (Eje X)
        for (int y = 0; y <= celdasLargo; y++)
        {
            Vector3 puntoInicio = posicionInicial + new Vector3(0, y * tamanoCelda, 0);
            Vector3 puntoFin = posicionInicial + new Vector3(celdasAncho * tamanoCelda, y * tamanoCelda, 0);
            Gizmos.DrawLine(puntoInicio, puntoFin);
        }
    }
}