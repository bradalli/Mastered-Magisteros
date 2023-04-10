using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.FSM
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(BaseStateMachine state);
    }
}
