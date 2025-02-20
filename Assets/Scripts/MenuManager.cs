using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; 

public class MenuManager : MonoBehaviour
{   
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI bestScoreText;

    void Start()
    {
        LoadBestScore();
    }
    public void StartGame()
    {
        PlayerPrefs.SetString("CurrentPlayerName", playerNameInput.text);
        SceneManager.LoadScene(1);
    }

    public void LoadBestScore()
    {
        bestScoreText.text = "BestScore: " + MainGameManager.Instance.bestScore + " Name: " + MainGameManager.Instance.playerName;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
