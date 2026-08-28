using UnityEngine;

public class DeadState : IAIState
{
    private EnemyController enemy;

    public DeadState(EnemyController enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        Debug.Log("AI entered DEAD state");

        enemy.agent.isStopped = true;
        enemy.enabled = false;
    }

    public void Update()
    {
    }

    public void Exit()
    {
    }
}