using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiGameManager : MonoBehaviour
{
    public static UiGameManager Instance;

    public GameObject gameCompletePanelUi;
    public GameObject gameOverPanelUi;

    public bool isGameWin;
    public bool isGameOver;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (isGameOver)
        {
            StartCoroutine(ShowUIGame(1));
        }
        if (isGameWin)
        {
            StartCoroutine(ShowUIGame(6));
        }
    }

    public void GameComplete()
    {
        gameCompletePanelUi.SetActive(true);
    }

    public void GameOver()
    {
        
        gameOverPanelUi.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Level_01");
    }

    public IEnumerator ShowUIGame(int time)
    {
        yield return new WaitForSeconds(time);

        if (isGameWin)
        {
            GameComplete();
        }
        else if (isGameOver)
        {
            GameOver();
        }
    }
}
