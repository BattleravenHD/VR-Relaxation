using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour
{
    public Light sun;

    private void OnEnable()
    {
        sun.intensity = 0.5f;
    }

    private void OnDisable()
    {
        sun.intensity = 1f;
    }
}
