using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
   
    public static bool InLayerMask(LayerMask layerMask, GameObject collisionObject)
    {
        if ((layerMask.value & (1 << collisionObject.layer)) > 0) { return true; }
        else { return false; }
    }


}
