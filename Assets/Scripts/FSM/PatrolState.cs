using UnityEngine;
using System;

public class PatrolState : IState
{
    public void Run(MonsterCtrl monster)
    {
        if (monster.Detect())
        {
            if (monster.GetTargetVisible())
            {
                if (monster.IsAttackable())
                {
                    monster.ChangeState(
                        StateManager.GetIState(StateManager.State.Attack));
                }
                    
                else
                {
                    monster.Move();
                    monster.ChangeState(
                        StateManager.GetIState(StateManager.State.Trace));
                }
            }

            else
            {
                // TODO: Set CheckPoint to Target Position
                monster.SetCheckpoint(new Vector3());
                monster.Move();
                monster.ChangeState(
                    StateManager.GetIState(StateManager.State.Trace));
            }
        }

        else
        {
            // PaceAround function is moving distance in just during one frame
            monster.PaceAround();
            //monster.ChangeState(StateManager.GetIState(StateManager.State.Patrol));
        }
    }
}
