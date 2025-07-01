using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public float force = 150f, forceTorque = 100f;
    [HideInInspector] public bool death = false;
    [HideInInspector] public bool isCanHeal = true;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(!death)
            transform.GetChild(0).localScale = new Vector3(health / 100f, 0.1f, 0.1f);
        
        if (health <= 0 && !death)
        {
            death = true;
            Destroy(transform.GetChild(0).gameObject);
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.up * force);
            rb.AddTorque(Vector3.back * forceTorque);
            GetComponent<MoveAgents>().enabled = false;
            GetComponent<Animator>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
        }
    }
}
