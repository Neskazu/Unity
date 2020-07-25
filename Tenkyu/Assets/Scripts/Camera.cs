using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 Offset;
    public GameObject MainCamera;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 NewPos = new Vector3(Player.transform.position.x + Offset.x, Player.transform.position.y + Offset.y, Player.transform.position.z + Offset.z);
        float VectorDifX = Mathf.Abs( MainCamera.transform.position.x - NewPos.x);
        float VectorDifY = Mathf.Abs(MainCamera.transform.position.y - NewPos.y);
        float VectorDifZ = Mathf.Abs(MainCamera.transform.position.z - NewPos.z);
        if (VectorDifX>0||VectorDifY>0 || VectorDifZ > 0)
        {
         MainCamera.transform.position = NewPos;
        }
    }
    void FixedUpdate()
    {
        Vector3 NewPos = new Vector3(Player.transform.position.x + Offset.x, Player.transform.position.y + Offset.y, Player.transform.position.z + Offset.z);
      
            MainCamera.transform.position = NewPos;
    }
}
