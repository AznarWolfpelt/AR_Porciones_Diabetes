using UnityEngine;

public class BotonSimple : MonoBehaviour
{
    public AlimentoData misDatos; 
    public TarjetaDetalleUI miTarjeta; 

    public void AlPresionar()
    {
        miTarjeta.Mostrar(misDatos);
    }
}