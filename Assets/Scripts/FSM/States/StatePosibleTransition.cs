using System.Collections.Generic;
using UnityEngine;

namespace FSM.States
{
    [CreateAssetMenu(fileName = "PosibleTransition", menuName = "Models/State/PosibleTransition")]
    public class StatePosibleTransition : ScriptableObject
    {
        public States PosibleTransition;
    }
}
