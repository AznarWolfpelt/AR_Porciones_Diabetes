using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    [Header("Managers")]
    public FoodManager foodManager;

    [Header("Food List")]
    public List<FoodData> allFoods;

    private List<FoodData> testFoods = new List<FoodData>();

    [Header("Question UI")]
    public TMP_Text foodNameText;
    public TMP_Text questionText;
    public Image foodImage;
    public TMP_Text progressText;
    public Button confirmButton;

    [Header("Result UI")]
    public GameObject resultPanel;
    public TMP_Text resultScoreText;
    public TMP_Text resultDetailsText;
    public TMP_Text finalMessageText;

    private int currentQuestion = 0;
    private int score = 0;

    private int selectedPortion = -1;

    private List<string> resultLines = new List<string>();

    void Start()
    {
        StartTest();
    }

    void StartTest()
    {
        resultPanel.SetActive(false);

        testFoods = new List<FoodData>(allFoods);

        ShuffleList(testFoods);

        if (testFoods.Count > 5)
        {
            testFoods = testFoods.GetRange(0, 5);
        }

        currentQuestion = 0;
        score = 0;

        ShowQuestion();
    }

    void ShowQuestion()
    {
        selectedPortion = -1;
        confirmButton.interactable = false;

        FoodData currentFood = testFoods[currentQuestion];
        foodNameText.text = currentFood.foodName;

        questionText.text = "¿Cuál es la porción recomendada?";

        foodImage.sprite = currentFood.foodImage;

        progressText.text =
            "Pregunta " + (currentQuestion + 1) + "/"
            + testFoods.Count;

        ClearPlate();
    }

    public void SelectPortion(int portionIndex)
    {
        selectedPortion = portionIndex;
        confirmButton.interactable = true;

        foodManager.SelectFood(testFoods[currentQuestion]);

        foodManager.ShowPortion(portionIndex);
    }

    public void ConfirmAnswer()
    {
        if (selectedPortion == -1)
            return;

        FoodData currentFood = testFoods[currentQuestion];

        bool correct =
            selectedPortion ==
            currentFood.recommendedPortionIndex;

        if (correct)
        {
            score++;

            resultLines.Add(
                "<color=green>" +
                currentFood.foodName +
                " - Correcto</color>"
            );
        }
        else
        {
            resultLines.Add(
                "<color=red>" +
                currentFood.foodName +
                " - Incorrecto</color>" +
                " (Respuesta correcta: " +
                PortionToText(currentFood.recommendedPortionIndex) +
                ")"
            );
        }

        currentQuestion++;

        if (currentQuestion >= testFoods.Count)
        {
            ShowResults();
        }
        else
        {
            ShowQuestion();
        }
    }

    void ShowResults()
    {
        resultPanel.SetActive(true);

        resultScoreText.text =
            score + "/" + testFoods.Count;

        resultDetailsText.text =
            string.Join("\n", resultLines);

        finalMessageText.text =
            GetFinalMessage(score);
    }

    void ClearPlate()
    {
        if (foodManager.foodAnchor == null)
            return;

        for (int i = 0; i < foodManager.foodAnchor.childCount; i++)
        {
            foodManager.foodAnchor
                .GetChild(i)
                .gameObject
                .SetActive(false);
        }
    }

    string PortionToText(int index)
    {
        switch (index)
        {
            case 0: return "1/4";
            case 1: return "2/4";
            case 2: return "3/4";
            case 3: return "1";

            default: return "";
        }
    }

    string GetFinalMessage(int finalScore)
    {
        float percentage = (float)finalScore / testFoods.Count;

        if (percentage == 1f)
        {
            return "¡Excelente trabajo!\nHas identificado correctamente todas las porciones recomendadas.";
        }

        if (percentage >= 0.75f)
        {
            return "¡Muy buen trabajo!\nReconoces la mayoría de las porciones recomendadas.";
        }

        if (percentage >= 0.5f)
        {
            return "¡Buen esfuerzo!\nYa identificas varias porciones correctamente.";
        }

        if (percentage >= 0.25f)
        {
            return "Sigue practicando.\nReconocer las porciones adecuadas toma tiempo.";
        }

        return "No te desanimes.\nCada intento ayuda a aprender.";
    }

    void ShuffleList(List<FoodData> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            FoodData temp = list[i];

            int randomIndex =
                Random.Range(i, list.Count);

            list[i] = list[randomIndex];

            list[randomIndex] = temp;
        }
    }
}