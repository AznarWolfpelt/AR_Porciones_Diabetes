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

    public void Setup(FoodData data, FoodManager manager)
    {
        foodData = data;
        foodManager = manager;

        foodNameText.text = data.foodName;
        foodImage.sprite = data.foodImage;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        Debug.Log("Click en: " + foodData.foodName);
        foodManager.SelectFood(foodData);
    }
}