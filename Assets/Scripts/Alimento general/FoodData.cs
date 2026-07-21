using UnityEngine;

[CreateAssetMenu(fileName = "FoodData", menuName = "Food/Food Data")]
public class FoodData : ScriptableObject
{
    [Header("Test")]
    public int recommendedPortionIndex;

    [Header("Basic Info")]
    public string foodName;
    public Sprite foodImage;

    [Header("Etiquetas flotantes")]
    public string[] portionDisplayNames = new string[4];
    public float[] portionWeights = new float[4];

    [Header("Biblioteca")]
    public GlycemicLevel glycemicLevel;

    [TextArea]
    public string libraryTips;

    [Header("Categoría")]
    public FoodCategory category;

    public enum GlycemicLevel
{
    Bajo,
    Medio,
    Alto
}

    public enum FoodCategory
    {
        Cereales,
        Legumbres,
        Verduras,
        Frutas,
        Proteinas,
        Lacteos,
        Otros
    }

    [TextArea]
    public string[] portionInfo = new string[4];

    public PortionLevel[] portionLevels = new PortionLevel[4];

    public enum PortionLevel
    {
        Recommended,
        Acceptable,
        Moderate,
        NotRecommended
    }

    [Header("Food Models")]
    public string[] portionObjectNames = new string[4];
    
}