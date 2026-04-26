using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNopeScene : AppearifyText
{
    [SerializeField]
    private AnimatorSetBool animator;

    [SerializeField]
    private Collider2D collider2D;
    protected override void CommitDisappearing(Collider2D other)
    {
        base.CommitDisappearing(other);
        gameObject.SetActive(true);
        collider2D.enabled = false;
        animator.SetBool(true);
        StartCoroutine("ScrewThis");
    }

    private IEnumerator ScrewThis()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("NopeScene");
    }
}