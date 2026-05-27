using UnityEngine;

public class BotonSalir : MonoBehaviour
{
    // Este método se puede asignar al botón en la UI
    public void SalirJuego()
    {
        // Cierra la aplicación
        Application.Quit();

        // Nota: En el editor de Unity no se verá el cierre,
        // pero en una build sí funciona.
        Debug.Log("El juego se cerraría aquí.");
    }
}
