using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FoodBrowserManager : MonoBehaviour
{
    [Header("Navigation")]
    public GameObject backButton;

    [Header("Food")]
    public List<FoodData> allFoods;

    [Header("Managers")]
    public FoodManager foodManager;

    [Header("Prefabs")]
    public GameObject categoryButtonPrefab;
    public GameObject foodButtonPrefab;

    [Header("UI")]
    public Transform content;

    private FoodData.FoodCategory currentCategory;

    void Start()
    {
        ShowCategories();
    }

    public void ShowCategories()
    {
        backButton.SetActive(false);
        ClearContent();

        var categories = allFoods
            .Select(f => f.category)
            .Distinct();

        foreach (var category in categories)
        {
            GameObject obj = Instantiate(categoryButtonPrefab, content);

            CategoryButtonUI button =
                obj.GetComponent<CategoryButtonUI>();

            button.Setup(category, this);
        }
    }

    public void ShowFoods(FoodData.FoodCategory category)
    {
        backButton.SetActive(true);
        currentCategory = category;

        ClearContent();

        foreach (FoodData food in allFoods)
        {
            if (food.category != category)
                continue;

            GameObject obj =
                Instantiate(foodButtonPrefab, content);

            FoodButtonUI button =
                obj.GetComponent<FoodButtonUI>();

            button.Setup(food, foodManager);
        }
    }

    void ClearContent()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
}