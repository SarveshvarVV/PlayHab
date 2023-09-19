using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameControllerAlien : MonoBehaviour
{
    [SerializeField] GameObject complete;

    [SerializeField] private List<Alien> hogs;
    [SerializeField] private Text timerText;
    [SerializeField] private Text scoreText; // Add a reference to the Score UI Text component.
    [SerializeField] private TMPro.TextMeshProUGUI finScoreDisplay;
    private HashSet<Alien> currentHogs = new HashSet<Alien>();
    int prevIndex = 0;

    // Add timer variables
    private float timer = 30f;
    private bool isGameActive = true;

    private float finalScore;

    private float score = 0;

    private void Start()
    {
        // Hide all the visible hogs.
        for (int i = 0; i < hogs.Count; i++)
        {
            hogs[i].Hide();
            hogs[i].SetIndex(i);
        }
        // Remove any old game state.
        currentHogs.Clear();
        scoreText.text = "0";
    }

    public void Update()
    {
        if (isGameActive)
        {
            // Update the timer
            timer -= Time.deltaTime;

            // Check if the timer has reached 0
            if (timer <= 0f)
            {
                // Game over logic here
                isGameActive = false;
                finalScore = score;
                finScoreDisplay.text = $"{finalScore}";
                complete.SetActive(true);
                Debug.Log("Game Over");
            }

            timerText.text = $"{(int)timer % 60:D2}";

            if (currentHogs.Count <= 0.5)
            {
                // Choose a random hog.
                int index = Random.Range(0, hogs.Count);
                if (!currentHogs.Contains(hogs[index]) && hogs[index] != hogs[prevIndex])
                {
                    currentHogs.Add(hogs[index]);
                    hogs[index].Activate();
                    prevIndex = index;
                }
            }
        }
    }

    public void Whacked(int hogIndex)
    {
        score++;
        Debug.Log(score);
        scoreText.text = $"{score}";
        currentHogs.Remove(hogs[hogIndex]);
    }

    public void Missed(int hogIndex)
    {
        currentHogs.Remove(hogs[hogIndex]);
    }

    public void BombHit(int hogIndex)
    {
        score -= 2;
        scoreText.text = $"{score}";
        currentHogs.Remove(hogs[hogIndex]);
    }
}
