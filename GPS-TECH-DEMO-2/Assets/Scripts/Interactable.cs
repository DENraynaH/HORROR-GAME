using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string toolTip;
    public string interactableName;
    public string displayName;

    public virtual void Interact()
    {

    }
}
           