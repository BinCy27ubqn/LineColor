using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiGameManager : MonoBehaviour
{
    public static UiGameManager Instance;

    public GameObject gameCompletePanelUi;
    public GameObject gameOverPanelUi;

    public bool isGameWin;
    public bool isGameOver;

    private float coinCollect = 0;
    public Text coinCollectionText;

    public GameObject animationCoinCollect;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        
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
        StartCoroutine(CoinCollection());
    }

    public void GameOver()
    {
        
        gameOverPanelUi.SetActive(true);
    }

    public void Claim()
    {
        animationCoinCollect.SetActive(true);
        Invoke("LoadScene",2f);
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

    public IEnumerator CoinCollection()
    {
        while(coinCollect < 50)
        { 
            coinCollect++;
            coinCollectionText.text = "<b>+" + coinCollect.ToString() + "</b>";
            yield return new WaitForSeconds(0.2f);
        }
    }
}
