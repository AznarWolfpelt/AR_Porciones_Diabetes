using TMPro;
using UnityEngine;

public class FloatingFoodLabel : MonoBehaviour
{
    public TMP_Text foodName;
    public TMP_Text portionText;
    public TMP_Text weightText;

    public void Setup(string name,
                    string portion,
                    float weight)
    {
        foodName.text = name;
        portionText.text = portion;
        weightText.text = weight.ToString("0.#") + " g";
    }
}