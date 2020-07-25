using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject CurLevel;
    public GameObject Player;
    public float MaxAngle=45f;
    public float MinAngle = -45f;
    public GameObject LevelPrefab 
    {
        get { return LevelPrefab; }
        set 
        {
            LevelPrefab = value;
            Player.transform.parent = LevelPrefab.transform;
        }
    }
    float RotationX = 0f;
    float RotationY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float pointer_x = Input.GetAxis("Mouse X");
        float pointer_y = Input.GetAxis("Mouse Y");
        if (Input.touchCount > 0)
        {
            pointer_x = Input.touches[0].deltaPosition.x / (Screen.width/10);
            pointer_y = Input.touches[0].deltaPosition.y / (Screen.height/10);
        }
        RotationX -= pointer_x;
        RotationY -= pointer_y;

        RotationX = Mathf.Clamp(RotationX,MinAngle,MaxAngle);
        RotationY = Mathf.Clamp(RotationY, MinAngle, MaxAngle);
        CurLevel.transform.localRotation = Quaternion.Euler(RotationX,0f, RotationY);
    }
}
