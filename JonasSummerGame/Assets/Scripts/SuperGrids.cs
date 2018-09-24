using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SuperGrids : MonoBehaviour
{
    public int sizeX;
    public int sizeY;
    public int sizeZ;

    public Tile[,,] grid;

    public GameObject tilePrefab;

    public HeroBase heroTest;

    private Color B;
    private Color Y;


    void Awake()
    {
        CreateGrid();
        heroTest = (HeroBase)FindObjectOfType(typeof(HeroBase));
        SetColors();
    }

    private void Start()
    {

    }

    private void Update()
    {
        CheckMouse();
        ColorTiles();
    }

    private void SetColors()
    {
        B.r = 0.1f;
        B.g = 0.1f;
        B.b = 1.0f;
        B.a = 0.3f;

        Y.r = 1.0f;
        Y.g = 1.0f;
        Y.b = 0.1f;
        Y.a = 0.3f;
    }

    private void CreateGrid()
    {
        grid = new Tile[sizeX, sizeY, sizeZ];
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int z = 0; z < sizeZ; z++)
                {
                    GameObject go = Instantiate(tilePrefab, new Vector3(x, y, z),
                        Quaternion.identity) as GameObject;
                    //Rename the new gameobject...
                    go.transform.name = x.ToString() + " " + y.ToString() + " " + z.ToString();
                    //...and parent it under this transform to be more organized
                    go.transform.parent = transform;

                    //Create a new tile...
                    Tile tile = go.AddComponent<Tile>();
                    tile.x = x;
                    tile.y = y;
                    tile.z = z;
                    tile.worldObject = go;
                    tile.walkable = false;

                    //Then place it into our new grid!
                    grid[x, y, z] = tile;
                }
            }
        }
    }

    public Tile GetTileFromVector3(Vector3 currentpos)
    {
        return grid[Mathf.RoundToInt(currentpos.x),
                    Mathf.RoundToInt(currentpos.y),
                    Mathf.RoundToInt(currentpos.z)];
    }

    public void CheckMouse()
    {
        bool mouseValid = false;
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int z = 0; z < sizeZ; z++)
                {
                    if (grid[x, y, z].mouseOver)
                    {
                        mouseValid = true;
                        heroTest.DrawPath(grid[x, y, z].transform.position);
                        break;
                    }
                }
            }
        }

        if(!mouseValid)
        {
            heroTest.DestroyPath();
        }
    }

    public void ColorTiles()
    {
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int z = 0; z < sizeZ; z++)
                {
                    NavMeshPath path = new NavMeshPath();
                    NavMesh.CalculatePath(heroTest.transform.position, grid[x, y, z].transform.position, NavMesh.AllAreas, path);

                    if (path.corners.Length >= 2)
                    {
                        Vector3 previousCorner = path.corners[0];
                        float pathDist = 0.0F;
                        int i = 1;
                        while (i < path.corners.Length)
                        {
                            Vector3 currentCorner = path.corners[i];
                            pathDist += Vector3.Distance(previousCorner, currentCorner);
                            previousCorner = currentCorner;
                            i++;
                        }

                        if(pathDist <= heroTest.cb.movement1)
                        {
                            grid[x, y, z].mat.color = B;
                        }
                        else if (pathDist > heroTest.cb.movement1 && pathDist <= heroTest.cb.movement2)
                        {
                            grid[x, y, z].mat.color = Y;
                        }
                    }
                }
            }
        }
    }

    public void OutlineTiles()
    {
        Tile center;
        List<Tile> range1 = new List<Tile>();
        List<Tile> range2 = new List<Tile>();
        List<Tile> outside1 = new List<Tile>();
        List<Tile> outside2 = new List<Tile>();
        List<Vector3> corners = new List<Vector3>();

        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int z = 0; z < sizeZ; z++)
                {
                    NavMeshPath path = new NavMeshPath();
                    NavMesh.CalculatePath(heroTest.transform.position, grid[x, y, z].transform.position, NavMesh.AllAreas, path);

                    if (path.corners.Length >= 2)
                    {
                        Vector3 previousCorner = path.corners[0];
                        float pathDist = 0.0F;
                        int i = 1;
                        while (i < path.corners.Length)
                        {
                            Vector3 currentCorner = path.corners[i];
                            pathDist += Vector3.Distance(previousCorner, currentCorner);
                            previousCorner = currentCorner;
                            i++;
                        }

                        if (pathDist <= heroTest.cb.movement1)
                        {
                            range1.Add(grid[x, y, z]);
                        }
                        else if (pathDist > heroTest.cb.movement1 && pathDist <= heroTest.cb.movement2)
                        {
                            range2.Add(grid[x, y, z]);
                        }
                    }
                }
            }
        }

        for (int a = 1; a < range1.Count; a++)
        {

        }
    }
}
