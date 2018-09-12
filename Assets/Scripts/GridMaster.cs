using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaster : MonoBehaviour
{
    public Tile[,,] tiles;
    public int sizeX = 10;
    public int sizeY = 1;
    public int sizeZ = 10;
    private int maxTiles;
    private List<GameObject> tileTest = new List<GameObject>();
    private Tile[] tileList;
    int tileCount;

	// Use this for initialization
	void Start ()
    {
        tiles = new Tile[sizeX, sizeY, sizeZ];
        maxTiles = sizeX * sizeY * sizeZ;

        //tileTest = GameObject.FindGameObjectsWithTag("Tile");
        tileTest.AddRange(GameObject.FindGameObjectsWithTag("Tile"));
        tileCount = tileTest.Count;

        Test();

        ResetTiles();
	}

    public void Test()
    {
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int z = 0; z < sizeZ; z++)
                {
                    Debug.Log("Tile: (" + x + ", " + y + ", " + z + ")" + tiles[x, y, z]);
                    Debug.Log(tiles[x, y, z]);

                }
            }
        }
    }

    public void ResetTiles()
    {
        //tileCount = tileTest.Length;
        //Debug.Log("Number of tiles: " + tileCount);

        
        for (int i = 0; i < tileCount; i++)
        {
            int currentX = Mathf.RoundToInt(tileTest[i].transform.position.x);
            int currentY = Mathf.RoundToInt(tileTest[i].transform.position.y);
            int currentZ = Mathf.RoundToInt(tileTest[i].transform.position.z);

            tiles[currentX, currentY, currentZ] = tileTest[i].gameObject.GetComponent<Tile>();
            //Debug.Log(tiles[currentX, currentY, currentZ]);

            //Debug.Log("(" + currentX + ", " + currentY + ", " + currentZ + ")");
            tiles[currentX, currentY, currentZ].SetDefense();
        }
        

        /*
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int z = 0; z < sizeZ; z++)
                {
                    for (int j = 0; j < tileCount; j++)
                    {
                        if (tileTest[j].transform.position.x == x
                            && tileTest[j].transform.position.y == y
                            && tileTest[j].transform.position.z == z)
                        {
                            tiles[x, y, z] = tileTest[j].gameObject.GetComponent<Tile>();
                        }
                    }
                }
            }
        }
        */
    }

    public Tile GetTile(Vector3 currentPos)
    {
        Tile currentTile = null;

        int currentX = Mathf.RoundToInt(currentPos.x);
        int currentY = Mathf.RoundToInt(currentPos.y);
        int currentZ = Mathf.RoundToInt(currentPos.z);

        for (int i = 0; i < tileCount; i++)
        {
            if (currentPos == tileTest[i].gameObject.transform.position)
            {
                currentTile = tileTest[i].GetComponent<Tile>();
            }
        }
        Debug.Log(currentTile);
        return currentTile;
    }
}
