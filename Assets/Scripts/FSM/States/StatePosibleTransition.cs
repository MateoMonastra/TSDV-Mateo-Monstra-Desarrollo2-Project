using System.Collections.Generic;
using UnityEngine;

namespace FSM.States
{
    [CreateAssetMenu(menuName = "Models/State/PosibleTransition", fileName = "PosibleTransition", order = 0)]
    public class StatePosibleTransition : ScriptableObject
    {
        public States PosibleTransition;
    }
}
