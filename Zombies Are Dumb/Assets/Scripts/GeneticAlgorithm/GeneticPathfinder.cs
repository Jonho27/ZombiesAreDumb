﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticPathfinder : MonoBehaviour
{
    public float creatureSpeed;
    public float pathMultiplier;
	public float rotationSpeed;
    int pathIndex = 0;
    public DNA dna;
    public bool hasFinished = false;

    public int identifier;
    public LayerMask obstacleLayer;

    bool hasBeenInitialized = false;
	bool hasCrashed = false;
	List<Vector3> travelledPath = new List<Vector3>();
    Vector3 target;
    Vector3 nextPoint;
	Quaternion targetRotation;
	//LineRenderer lr;
    public void InitCreature(DNA newDna, Vector3 _target, int id)
    {
		travelledPath.Add(transform.position);
		//lr = GetComponent<LineRenderer>();
        dna = newDna;
        target = _target;
        nextPoint = transform.position;
		travelledPath.Add(nextPoint);
        hasBeenInitialized = true;
        identifier = id;
    }
    private void Update()
    {
        if (hasBeenInitialized && !hasFinished)
        {
            if(pathIndex == dna.genes.Count || Vector3.Distance(transform.position, target) < 0.5f)
            {
                PopulationController.population[identifier].gameObject.transform.localScale = new Vector3(0, 0, 0);
                hasFinished = true;
            }
            if((Vector3)transform.position == nextPoint)
            {
                nextPoint = (Vector3)transform.position + dna.genes[pathIndex] * pathMultiplier;
				travelledPath.Add(nextPoint);
                Vector3 lookPos = nextPoint - transform.position;
                lookPos.y = 0;
                targetRotation = Quaternion.LookRotation(lookPos);
                pathIndex++;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPoint, creatureSpeed * Time.deltaTime);
            }
			if(transform.rotation != targetRotation)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
			}
        }

        if (hasFinished)
        {
            //gameObject.GetComponent<Animator>().SetBool("isOver", true);

            //StartCoroutine(Desaparecer());

           

            
        }
    }

    IEnumerator Desaparecer()
    {
        yield return new WaitForSeconds(1.75f);
        gameObject.transform.localScale = new Vector3(0, 0, 0);

    }
	
    public float fitness
    {
        get
        {
            float dist = Vector3.Distance(transform.position, target);
            if(dist == 0f)
            {
                dist = 0.0001f;
            }
			RaycastHit[] obstacles = Physics.RaycastAll(transform.position, target, obstacleLayer);
			float obstacleMultiplier = 1f - (0.15f * obstacles.Length);
			return (60/dist) * (hasCrashed ? 0.75f : 1f) * obstacleMultiplier;
        }
    }
	
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            
            hasFinished = true;
            hasCrashed = true;
            
        }

        if (collision.transform.CompareTag("Goal"))
        {
            Debug.Log("Logrado");
        }
    }


    


}