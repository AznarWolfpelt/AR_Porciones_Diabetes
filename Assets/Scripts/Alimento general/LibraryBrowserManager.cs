using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LibraryBrowserManager : MonoBehaviour
{
    [Header("Food")]
    public List<FoodData> allFoods;

    [Header("Manager")]
    public LibraryManager libraryManager;

    [Header("Prefabs")]
    public GameObject categoryButtonPrefab;
    public GameObject foodButtonPrefab;

    [Header("UI")]
    public Transform content;

    [Header("Navigation")]
    public GameObject backButton;

    void Start()
    {
        ShowCategories();
    }

    public void ShowCategories()
    {
        ClearContent();

        if (backButton != null)
            backButton.SetActive(false);

        var categories = allFoods
            .Select(f => f.category)
            .Distinct();

        foreach (var category in categories)
        {
            GameObject obj =
                Instantiate(categoryButtonPrefab, content);

            CategoryButtonUI button =
                obj.GetComponent<CategoryButtonUI>();

            button.Setup(category, this);
        }
    }

    public void ShowFoods(FoodData.FoodCategory category)
    {
        ClearContent();

        if (backButton != null)
            backButton.SetActive(true);

        foreach (FoodData food in allFoods)
        {
            if (food.category != category)
                continue;

            GameObject obj =
                Instantiate(foodButtonPrefab, content);

            FoodButtonUI button =
                obj.GetComponent<FoodButtonUI>();

            button.Setup(food, libraryManager);
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