using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// J�ŏƎ�
/// </summary>
public class BeamShooter : MonoBehaviour
{
    [SerializeField]
    BeamController beamController;

    bool keyPush = false;

    void Update()
    {
        keyPush = Input.GetKey(KeyCode.J);
    }

    private void FixedUpdate()
    {
        if (keyPush)
        {
            beamController.ShotStart();
        }
        else
        {
            beamController.ShotEnd();
        }
    }
}