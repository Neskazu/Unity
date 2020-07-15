using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target:MonoBehaviour
{
    //Can be overriden for specif object 
    public abstract void ReactToHit();
}
