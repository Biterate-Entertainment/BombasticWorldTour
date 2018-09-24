using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTracker : MonoBehaviour
{
    public SuperGrids gridmaster;
    public CharacterBase[] characters;
    public HeroBase[] heroes;

    public CharacterBase activeCharacter;

	// Use this for initialization
	void Start ()
    {
        gridmaster = (SuperGrids)FindObjectOfType(typeof(SuperGrids));
        characters = FindObjectsOfType(typeof(CharacterBase)) as CharacterBase[];
        heroes = FindObjectsOfType(typeof(HeroBase)) as HeroBase[];

        ResetPlayer();
    }

    void InitializeGame()
    {
        heroes = new HeroBase[heroes.Length];

        for (int i = 0; i < heroes.Length; i++)
        {
            heroes[i] = new HeroBase();
        }
    }

    // Update is called once per frame
    void Update ()
    {

	}

    void MoveMode()
    {

    }

    void AttackMode()
    {

    }

    void ResetPlayer()
    {
        activeCharacter = heroes[0].gameObject.GetComponent<CharacterBase>();
    }
}
