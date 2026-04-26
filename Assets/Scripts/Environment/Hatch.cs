using System;
using UnityEngine;

public class Hatch : Malignance
{
    [SerializeField]
    private GameObject hatch;

    private void Awake()
    {
        Reset();
    }

    protected override void FinishWork()
    {
        gameObject.SetActive(false);
        hatch.SetActive(true);
    }
}