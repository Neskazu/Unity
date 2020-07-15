using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera Cam;
    public LayerMask Obstacles;
    public LayerMask Destructible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RangeAttack();
            Debug.Log("good");
        }
    }
    
    void RangeAttack()
    {
        Ray ray = Cam.ScreenPointToRay(Cam.transform.forward);
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
        Debug.Log(hit.collider.gameObject);
        if(hit.collider!=null)
        {
            if (hit.collider.gameObject.layer == Obstacles)
            {
                //Create sprite or something else
            }
            if (hit.collider.gameObject.layer == Destructible)
            {
                hit.collider.gameObject.GetComponent<ReactiveTarget>().FindTarget();
            }
            if (hit.collider.gameObject.transform.root.CompareTag("Enemy"))
            {
                hit.collider.gameObject.transform.root.GetComponent<ReactiveTarget>().FindTarget();
            }
        }
    }
    
}
