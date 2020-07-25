using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerate : MonoBehaviour
{
    public GameObject LevelPrefab;
    public GameObject Player;
    public GameObject LevelControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            GenerateNewLevel();
        }
    }
    void GenerateNewLevel()
    {
        Debug.Log("generated");
        Player = GameObject.FindGameObjectWithTag("Player");
        LevelControl = GameObject.FindGameObjectWithTag("Controller");
        var NewLevel = Instantiate(LevelPrefab);
        NewLevel.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 10, Player.transform.position.z);
        Player.transform.parent = NewLevel.transform;
        var prevlevel = LevelControl.GetComponent<LevelController>().CurLevel;
        LevelControl.GetComponent<LevelController>().CurLevel = NewLevel;
        Destroy(prevlevel);
    }
}
