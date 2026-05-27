using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text titleText;
    public Image foodImage;
    public TMP_Text infoText;
    public TMP_Text recommendedText;
    public Image infoPanelBackground;

    [Header("Current Food")]
    public FoodData currentFood;
    
    public Transform foodAnchor;
    private int currentPortion = 0;

    public void SelectFood(FoodData food)
    {
        currentFood = food;

        // Mostrar porción recomendada (1/4 por defecto)
        ShowPortion(0);
    }

    public void ShowPortion(int portionIndex)
    {
        currentPortion = portionIndex;

        // Apagar todos los modelos
        for (int i = 0; i < foodAnchor.childCount; i++)
        {
            foodAnchor.GetChild(i).gameObject.SetActive(false);
        }

        Transform selectedFood = foodAnchor.Find(currentFood.portionObjectNames[portionIndex]);

        if (selectedFood != null)
        {
            selectedFood.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("NO ENCONTRADO");
        }

        // Actualizar UI
        titleText.text = currentFood.foodName;

        foodImage.sprite = currentFood.foodImage;

        infoText.text = currentFood.portionInfo[portionIndex];

            switch ((FoodData.PortionLevel)currentFood.portionLevels[portionIndex])
        {
            case FoodData.PortionLevel.Recommended:

                recommendedText.text = "Recommended";
                infoPanelBackground.color = Color.green;

                break;

            case FoodData.PortionLevel.Moderate:

                recommendedText.text = "Moderate";
                infoPanelBackground.color = Color.yellow;

                break;

            case FoodData.PortionLevel.NotRecommended:

                recommendedText.text = "Not Recommended";
                infoPanelBackground.color = Color.red;

                break;
        }
    }
}