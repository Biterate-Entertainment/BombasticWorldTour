using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public CameraPan cam;
    public GameObject unit;
    public float time;
    public GameTracker gametracker;

    public CharacterBase character;

	// Use this for initialization
	void Start ()
    {
        cam = (CameraPan)FindObjectOfType(typeof(CameraPan));
        character = unit.GetComponent<CharacterBase>();
        gametracker = (GameTracker)FindObjectOfType(typeof(GameTracker));
    }

    public void MoveCamera()
    {
        gametracker.activeCharacter = character;
        Debug.Log("Button call");
        StartCoroutine(cam.RetargetCamera(unit.transform.position, time));
    }
}
