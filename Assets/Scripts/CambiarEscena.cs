using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manejar escenas

public class CambiarEscena : MonoBehaviour
{
    // Método para cargar una escena por nombre
    public void CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    // Método para cargar una escena por índice (según Build Settings)
    public void CargarEscenaPorIndice(int indice)
    {
        SceneManager.LoadScene(indice);
    }

    // Ejemplo: volver a la escena anterior
    public void RecargarEscenaActual()
    {
        Scene escenaActual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escenaActual.name);
    }
}
