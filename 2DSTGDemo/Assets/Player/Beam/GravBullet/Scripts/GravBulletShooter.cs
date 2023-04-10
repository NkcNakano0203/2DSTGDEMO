using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravBulletShooter : MonoBehaviour
{
    [SerializeField]
    GravController gravController;

    [SerializeField]
    float shotSpeed = 1;

    bool canShot => gravController.CanFire;

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.H)) return;
        if (!canShot) return;
        gravController.OnFire(shotSpeed);
    }
}