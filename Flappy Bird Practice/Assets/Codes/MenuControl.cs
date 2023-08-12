using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public Text Scor;
    public Text LastScoreText;
    void Start()
    {
        int highestScor = PlayerPrefs.GetInt("scor");
        int LastScore = PlayerPrefs.GetInt("LastScor");

        Scor.text = "Scor :" + highestScor;
        LastScoreText.text = "Last Score : " + LastScore;
    }

    
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("1");
    }
    public void Out()
    {
        Application.Quit();
    }
}
