using System;
using UnityEngine.SceneManagement;

public class BossMalignance : Malignance
{
    private void Awake()
    {
        Reset();
    }

    protected override void FinishWork()
    {
        SceneManager.LoadScene("WinScene");
    }
}