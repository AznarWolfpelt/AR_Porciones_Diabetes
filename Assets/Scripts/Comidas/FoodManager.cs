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

    [Header("Colores de Estado")]
    public Color recommendedColor = Color.green;
    public Color acceptableColor = new Color(0.4f, 0.8f, 1f);
    public Color moderateColor = Color.yellow;
    public Color notRecommendedColor = Color.red;
    
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
                    recommendedText.text = "Recomendado";
                }

                if (infoPanelBackground != null)
                {
                    infoPanelBackground.color = recommendedColor;
                }

                break;

            case FoodData.PortionLevel.Acceptable:

                if (recommendedText != null)
                {
                    recommendedText.text = "Aceptable";
                }

                if (infoPanelBackground != null)
                {
                    infoPanelBackground.color = acceptableColor;
                }

                break;

            case FoodData.PortionLevel.Moderate:

                if (recommendedText != null)
                {
                    recommendedText.text = "Moderado";
                }

                if (infoPanelBackground != null)
                {
                    infoPanelBackground.color = moderateColor;
                }

                break;

            case FoodData.PortionLevel.NotRecommended:

                if (recommendedText != null)
                {
                    recommendedText.text = "No recomendado";
                }

                if (infoPanelBackground != null)
                {
                    infoPanelBackground.color = notRecommendedColor;
                }

                break;
        }
    }
}