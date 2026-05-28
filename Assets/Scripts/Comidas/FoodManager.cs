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
        if(titleText != null)
        {
            titleText.text = currentFood.foodName;
        }

        if(foodImage != null)
        {
            foodImage.sprite = currentFood.foodImage;
        }

        if(infoText != null)
        {
            infoText.text = currentFood.portionInfo[portionIndex];
        }

        switch (currentFood.portionLevels[portionIndex])
        {
            case FoodData.PortionLevel.Recommended:

                if (recommendedText != null)
                {
                    recommendedText.text = "Recommended";
                }

                if (infoPanelBackground != null)
                {
                    infoPanelBackground.color = Color.green;
                }

                break;

            case FoodData.PortionLevel.Moderate:

                if (recommendedText != null)
                {
                    recommendedText.text = "Moderate";
                }

                if (infoPanelBackground != null)
                {
                    infoPanelBackground.color = Color.yellow;
                }

                break;

            case FoodData.PortionLevel.NotRecommended:

                if (recommendedText != null)
                {
                    recommendedText.text = "Not Recommended";
                }

                if (infoPanelBackground != null)
                {
                    infoPanelBackground.color = Color.red;
                }

                break;
        }
    }
}