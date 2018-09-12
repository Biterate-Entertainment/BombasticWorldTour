using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public SuperGrids gridmaster;
    public Tile currentTile;

    //Establish variables
    public int team;
    public bool isActive;

    public int maxHP;
    public int currentHP;
    public int movement1;
    public int movement2;
    public int attackPower;
    public int currentDefense;
    public int guardDefense;
    public int baseDefense;
    public int range;
    public int jumpRange;

    int northDefense;
    int southDefense;
    int eastDefense;
    int westDefense;

    public HeroBase heroTest;


    private void Start()
    {
        gridmaster = (SuperGrids)FindObjectOfType(typeof(SuperGrids));
        heroTest = (HeroBase)FindObjectOfType(typeof(HeroBase));

        GetTile();
    }

    public void GetTile()
    {
        currentTile = gridmaster.GetTileFromVector3(gameObject.transform.position);
        Debug.Log(currentTile);
    }

    void SetDefense()
    {
        northDefense = currentTile.northDefense;
        southDefense = currentTile.southDefense;
        eastDefense = currentTile.eastDefense;
        westDefense = currentTile.westDefense;
    }
}
