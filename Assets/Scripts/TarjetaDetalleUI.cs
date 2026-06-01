using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TarjetaDetalleUI : MonoBehaviour
{
    public Image fondoTarjeta;
    public TextMeshProUGUI txtTitulo;
    public Image imagenFoto;
    public TextMeshProUGUI txtInfo;

    [Header("Elige tus Colores")]
    public Color colorRecomendado = Color.green;
    public Color colorModerado = Color.yellow;
    public Color colorPrecaucion = Color.red;

    private AlimentoData alimentoActual; 

    public void Mostrar(AlimentoData datos)
    {
        alimentoActual = datos;
        txtTitulo.text = datos.nombre;
        imagenFoto.sprite = datos.foto;
        
        CambiarPorcion(1); 
        
        // Aquí lee los colores que tú elegiste en Unity
        if (datos.categoria == TipoCategoria.Recomendado) fondoTarjeta.color = colorRecomendado;
        else if (datos.categoria == TipoCategoria.Moderado) fondoTarjeta.color = colorModerado;
        else fondoTarjeta.color = colorPrecaucion;

        gameObject.SetActive(true);
    }

    public void CambiarPorcion(int cuartos)
    {
        if (alimentoActual == null) return;
        
        if (cuartos == 1) txtInfo.text = alimentoActual.infoUnCuarto;
        else if (cuartos == 2) txtInfo.text = alimentoActual.infoDosCuartos;
        else if (cuartos == 3) txtInfo.text = alimentoActual.infoTresCuartos;
        else if (cuartos == 4) txtInfo.text = alimentoActual.infoPlatoLleno;
    }

    public void Cerrar() { gameObject.SetActive(false); }
}