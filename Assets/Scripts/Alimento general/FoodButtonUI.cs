using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodButtonUI : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text foodNameText;
    public Image foodImage;
    public Button button;

    private FoodData foodData;

    private FoodManager foodManager;
    private LibraryManager libraryManager;

    public void Setup(FoodData data, FoodManager manager)
    {
        foodData = data;
        foodManager = manager;
        libraryManager = null;

        foodNameText.text = data.foodName;
        foodImage.sprite = data.foodImage;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnButtonClicked);
    }

    public void Setup(FoodData data, LibraryManager manager)
    {
        foodData = data;
        libraryManager = manager;
        foodManager = null;

        foodNameText.text = data.foodName;
        foodImage.sprite = data.foodImage;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        if (foodManager != null)
        {
            foodManager.SelectFood(foodData);
        }

        if (libraryManager != null)
        {
            libraryManager.SelectFood(foodData);
        }
    }
}