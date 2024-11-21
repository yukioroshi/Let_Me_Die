using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }

    public  Animator animator;
    public float delay = 0.3f;
    private bool attackBlocked;

    private void Update()
    {
        transform.right = (PointerPosition-(Vector2)transform.position).normalized;
    }

    public void Attack()
    {
        if (attackBlocked) 
            return;
        animator.SetTrigger("Attack");
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
}
