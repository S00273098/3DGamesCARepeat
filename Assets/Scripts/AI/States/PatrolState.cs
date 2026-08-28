using UnityEngine;

public class PatrolState : IAIState
{
    private EnemyController enemy;
    private int currentPoint = 0;

    public PatrolState(EnemyController enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        Debug.Log("AI entered PATROL state");

        enemy.agent.isStopped = false;

        GoToNextPoint();
    }

    public void Update()
    {
        if (enemy.CanSeePlayer())
        {
            enemy.ChangeState(enemy.ChaseState);
            return;
        }

        if (!enemy.agent.pathPending &&
            enemy.agent.remainingDistance <= enemy.agent.stoppingDistance)
        {
            GoToNextPoint();
        }
    }

    private void GoToNextPoint()
    {
        if (enemy.patrolPoints == null ||
            enemy.patrolPoints.Length == 0)
            return;

        enemy.agent.SetDestination(
            enemy.patrolPoints[currentPoint].position
        );

        currentPoint++;

        if (currentPoint >= enemy.patrolPoints.Length)
        {
            currentPoint = 0;
        }
    }

    public void Exit()
    {
    }
}