using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;

    public float detectionRange = 10f;
    public float attackRange = 2f;

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

        float distance = Vector3.Distance(
            transform.position,
            player.position
        );

        return distance <= detectionRange;
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