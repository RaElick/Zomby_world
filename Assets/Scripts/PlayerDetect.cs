using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDetect : MonoBehaviour
{

    public float radius = 20f, attack = 5f;
    public int damage = 5, prtDamage = 0;
    private NavMeshAgent agent;
    private Coroutine coroutine;
    private Animator anim;
    private EnemyHealth eHealth;
    public Protection prt;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        eHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (eHealth.death)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
                enabled = true;
            }
            return;
        }

        DetectCollision();
        DetectAttack();
        NewPath();
    }

    private void DetectAttack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attack);

        bool isFoundPlayer = false;
        foreach (var el in hitColliders)
        {
            if (el.CompareTag("Player") && coroutine == null)
            {
                coroutine = StartCoroutine(SetDamage(el));
                anim.SetBool("IsAttack", true);
            }

            if (el.CompareTag("Player"))
                isFoundPlayer = true;
        }

        if (!isFoundPlayer && coroutine != null)
        {
            anim.SetBool("IsAttack", false);
            StopCoroutine(coroutine);
            coroutine = null;
        }

    }

    IEnumerator SetDamage(Collider player)
    {
        while (true)
        {
            if (prt.isProtected)
            {
                player.GetComponent<PlayerHealth>().TakeDamage(prtDamage);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                player.GetComponent<PlayerHealth>().TakeDamage(damage);
                yield return new WaitForSeconds(1f);
            }
        }
    }

    private void NewPath()
    {
        if (!agent.hasPath)
            GetComponent<MoveAgents>().SetNewPath();
    }

    private void DetectCollision()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (var el in hitColliders)
        {
            if (el.CompareTag("Player"))
                agent.SetDestination(el.transform.GetChild(0).transform.position);
        }
    }


}
