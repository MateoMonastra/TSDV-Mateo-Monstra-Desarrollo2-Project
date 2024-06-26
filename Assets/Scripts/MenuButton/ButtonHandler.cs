using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonHandler : ScriptableObject 
{
    abstract public void Handle(params object[] args);
}
