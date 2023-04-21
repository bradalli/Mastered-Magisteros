using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.FSM;

[CreateAssetMenu(menuName = "FSM/Decisions/AggravatedDecision")]
public class AggravatedDecision : Decision
{
    public KeyCode debugAdvanceKey;
    public override bool Decide(BaseStateMachine stateMachine)
    {
        bool decision = false;
        // var characterInSight = stateMachine.GetComponent<CharacterSight>();
        // decision = characterInSight.Ping() && characterInSight.IsEnemyInSight();
        var characterInfo = stateMachine.GetComponent<CharacterInfo>();
        decision = characterInfo.InCombat();
        return decision;
    }
}
