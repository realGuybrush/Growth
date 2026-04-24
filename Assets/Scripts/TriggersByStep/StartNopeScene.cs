using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNopeScene : AppearifyText
{
    [SerializeField]
    private AnimatorSetBool animator;
    protected override void CommitDisappearing()
    {
        base.CommitDisappearing();
        gameObject.SetActive(true);
        animator.SetBool();
        StartCoroutine("ScrewThis");
    }

    private IEnumerator ScrewThis()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("NopeScene");
    }
}