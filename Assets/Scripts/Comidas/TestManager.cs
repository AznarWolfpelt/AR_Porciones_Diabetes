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
    public TMP_Text questionText;
    public Image foodImage;
    public TMP_Text progressText;

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

        FoodData currentFood = testFoods[currentQuestion];

        questionText.text = "What is the recommended portion?";

        foodImage.sprite = currentFood.foodImage;

        progressText.text =
            "Question " + (currentQuestion + 1) + "/"
            + testFoods.Count;

        ClearPlate();
    }

    public void SelectPortion(int portionIndex)
    {
        selectedPortion = portionIndex;

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
                "✔ " +
                currentFood.foodName +
                " - Correct"
            );
        }
        else
        {
            resultLines.Add(
                "❌ " +
                currentFood.foodName +
                " - Correct answer: " +
                PortionToText(currentFood.recommendedPortionIndex)
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
            case 3: return "Full";

            default: return "";
        }
    }

    string GetFinalMessage(int finalScore)
    {
        switch (finalScore)
        {
            case 5:
                return "Excellent! One step closer to healthy habits.";

            case 4:
                return "Very good job!";

            case 3:
                return "Good effort! Keep practicing.";

            case 2:
                return "Keep learning portion sizes.";

            default:
                return "Try again and keep practicing.";
        }
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