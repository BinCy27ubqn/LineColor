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

    public Renderer playerRenderer;
    public ParticleSystem playerMovementParticle;
    public ParticleSystem playerDeadParticle;
    public ParticleSystem playerDead1Particle;
    public TrailRenderer trailColer;
    public Image sliderColor;
    public SpriteRenderer waterColor;
    

    public LevelData levels;

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

        int ran = Random.Range(0, 4);

        playerRenderer.material = levels.playerMaterial[ran];
        levels.sliderColor.color = levels.playerColor[ran];
        var renderer = playerDeadParticle.GetComponent<ParticleSystemRenderer>();
        renderer.material = levels.playerMaterial[ran];
        var renderer1 = playerDead1Particle.GetComponent<ParticleSystemRenderer>();
        renderer1.material = levels.playerMaterial[ran];
        trailColer.material = levels.playerMaterial[ran];
        waterColor.sprite = levels.spriteWater[ran].sprite;
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
