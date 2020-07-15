using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Multipurpose script for evert Target that can react to hit can be modified 
/// to send info about hit(Damage,HitType etc)
/// </summary>
/// 
public class ReactiveTarget : MonoBehaviour
{
    public void FindTarget()
    {
        gameObject.GetComponent<Target>().ReactToHit();
    }
}
