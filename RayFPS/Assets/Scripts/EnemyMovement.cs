using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent EnemyAgent;
    public Transform Player;

    //aggr radius
    public float LookRadius = 10f;

    //Rotation to player speed
    public float RotationSpeed = 5f;
    
    //Distance between player and enemyagent
    public float Distance;

    //Fireball Prefab
    public GameObject FireBall;

    //Range Attack Radius
    public float RangeAttackMinDistance = 8;

    //Attack spawn Position
    public Transform RangeAttackStartPosition;

    //Max range attack distance
    public float RangeAttackMaxDistance;

    //Fireball Size
    public float SphereRadius;
    
    //
    public LayerMask FireBallLayerMask;

    //Fire Check Cooldown
    public bool IsFireCoolDown;
    //Time between check fire possible(seconds)
    public float TimeBetweenFireCheck = 1f;
    //Attack Charge Time (seconds);
    public float RangeAttackChargeTime = 1f;
    //Is target detected and Shoot Possible
    public bool IsShootPossible;
    public bool IsChargingAttack;
    //Melee Attack Charge Time;
    public float MeleeAttackTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //check distance between playet and enemy
        Distance = Vector3.Distance(Player.position, transform.position);
        if (Distance <= LookRadius&&!IsChargingAttack)
        {
            //Moving enemy to player
            EnemyAgent.SetDestination(Player.position);

            Debug.LogWarning(Distance);
            //Check melee attack possibility
            if (Distance <= EnemyAgent.stoppingDistance)
            {
                Attack();
            }
        }
        if (Distance <= RangeAttackMinDistance && Distance >= RangeAttackMaxDistance)
        {
            if(IsRangeAttackPossible())
            {
              
                RangeAttack();
                
            }
        }
        Debug.DrawRay(RangeAttackStartPosition.position,(Player.position - transform.position).normalized, Color.green);
    }
    void FaceTarget()
    {
        Vector3 Direction = (Player.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(Direction.x, 0, Direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * RotationSpeed);
    }
    void Attack()
    {
        StartCoroutine(MeleeAttack());
        if (Distance <= EnemyAgent.stoppingDistance)
        {
            //Can be Replaced Bu ReactiveTarget Logic
            Destroy(Player.gameObject);
        }
    }
    void RangeAttack()
    {
        Debug.Log("zashlo");
        IsChargingAttack = true;
        //stop navmesh agent move
        EnemyAgent.isStopped=true;
        StartCoroutine( FireLoadTime()); 
    }
    void SpawnFireBall()
    {//Reset var for next shoot
        IsShootPossible = false;
        var FireBallClone = Instantiate(FireBall, RangeAttackStartPosition.position, Quaternion.identity);
        FireBallClone.GetComponent<FireBall>().Player = Player;
    }
    //Check range attack possibility
    bool IsRangeAttackPossible()
    {
        RaycastHit hit;
        if(!IsFireCoolDown&&!IsShootPossible)
        {
            if( Physics.SphereCast(RangeAttackStartPosition.position,SphereRadius, (Player.position - transform.position).normalized, out hit, RangeAttackMaxDistance, FireBallLayerMask))
            {
                if (hit.collider.gameObject.layer == 8)
                {
                    
                    IsFireCoolDown = true;
                    StartCoroutine(FireCooldown());
                }
                if (hit.collider.CompareTag("Player"))
                {
                    IsShootPossible = true;
                    IsFireCoolDown = true;
                    StartCoroutine(FireCooldown());
                }
              
            }
            
        }
        if (IsShootPossible&&!IsChargingAttack)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position,LookRadius);
    }
    IEnumerator FireCooldown()
    {
        yield return new
         WaitForSeconds(TimeBetweenFireCheck);
        IsFireCoolDown = false;
    }
    IEnumerator FireLoadTime()
    {
           yield return new
        WaitForSeconds(RangeAttackChargeTime);
        IsChargingAttack = false;
        SpawnFireBall();
        //resume navmesh agent
        EnemyAgent.isStopped = false;
    }
    IEnumerator MeleeAttack()
    {
        yield return new
      WaitForSeconds(MeleeAttackTime);
        
    }
}
