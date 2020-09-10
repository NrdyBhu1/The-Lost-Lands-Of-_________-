using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    #region Variables
    public Rigidbody sunLight;
    #endregion
    void Update()
    {
        Quaternion moveRotation = new Quaternion(sunLight.rotation.x + ((Time.deltaTime / 2) * 100f), -30f, 0f, 1f);
        moveRotation = moveRotation.normalized;
        sunLight.MoveRotation(moveRotation);
    }
}
