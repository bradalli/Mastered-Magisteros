using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.FSM;

[CreateAssetMenu(menuName = "FSM/Decisions/WPReachedDecision")]
public class WPReachedDecision : Decision
{
    public KeyCode debugAdvanceKey;
    public override bool Decide(BaseStateMachine stateMachine)
    {
        bool decision = false;
        #region For Testing Purposes
        decision = Input.GetKeyDown(debugAdvanceKey);
        #endregion
        // var characterInfo = stateMachine.GetComponent<CharacterInfo>();
        // decision = !characterInfo.AreWaypointsRemaining();
        return decision;
    }
}
