using UnityEngine;
using UnityEngine.Tilemaps;

public class PelletGenerator : MonoBehaviour
{
    // Assign these in the Inspector
    public Tilemap mazeTilemap;
    public GameObject pelletPrefab;
    public Vector3 pelletOffset = new Vector3(0.5f, 0.5f, 0); // To center the pellet on the tile

    void Start()
    {
        GeneratePellets();
    }

    void GeneratePellets()
    {
        BoundsInt bounds = mazeTilemap.cellBounds;
        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            Vector3 localPlace = mazeTilemap.GetCellCenterWorld(pos);
            
            if (mazeTilemap.GetTile(pos) == null) 
            {
                GameObject pellet = Instantiate(pelletPrefab, localPlace, Quaternion.identity);
                pellet.transform.SetParent(this.transform); // Keep the scene hierarchy clean
            }
        }
    }
}