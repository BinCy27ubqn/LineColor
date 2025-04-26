using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public float distanceValue;
    public float currentDistance = 0;

    public Slider levelSlider;

    public bool levelCompleted = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;

        levelSlider.maxValue = distanceValue;
        levelSlider.minValue = 0;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) || (levelCompleted == false && UiGameManager.Instance.isGameWin == true))
        {
            currentDistance += Time.deltaTime;
            levelSlider.value = currentDistance;
        }
    }
}
