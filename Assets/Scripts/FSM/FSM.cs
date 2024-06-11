using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    [SerializeField] List<States> states;

    public States currentState;

    private void FSMCheck()
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
