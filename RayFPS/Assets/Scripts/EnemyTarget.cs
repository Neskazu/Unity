using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : Target
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    //Enemy Reaction To hit
    public override void ReactToHit()
    {
        Debug.Log("Work"); ;
    }
}
