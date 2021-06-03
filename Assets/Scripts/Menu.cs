using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text bestScoreText;
    public InputField inputName;
    public static string playerName;
    public static string bestPlayer = string.Empty;
    public static int bestScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        ShowBestScore();
    }

    public void StartGame()
    {
        playerName = inputName.text == string.Empty ? "Joe" : inputName.text;
        SceneManager.LoadScene(1);
    }

    private void ShowBestScore()
    {
        string path = Application.persistentDataPath + "/bestScore.json";
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<Save>(json);
            bestPlayer = data.playerName;
            bestScore = data.score;
            bestScoreText.text = "Best Score: " + bestPlayer + ": " + bestScore;
        }        
    }
}
