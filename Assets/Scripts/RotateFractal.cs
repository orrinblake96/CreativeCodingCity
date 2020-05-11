using System;
using UnityEngine;

public class RotateFractal : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, 10 * Time.deltaTime, 0);
    }
}
