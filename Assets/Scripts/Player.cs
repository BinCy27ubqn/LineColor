using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ParticleSystem par;

    public GameObject[] parDead;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacles"))
        {
            UiGameManager.Instance.isGameOver = true;

            foreach(var i in parDead)
            {
                i.SetActive(true);
            }

            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("GameWin"))
        {
            UiGameManager.Instance.isGameWin = true;
        }

        if (other.gameObject.CompareTag("chessRegion"))
        {
            AnimationManager.Instance.PlayAnim(AnimationManager.Instance.chessAnimation);
            LevelManager.Instance.levelCompleted = true;
        }
    }

    
}
