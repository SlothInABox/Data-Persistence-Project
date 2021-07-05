using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoresUIHandler : MonoBehaviour
{
    public Button returnButton;

    [SerializeField] private Text scoreTextPrefab;

    [SerializeField] private float scoreHeightIncrement;

    [SerializeField] private int fontSize;

    // Start is called before the first frame update
    void Start()
    {
        // Add player score text elements
        int playerCount = 0;
        foreach (NameAndScore playerScore in DataManager.instance.highScores)
        {
            Text newScoreText = NewScoreText(); // Make new score text element
            newScoreText.transform.position = new Vector3(newScoreText.transform.position.x, newScoreText.transform.position.y + playerCount * scoreHeightIncrement); // Position element
            newScoreText.text = playerScore.Name + ": " + playerScore.Score;
            playerCount++;
        }
    }

    private Text NewScoreText()
    {
        Text newScoreText = Instantiate(scoreTextPrefab, gameObject.transform);

        newScoreText.color = Color.white;
        newScoreText.fontSize = fontSize;
        newScoreText.alignment = TextAnchor.MiddleCenter;
        newScoreText.horizontalOverflow = HorizontalWrapMode.Overflow;
        newScoreText.verticalOverflow = VerticalWrapMode.Overflow;

        return newScoreText;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
