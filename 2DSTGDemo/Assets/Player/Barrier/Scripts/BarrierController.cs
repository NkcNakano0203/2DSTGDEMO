using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// K‚ÅƒoƒŠƒA“WŠJ
/// </summary>
public class BarrierController : MonoBehaviour
{
    [SerializeField]
    float openTime = 2;

    [SerializeField]
    BarrierImageController imageController;

    bool isOpen = false;

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.K)) return;
        if (isOpen) return;

        imageController.Open();
        StartCoroutine(OpenTimer());
        isOpen = true;
    }

    IEnumerator OpenTimer()
    {
        yield return new WaitForSeconds(openTime);
        imageController.Close();
        isOpen = false;
    }
}