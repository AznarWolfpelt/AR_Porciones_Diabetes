using UnityEngine;

[CreateAssetMenu(fileName = "FoodData", menuName = "Food/Food Data")]
public class FoodData : ScriptableObject
{
    [Header("Test")]
    public int recommendedPortionIndex;

    [Header("Basic Info")]
    public string foodName;
    public Sprite foodImage;

    [TextArea]
    public string[] portionInfo = new string[4];

    public PortionLevel[] portionLevels = new PortionLevel[4];

    public enum PortionLevel
    {
        Recommended,
        Moderate,
        NotRecommended
    }

    [Header("Food Models")]
    public string[] portionObjectNames = new string[4];
}