using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [Header("Atributos")]
    public float saludMaxima = 100f;
    public float saludActual;

    // Declaramos los eventos. Action<float, float> permite enviar 2 números (actual y máxima) a quien escuche.
    public event Action<float, float> OnSaludCambiada;
    public event Action OnMuerte; // Evento sin parámetros para cuando llegue a 0

    private void Start()
    {
        saludActual = saludMaxima;

        // Disparamos el evento al inicio para que la UI se configure con la vida llena
        OnSaludCambiada?.Invoke(saludActual, saludMaxima);
    }

    // Llama a esta función desde trampas, enemigos, o pociones
    public void ModificarSalud(float cantidad)
    {
        // Si la cantidad es negativa (daño) o positiva (curación), la sumamos
        saludActual += cantidad;

        // Evitamos que la vida baje de 0 o supere el máximo
        saludActual = Mathf.Clamp(saludActual, 0, saludMaxima);

        // ¡Disparamos el evento! El símbolo '?' comprueba si hay alguien escuchando antes de enviarlo.
        OnSaludCambiada?.Invoke(saludActual, saludMaxima);

        // Comprobamos si ha muerto
        if (saludActual <= 0)
        {
            OnMuerte?.Invoke();
        }
    }
}