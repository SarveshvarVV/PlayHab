using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Chimp_GameManager : MonoBehaviour
{
    public Transform grid;
    public Color textColor = Color.black; // Text color for the button numbers.
    public int numberOfButtonsToUse = 8; // Number of buttons to assign random numbers.
    private float alphaForUnusedButtons = 0f; // Alpha value for non-numbered buttons.

    private int nextExpectedNumber = 1; // Track the next expected number to be clicked.

    private bool gameOver = false;
    private float timer = 0f;

    bool timeStart = false;
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject LosePanel;

    [SerializeField] GameObject timerText;


    public GameObject pauseMenu;
    public GameObject pauseButtonPanel;

    public GameObject resumeButton;


    private void Start()
    {
        List<Transform> buttonsToUse = AssignRandomNumbersToButtons(numberOfButtonsToUse); // Assign random numbers to random buttons.
        AdjustAlphaForUnusedButtons(buttonsToUse); // Reduce alpha for non-numbered buttons.
        SetupButtonClickEvents(buttonsToUse); // Setup button click events.
    }

    void Update(){
        if (timeStart){
            timer += Time.deltaTime * 1f;
        }
    }
    private List<Transform> AssignRandomNumbersToButtons(int count)
    {
        List<Transform> buttonList = new List<Transform>();

        // Find all child buttons in the grid.
        foreach (Transform cell in grid)
        {
            // Check if the child object's name contains "Chimp_GridButton."
            if (cell.name.Contains("Chimp_GridButton"))
            {
                buttonList.Add(cell);
            }
        }

        // Ensure we have enough buttons to assign numbers.
        if (buttonList.Count < count)
        {
            Debug.LogError("Not enough buttons in the grid to assign numbers.");
            return null;
        }

        // Generate a list of unique random numbers from 1 to 'count'.
        List<int> uniqueRandomNumbers = GenerateUniqueRandomNumbers(1, count);

        // Shuffle the list of all buttons.
        Shuffle(buttonList);

        // Assign unique random numbers to the Text components of the selected buttons.
        for (int i = 0; i < count; i++)
        {
            Transform button = buttonList[i];
            Text buttonText = button.GetComponentInChildren<Text>();

            // Check if a Text component exists before attempting to set the text.
            if (buttonText != null)
            {
                buttonText.text = uniqueRandomNumbers[i].ToString();
                buttonText.color = textColor; // Set the text color.
                buttonText.enabled = true; // Enable the Text component.
            }
            else
            {
                Debug.LogError("Text component not found in button: " + button.name);
            }

            // Find the child Image component and disable it.
            Image buttonImage = button.GetComponentInChildren<Image>();
            if (buttonImage != null)
            {
                buttonImage.enabled = false;
            }
        }

        return buttonList.GetRange(0, count); // Return the list of buttons with assigned numbers.
    }

    private List<int> GenerateUniqueRandomNumbers(int min, int max)
    {
        List<int> numbers = new List<int>();
        for (int i = min; i <= max; i++)
        {
            numbers.Add(i);
        }

        // Shuffle the list to get unique random numbers.
        Shuffle(numbers);

        return numbers;
    }

    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private void AdjustAlphaForUnusedButtons(List<Transform> buttonsToUse)
    {
        // Find all child buttons in the grid.
        foreach (Transform cell in grid)
        {
            // Check if the child object's name contains "Chimp_GridButton."
            if (cell.name.Contains("Chimp_GridButton"))
            {
                Transform button = cell;

                // Check if an Image component exists before attempting to adjust alpha.
                Image buttonImage = button.GetComponentInChildren<Image>();
                if (buttonImage != null)
                {
                    // Check if the button should have reduced alpha.
                    if (!buttonsToUse.Contains(button))
                    {
                        // Adjust the alpha value.
                        buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, alphaForUnusedButtons);
                    }
                }
            }
        }
    }

    private void SetupButtonClickEvents(List<Transform> buttonsToUse)
    {
        foreach (Transform button in buttonsToUse)
        {
            Button buttonComponent = button.GetComponent<Button>();
            buttonComponent.onClick.AddListener(() => OnButtonClick(button));
        }
    }

   private HashSet<Transform> clickedButtons = new HashSet<Transform>(); // Keep track of clicked buttons

public void OnButtonClick(Transform button)
{
    if (gameOver || clickedButtons.Contains(button))
    {
        // Game is over or button has already been clicked, do not process the button click.
        return;
    }

    Text buttonText = button.GetComponentInChildren<Text>();
    Image buttonImage = button.GetComponentInChildren<Image>();

    // Check if the button has text.
    if (buttonText != null)
    {
        int clickedNumber;
        if (int.TryParse(buttonText.text, out clickedNumber))
        {
            if (clickedNumber == nextExpectedNumber)
            {
                // Correct button clicked, increment the expected number.
                nextExpectedNumber++;

                // Mark the button as clicked.
                clickedButtons.Add(button);

                // Check if all buttons have been clicked in order.
                if (nextExpectedNumber > numberOfButtonsToUse)
                {
                    gameOver = true; // Set the game state to "game over."
                    timeStart = false;
                    WinPanel.SetActive(true);
                    timerText.GetComponent<Text>().text = timer.ToString("F2"); // Format the timer with two decimal places
                    resumeButton.SetActive(false);
                }
            }
            else
            {
                // Incorrect button clicked, display "failed" and reset the expected number.
                nextExpectedNumber = 1;
                gameOver = true; // Set the game state to "game over."
                LosePanel.SetActive(true);
                resumeButton.SetActive(false);
            }
        }
    }


    // Loop through all buttons to update their states.
    foreach (Transform cell in grid)
    {
        // Check if the child object's name contains "Chimp_GridButton."
        if (cell.name.Contains("Chimp_GridButton"))
        {
            Transform gridButton = cell;

            Text gridButtonText = gridButton.GetComponentInChildren<Text>();
            Image gridButtonImage = gridButton.GetComponentInChildren<Image>();

            // Check if the button has text.
            if (gridButtonText != null)
            {
                int gridButtonNumber;
                if (int.TryParse(gridButtonText.text, out gridButtonNumber))
                {
                    if (gridButtonNumber == 1)
                    {
                        // Button 1 clicked, keep it as text.
                        gridButtonText.enabled = true;
                        timeStart = true;
                    }
                    else if (gridButtonNumber < nextExpectedNumber)
                    {
                        // Buttons before the clicked number should have their image component enabled.
                        gridButtonText.enabled = true;
                        if (gridButtonImage != null)
                        {
                            gridButtonImage.enabled = false;
                        }
                    }
                    else
                    {
                        // Buttons after the clicked number should have their text component enabled.
                        if (gridButtonText != buttonText)
                        {
                            gridButtonText.enabled = false;
                        }

                        // Buttons after the clicked number should have their image component disabled.
                        if (gridButtonImage != null)
                        {
                            gridButtonImage.enabled = true;
                        }
                    }
                }
            }
        }
    }
}

public void GoToPause() 
{
    pauseButtonPanel.SetActive(false);
    pauseMenu.SetActive(true);
    Time.timeScale = 0;
}

public void ResumeGame(){
    pauseButtonPanel.SetActive(true);
    pauseMenu.SetActive(false);
    Time.timeScale = 1;
}

public void RestartL1() {
    SceneManager.LoadScene("Chimp_L1");
    Time.timeScale = 1;
}

public void RestartL2() {
    SceneManager.LoadScene("Chimp_L2");
    Time.timeScale = 1;
}
public void RestartL3() {
    SceneManager.LoadScene("Chimp_L3");
    Time.timeScale = 1;
}
public void RestartL4() {
    SceneManager.LoadScene("Chimp_L4");
    Time.timeScale = 1;
}
public void RestartL5() {
    SceneManager.LoadScene("Chimp_L5");
    Time.timeScale = 1;
}
public void RestartL6() {
    SceneManager.LoadScene("Chimp_L6");
    Time.timeScale = 1;
}

}