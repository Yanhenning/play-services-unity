using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Main : MonoBehaviour
{
    private const string SAVE_NAME = "SAVE_ONE";

    [SerializeField] Button saveLocalButton, loadLocalButton, saveCloudButton, loadCloudButton, incrementButton, decrementButton, resetButton, pipelineButton;
    [SerializeField] TMP_Text scoreText, actionText;
    private GameSave gameSave;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        incrementButton.onClick.AddListener(increaseScore);
        decrementButton.onClick.AddListener(decreaseScore);
        resetButton.onClick.AddListener(resetScore);
        saveLocalButton.onClick.AddListener(saveLocal);
        loadLocalButton.onClick.AddListener(loadLocal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void updateAction(string action)
    {
        actionText.text = action;
    }

    void increaseScore()
    {
        score += 1;
        updateScoreText();
    }

    void decreaseScore()
    {
        score -= 1;
        updateScoreText();
    }

    void resetScore()
    {
        score = 0;
        updateScoreText();
        updateAction("resetScore");
    }

    void loadLocal()
    {
        gameSave = SaveManager.LoadGame(SAVE_NAME);
        if (gameSave != null)
        {
            score = gameSave.score;
            updateScoreText();
        }
        updateAction("loadLocal");
    }

    void saveLocal()
    {
        if (gameSave == null)
        { 
            gameSave = new GameSave();         
        }
        gameSave.score = score;
        gameSave = SaveManager.SaveGame(gameSave, SAVE_NAME);
        updateAction("saveLocal");
    }
}
