using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCharacter : MonoBehaviour
{
    public float rotateAngle;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, rotateAngle * Time.deltaTime, 0);
    }
}
