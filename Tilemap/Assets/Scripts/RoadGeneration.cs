using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class RoadGeneration : MonoBehaviour
{
    public GameObject ScoreObject;
    public float ScoreObjectChance;
    Vector3Int LastTilePos = Vector3Int.zero;
    public Transform PlayerPos;
    public float DistanceToPlayer;
    //Percentage
    public float RightTileChance;
    //Tile
    public RuleTile RoadTile;
    //Road Tilemap
    public Tilemap tilemap;
    //tileChoose
    bool isright;
    GridLayout gridLayout;
    // Start is called before the first frame update
    void Start()
    {
        gridLayout = tilemap.transform.parent.GetComponentInParent<GridLayout>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (DistanceCheck())
        {
            PlaceTile(ChooseTile());
          
        }
    }
    bool DistanceCheck()
    {
       
        return Vector2.Distance(gridLayout.CellToWorld(LastTilePos), PlayerPos.position) < DistanceToPlayer ? true:false;
    }
    bool ChooseTile()
    {
        return Random.Range(0, 100) <= RightTileChance ? isright = true : isright = false;
    }
    void PlaceTile(bool isRight)
    {
        //Place Tile Up or Right
        if (isright)
        {
            tilemap.SetTile(LastTilePos + Vector3Int.right, RoadTile);
            LastTilePos += Vector3Int.right;
        }
        else
        {
            tilemap.SetTile(LastTilePos + Vector3Int.up, RoadTile);
            LastTilePos += Vector3Int.up;
        }
        PlaceScoreObject();
    }
    void PlaceScoreObject()
    {
        if(Random.Range(0, 100)<=ScoreObjectChance)
        Instantiate(ScoreObject,gridLayout.CellToWorld(LastTilePos)+tilemap.tileAnchor,Quaternion.identity);
    }
}
