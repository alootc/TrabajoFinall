using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCEnemigos : MonoBehaviour
{
    public Grafonodirigido nodo;
    public NavMeshAgent agent;

    [Header("Field Vision")]
    public Transform target;
    public float view_radius;
    [Range(45, 120)] public float view_angle = 75;
    public float rotation_speed;

    private void Start()
    {
        agent.SetDestination(nodo.gameObject.transform.position);
    }

    private void Update()
    {
        Vector2 p1 = new (transform.position.x, transform.position.x);
        Vector2 p2 = new (nodo.transform.position.x, nodo.transform.position.x);

        if(Vector3.Distance(p1, p2) < 0.5f)
        {
            nodo = nodo.GetNodeRandom();
            agent.SetDestination(nodo.transform.position);
        }
    }

    private bool IsTargetInsideFOV()
    {
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

        if (angleToTarget < view_angle / 2)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            return distance < view_radius;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, view_radius);

        Gizmos.color = IsTargetInsideFOV() ? Color.green : Color.red;;
        Vector3 viewAngleA = DirFromAngle(-view_angle / 2);
        Vector3 viewAngleB = DirFromAngle(view_angle / 2);

        Gizmos.DrawLine(transform.position, transform.position + viewAngleA * view_radius);
        Gizmos.DrawLine(transform.position, transform.position + viewAngleB * view_radius);
    }
     
    private Vector3 DirFromAngle(float angle)
    {
        angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad),0, Mathf.Cos(angle*Mathf.Deg2Rad));

    }
}
