using UnityEngine;

public class AnimatorSetBool : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void SetBool(bool value)
    {
        //Yes, it cannot be done via UI. Who could've known?
        animator.SetBool("On", value);
    }
}