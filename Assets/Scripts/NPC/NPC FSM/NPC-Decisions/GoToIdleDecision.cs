using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.FSM;
using Mastered.Magisteros.NPC;

[CreateAssetMenu(menuName = "FSM/Decisions/GoToIdleDecision")]
public class GoToIdleDecision : Decision
{
    public KeyCode debugAdvanceKey;

    public override bool Decide(BaseStateMachine stateMachine)
    {
        bool decision = false;
        var characterInfo = stateMachine.GetComponent<CharacterInformation>();
        decision = !characterInfo.InCombat() && !characterInfo.AreWaypointsRemaining();
        return decision;
    }
}
