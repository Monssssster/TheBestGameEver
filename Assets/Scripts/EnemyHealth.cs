using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator animator;

    public Explosion explosionPrefab;

    public bool IsAlive()
    {
        return value > 0;
    }

    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            Death();
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }

    private void Death()
    {
        animator.SetTrigger("death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        MobExpolion();
    }

    private void MobExpolion()
    {
        if(explosionPrefab == null) return;
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;        
    }


}
