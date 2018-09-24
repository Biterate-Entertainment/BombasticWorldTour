using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public SuperGrids gridmaster;

    public bool selectable;
    public bool walkable;
    public bool mouseOver;
    public CharacterBase currentUnit;

    public int northDefense;
    public int southDefense;
    public int eastDefense;
    public int westDefense;

    public int x;
    public int y;
    public int z;

    private Color prevColor;

    public GameObject worldObject;

    public Material mat;

    public HeroBase heroTest;

    private void Start()
    {
        gridmaster = (SuperGrids)FindObjectOfType(typeof(SuperGrids));

        mat = GetComponent<Renderer>().material;
        heroTest = (HeroBase)FindObjectOfType(typeof(HeroBase));

        mat.color = Color.clear;
        CheckSurroundings();
    }

    private void Update()
    {

    }

    public void CheckSurroundings()
    {
        Vector3 north = new Vector3(0, 0, 1);
        Vector3 south = new Vector3(0, 0, -1);
        Vector3 east = new Vector3(1, 0, 0);
        Vector3 west = new Vector3(-1, 0, 0);

        Vector3 down = new Vector3(0, -1, 0);
        Vector3 up = new Vector3(0, 1, 0);

        int groundMask = 1 << 11;
        int layerMask = 1 << 9;
        float checkDist = 1.1f;
        RaycastHit hit;

        //check ground
        if (Physics.Raycast(transform.position, down, out hit, checkDist, layerMask))
        {
            walkable = true;
        }

        //check north
        if (Physics.Raycast(transform.position, north, out hit, checkDist, layerMask))
        {
            northDefense = 1;
        }
        //check south
        if (Physics.Raycast(transform.position, south, out hit, checkDist, layerMask))
        {
            southDefense = 1;
        }
        //check east
        if (Physics.Raycast(transform.position, east, out hit, checkDist, layerMask))
        {
            eastDefense = 1;
        }
        //check west
        if (Physics.Raycast(transform.position, west, out hit, checkDist, layerMask))
        {
            westDefense = 1;
        }
    }

    private void OnMouseOver()
    {
        //prevColor = mat.color;
        mouseOver = true;
        //mat.color = Color.white;
        if (Input.GetMouseButton(1))
        {
            heroTest.MoveUnit(transform.position);
        }
    }

    private void OnMouseExit()
    {
        mouseOver = false;
        mat.color = Color.clear;
        //heroTest.DestroyPath();
    }
}

