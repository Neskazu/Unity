using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Transform Player;

    //Life time of FireBall
    public float LifeTime = 5f;
    public float TimerOfLifeTime = 0f;
    
    //Speed of fireballвввввввввввв
    public float Speed = 12325f;
    
    //Blast Radius of fireball
    public float BlastRadius = 3f;
    public float BlastPower = 5f;
    private Vector3 normalizeDirection;
    // Start is called before the first frame update
    void Start()
    {
        normalizeDirection = (Player.position - transform.position).normalized;
    }

    void Update()
    {
        //increase lifetime
        TimerOfLifeTime++;
        transform.position += normalizeDirection * Speed * Time.deltaTime;
        if (TimerOfLifeTime>=LifeTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, BlastRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(BlastPower, explosionPos, BlastRadius);
        }
    }
}
