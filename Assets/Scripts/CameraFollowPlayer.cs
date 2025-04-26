using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
 

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 29.5f, player.transform.position.z -7);

        if (UiGameManager.Instance.isGameWin)
        {
            transform.Rotate(0, 0, 2 * Time.deltaTime);
        }
    }
}
