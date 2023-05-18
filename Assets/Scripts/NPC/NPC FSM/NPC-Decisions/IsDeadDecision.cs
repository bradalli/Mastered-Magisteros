using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.FSM;
using Mastered.Magisteros.NPC;

[CreateAssetMenu(menuName = "FSM/Decisions/IsDeadDecision")]
public class IsDeadDecision : Decision
{
    public override bool Decide(BaseStateMachine stateMachine)
    {
        bool decision = false;
        var characterInfo = stateMachine.GetComponent<Mastered.Magisteros.NPC.Character>();
        decision = characterInfo.IsDead();
        return decision;
    }
}
