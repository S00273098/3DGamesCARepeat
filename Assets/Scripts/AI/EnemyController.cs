using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public Transform[] patrolPoints;
    public EnemyData enemyData;

    [HideInInspector]
    public NavMeshAgent agent;

    private IAIState currentState;

    private PatrolState patrolState;
    private ChaseState chaseState;
    private AttackState attackState;
    private DeadState deadState;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        patrolState = new PatrolState(this);
        chaseState = new ChaseState(this);
        attackState = new AttackState(this);
        deadState = new DeadState(this);
    }

    private void Start()
    {
        agent.speed = enemyData.movementSpeed;

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

        if (distanceToPlayer > enemyData.detectionRange)
            return false;

        directionToPlayer.Normalize();

        float dot = Vector3.Dot(transform.forward,directionToPlayer);

        float fieldOfViewCosine = Mathf.Cos(enemyData.fieldOfView * 0.5f * Mathf.Deg2Rad);

        if (dot < fieldOfViewCosine)
            return false;

        Vector3 rayOrigin = transform.position + Vector3.up * 1f;

        if (Physics.Raycast(
            rayOrigin,
            directionToPlayer,
            out RaycastHit hit,
            enemyData.detectionRange))
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
    public DeadState DeadState => deadState;
}