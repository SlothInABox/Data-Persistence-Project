using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance; // Singleton instance

    public string playerName; // Name entered by player
    public List<NameAndScore> highScores = new List<NameAndScore>();

    private void Awake()
    {
        if (instance != null)
        {
            // Remove if singleton already exists
            Destroy(gameObject);
            return;
        }
        instance = this; // Initialize singleton instance
        DontDestroyOnLoad(gameObject);

        LoadScores(); // Load save data
    }

    public void AddScore(string name, int score)
    {
        NameAndScore newScore = new NameAndScore(name, score); // New name and score struct
        highScores.Add(newScore); // Add new score to list of scores

        highScores.Sort((a, b) => b.Score.CompareTo(a.Score)); // Sort by score values

        // Keep the top 10 scores
        if (highScores.Count > 10)
        {
            highScores = highScores.GetRange(0, 10);
        }
    }

    [System.Serializable]
    class SaveData
    {
        public List<string> names = new List<string>();
        public List<int> scores = new List<int>();
    }

    public void SaveScores()
    {
        SaveData data = new SaveData();
        foreach (NameAndScore playerScore in highScores)
        {
            data.names.Add(playerScore.Name);
            data.scores.Add(playerScore.Score);
        }

        string json = JsonUtility.ToJson(data); // Transform instance to json

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            highScores.Clear(); // Ensure highscores are empty

            SaveData data = JsonUtility.FromJson<SaveData>(json); // Transform into save data instance
            for (int i = 0; i < data.names.Count; i++)
            {
                NameAndScore playerScore = new NameAndScore(data.names[i], data.scores[i]);
                highScores.Add(playerScore);
            }

            highScores.Sort((a, b) => b.Score.CompareTo(a.Score)); // Ensure scores are sorted
        }
    }
}
