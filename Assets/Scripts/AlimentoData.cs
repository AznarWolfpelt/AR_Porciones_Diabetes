using UnityEngine;

public enum TipoCategoria { Recomendado, Moderado, Precaucion } 

[CreateAssetMenu(fileName = "Nuevo Alimento", menuName = "Nutricion/Alimento")]
public class AlimentoData : ScriptableObject
{
    public string nombre;
    public TipoCategoria categoria;
    public Sprite foto;
    
    [Header("Información por Porción")]
    [TextArea] public string infoUnCuarto;
    [TextArea] public string infoDosCuartos;
    [TextArea] public string infoTresCuartos;
    [TextArea] public string infoPlatoLleno;
}