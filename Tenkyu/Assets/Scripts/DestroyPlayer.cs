using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Reset();
    }
    void Reset()
    {
       Scene scene=SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
