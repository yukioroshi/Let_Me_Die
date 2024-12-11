using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }

    public  Animator animator;
    public float delay = 0.3f;
    private bool attackBlocked;

    public bool IsAttacking {  get; private set; }

    public Transform cicrcleOrigin;
    public float radius;

    [SerializeField]
    public int Damage;

    public void ResetIsAttacking()
    {
        IsAttacking = false;
    }

    private void Update()
    {
        if (IsAttacking)
            return;
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        Vector2 scale = transform.localScale;
        if(direction.x < 0)
        {
            scale.y = -1;
        }
        else if(direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;
        
    }

    public void Attack()
    {
        if (attackBlocked) 
            return;
        animator.SetTrigger("Attack");
        IsAttacking = true;
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 position = cicrcleOrigin == null ? Vector3.zero : cicrcleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    public void DetectColliders()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(cicrcleOrigin.position, radius))
        {
            //Debug.Log(collider.name);
            PlayerHealth health;
            if (health = collider.GetComponent<PlayerHealth>())
            {
                health.GetHit(Damage, transform.parent.gameObject);
            }
        }
    }

    public void AttackUpgrade()
    {
        Damage += 1;
        MoneyManager.score -= 30;
    }
}
