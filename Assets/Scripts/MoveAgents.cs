using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MoveAgents : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] points;
    private Transform nowPoint;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNewPath();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Point"))
            SetNewPath();
    }

    public void SetNewPath()
    {
        Transform moveTo = points[Random.Range(0, points.Length)];
        if (nowPoint != null && moveTo.position == nowPoint.position)
        {
            SetNewPath();
            return;
        }

        nowPoint = moveTo;
        agent.SetDestination(nowPoint.position);
    }
}
