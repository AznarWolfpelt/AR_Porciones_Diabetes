using UnityEngine;

public class ControladorMenu : MonoBehaviour
{
    public GameObject panelAlimentos;

    public void AlternarMenu()
    {
        panelAlimentos.SetActive(!panelAlimentos.activeSelf);
    }
}