using UnityEngine;

public class PatrolState : EnemyBaseState
{
    public PatrolState(Enemy enemy, string animationName) : base (enemy, animationName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        enemy.spriteRenderer.color = Color.green;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        enemy.Patrulha();
        if(enemy.isChasing) enemy.SwitchState(enemy.chaseState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
