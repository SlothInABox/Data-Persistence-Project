using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public InputField nameInputField;

    // Start is called before the first frame update
    void Start()
    {
        // Listen to text input field and invoke method when text changes
        nameInputField.onValueChanged.AddListener(delegate { NewNameEntered(); });
    }

    // Invoked when the value of the text field changes
    public void NewNameEntered()
    {
        DataManager.instance.playerName = nameInputField.text;
    }

    public void StartNew()
    {
        if (nameInputField.text != "")
        {
            SceneManager.LoadScene(1); // Load main scene
        }
    }

    public void ToHighScores()
    {
        SceneManager.LoadScene(2); // Load high scores scene
    }

public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
