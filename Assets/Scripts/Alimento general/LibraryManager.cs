using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LibraryManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject infoPanel;

    [Header("UI")]
    public TMP_Text titleText;
    public Image foodImage;
    public TMP_Text infoText;
    public TMP_Text tipsText;
    public TMP_Text glycemicText;
    public Image infoPanelBackground;

    [Header("Colores")]
    public Color lowColor = Color.green;
    public Color mediumColor = Color.yellow;
    public Color highColor = Color.red;

    private FoodData currentFood;

    public void SelectFood(FoodData food)
    {
        currentFood = food;

        if (infoPanel != null)
            infoPanel.SetActive(true);

        ShowFood();
    }

    void ShowFood()
    {
        // UI
        if (titleText != null)
            titleText.text = currentFood.foodName;

        if (foodImage != null)
            foodImage.sprite = currentFood.foodImage;

        if (infoText != null)
            infoText.text = currentFood.portionInfo[0];

        if (tipsText != null)
            tipsText.text = currentFood.libraryTips;

        switch (currentFood.glycemicLevel)
        {
            case FoodData.GlycemicLevel.Bajo:

                if (glycemicText != null)
                    glycemicText.text = "Nivel glucémico: Bajo";

                if (infoPanelBackground != null)
                    infoPanelBackground.color = lowColor;

                break;

            case FoodData.GlycemicLevel.Medio:

                if (glycemicText != null)
                    glycemicText.text = "Nivel glucémico: Medio";

                if (infoPanelBackground != null)
                    infoPanelBackground.color = mediumColor;

                break;

            case FoodData.GlycemicLevel.Alto:

                if (glycemicText != null)
                    glycemicText.text = "Nivel glucémico: Alto";

                if (infoPanelBackground != null)
                    infoPanelBackground.color = highColor;

                break;
        }
    }
}