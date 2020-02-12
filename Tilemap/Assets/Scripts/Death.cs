using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public string GameScene;
    //Road Tilemap
    public Tilemap tilemap;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DeathCheck())
        {
            SceneManager.LoadScene(GameScene);
        }
    }
    bool DeathCheck()
    {
        
        GridLayout gridLayout = tilemap.transform.parent.GetComponentInParent<GridLayout>();
        Vector3Int playeposWorldtoCell = gridLayout.WorldToCell(rb.position);
        
        if (tilemap.GetTile(playeposWorldtoCell) == null)
        {
            return true;
        }
        return false;
    }
}
