using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategoryButtonUI : MonoBehaviour
{
    public TMP_Text categoryNameText;
    public Button button;
    public Image background;

    private FoodData.FoodCategory category;
    
    private FoodBrowserManager foodBrowser;
    private LibraryBrowserManager libraryBrowser;

    public void Setup(
        FoodData.FoodCategory newCategory,
        FoodBrowserManager manager)
    {
        category = newCategory;
        foodBrowser = manager;
        categoryNameText.text = GetCategoryName(category);

        background.color = GetCategoryColor(category);
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClick);
    }

    public void Setup
        (FoodData.FoodCategory newCategory,
        LibraryBrowserManager manager)
    {
        category = newCategory;
        libraryBrowser = manager;
        categoryNameText.text = GetCategoryName(category);

        background.color = GetCategoryColor(category);
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (foodBrowser != null)
            foodBrowser.ShowFoods(category);

        if (libraryBrowser != null)
            libraryBrowser.ShowFoods(category);
    }

    string GetCategoryName(FoodData.FoodCategory category)
    {
        switch(category)
        {
            case FoodData.FoodCategory.Cereales:
                return "Cereales";

            case FoodData.FoodCategory.Legumbres:
                return "Legumbres";

            case FoodData.FoodCategory.Verduras:
                return "Verduras";

            case FoodData.FoodCategory.Frutas:
                return "Frutas";

            case FoodData.FoodCategory.Proteinas:
                return "Proteínas";

            case FoodData.FoodCategory.Lacteos:
                return "Lácteos";

            default:
                return "Otros";
        }
    }
        Color GetCategoryColor(FoodData.FoodCategory category)
    {
        switch(category)
        {
            case FoodData.FoodCategory.Cereales:
                return new Color(0.96f, 0.87f, 0.66f);

            case FoodData.FoodCategory.Legumbres:
                return new Color(0.73f, 0.56f, 0.43f);

            case FoodData.FoodCategory.Verduras:
                return new Color(0.60f, 0.85f, 0.60f);

            case FoodData.FoodCategory.Frutas:
                return new Color(1f, 0.78f, 0.45f);

            case FoodData.FoodCategory.Proteinas:
                return new Color(0.93f, 0.67f, 0.67f);

            case FoodData.FoodCategory.Lacteos:
                return new Color(0.72f, 0.86f, 1f);

            default:
                return Color.gray;
        }
    }
}