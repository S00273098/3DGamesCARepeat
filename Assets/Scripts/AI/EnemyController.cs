using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public Transform[] patrolPoints;
    public float detectionRange = 10f;
    public float attackRange = 2f;
    public float fieldOfView = 120f;
    [HideInInspector]
    public NavMeshAgent agent;

    private IAIState currentState;

    private PatrolState patrolState;
    private ChaseState chaseState;
    private AttackState attackState;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        patrolState = new PatrolState(this);
        chaseState = new ChaseState(this);
        attackState = new AttackState(this);
    }

    private void Start()
    {
        ChangeState(patrolState);
    }

    private void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(IAIState newState)
    {
        currentState?.Exit();

        currentState = newState;

        currentState.Enter();
    }

    public bool CanSeePlayer()
    {
        if (player == null)
            return false;

        Vector3 directionToPlayer =
            player.position - transform.position;

        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer > detectionRange)
            return false;

        directionToPlayer.Normalize();

        float angle = Vector3.Angle(
            transform.forward,
            directionToPlayer
        );

        if (angle > fieldOfView / 2f)
            return false;

        Vector3 rayOrigin = transform.position + Vector3.up * 1f;

        if (Physics.Raycast(
            rayOrigin,
            directionToPlayer,
            out RaycastHit hit,
            detectionRange))
        {
            if (hit.transform == player)
            {
                return true;
            }
        }

        return false;
    }

    public float DistanceToPlayer()
    {
        return Vector3.Distance(
            transform.position,
            player.position
        );
    }

    public PatrolState PatrolState => patrolState;
    public ChaseState ChaseState => chaseState;
    public AttackState AttackState => attackState;
}