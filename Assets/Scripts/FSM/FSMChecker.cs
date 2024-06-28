using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class FsmChecker : MonoBehaviour
    {
        [SerializeField] List<States> states;

        public States currentState;

        private void FsmCheck()
        {
            foreach (States state in states)
            {
                if (state == currentState)
                {
                    //state.();
                    //Preguntar si va por aca la cosa
                }

            }
        }
    }
}
