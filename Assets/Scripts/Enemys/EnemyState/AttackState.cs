using UnityEngine;

public class AttackState : EnemyBaseState
{
    public AttackState(Enemy enemy, string animationName) : base (enemy, animationName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        enemy.spriteRenderer.color = Color.red;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!enemy.CanAttack() && enemy.isChasing)
            enemy.SwitchState(enemy.chaseState);
        else if(!enemy.CanAttack())
            enemy.SwitchState(enemy.patrolState);
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
