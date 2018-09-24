using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroBase : MonoBehaviour
{
    public CharacterBase cb;
    private NavMeshAgent agent;
    NavMeshPath path;

    Color orange;

    private Material lineMat;


    // Use this for initialization
    void Start ()
    {
        cb = gameObject.GetComponent<CharacterBase>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        path = new NavMeshPath();

        orange.r = 1.0f;
        orange.g = 0.6f;
        orange.b = 0.0f;
        orange.a = 1.0f;
    }

    // Update is called once per frame
    void Update ()
    {
        //cb.GetTile();
	}

    public void DrawPath(Vector3 target)
    {
        NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, path);

        if (path.corners.Length >= 2)
        {
            Vector3 previousCorner = path.corners[0];
            float lengthSoFar = 0.0F;
            int i = 1;
            while (i < path.corners.Length)
            {
                Vector3 currentCorner = path.corners[i];
                lengthSoFar += Vector3.Distance(previousCorner, currentCorner);
                previousCorner = currentCorner;
                i++;
            }

            LineRenderer line = GetComponent<LineRenderer>();
            if (line == null)
            {
                line = gameObject.AddComponent<LineRenderer>();
                line.material = new Material(Shader.Find("Sprites/Default")) { color = Color.white };
                line.material.renderQueue = 5000;
                line.startWidth = 0.1f;
                line.endWidth = 0.2f;
                line.numCornerVertices = 10;
                line.numCapVertices = 20;
                line.startColor = Color.cyan;
                line.endColor = Color.blue;
            }

            line.positionCount = path.corners.Length;
            for (int k = 0; k < path.corners.Length; k++)
            {
                line.SetPosition(k, path.corners[k]);
            }

            if (lengthSoFar <= cb.movement1)
            {
                line.startColor = Color.cyan;
                line.endColor = Color.blue;
            }
            else if (lengthSoFar > cb.movement1 && lengthSoFar <= cb.movement2)
            {
                line.startColor = Color.yellow;
                line.endColor = orange;
            }
            else
            {
                line.startColor = Color.clear;
                line.endColor = Color.clear;
            }
        }
    }

    public void MoveUnit(Vector3 target)
    {
        NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, path);

        if (path.corners.Length >= 2)
        {
            Vector3 previousCorner = path.corners[0];
            float lengthSoFar = 0.0F;
            int i = 1;
            while (i < path.corners.Length)
            {
                Vector3 currentCorner = path.corners[i];
                lengthSoFar += Vector3.Distance(previousCorner, currentCorner);
                previousCorner = currentCorner;
                i++;
            }

            if(lengthSoFar <= cb.movement2)
            {
                agent.destination = target;
            }
        }
    }

    public void DestroyPath()
    {
        //LineRenderer line = gameObject.GetComponent<LineRenderer>();
        Destroy(gameObject.GetComponent<LineRenderer>());
    }
}
