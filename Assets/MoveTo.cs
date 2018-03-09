// MoveTo.cs
using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {


	public Details DataDetails;

    UnityEngine.AI.NavMeshAgent agent;
    GameObject[] TargetObject;
	Transform[] TargetHotspots;
	GameObject TheDestinationObject;

    Vector3 StartWalking;

    StageMoveTo stages;

    enum StageMoveTo
    {
        TurnToFaceDestination,
        StartWalking,
        WalkToDestination,
        TurnToFaceObjective,
        Finished,

    }


    void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		
		TargetObject = GameObject.FindGameObjectsWithTag(DataDetails.GetMoveString());

	
		int whichPedIndex = 0;

		for(int i= 0;i< TargetObject.Length-1;i++)
		{
			//Checks for choosing a receptionist, 
			whichPedIndex = i;
		}

		TargetHotspots = TargetObject[whichPedIndex].GetComponentsInChildren<Transform>();
		TheDestinationObject = TargetObject[whichPedIndex];

		for(int i = 0; i < TargetHotspots.Length-1;i++)
		{
			if(TargetHotspots[i].name == "HotSpot") //&& IS HOTSPOT FREE
			{
				
                StartWalking = TargetHotspots[i].transform.position;

                break;
			}
		}

	}

    void Update()
    {


        float dist = agent.remainingDistance;

        switch(stages)
        {

            case StageMoveTo.TurnToFaceDestination:

                this.transform.LookAt(StartWalking);



                stages = StageMoveTo.StartWalking;

                break;

            case StageMoveTo.StartWalking:

                agent.destination = StartWalking;
                stages = StageMoveTo.WalkToDestination;
                break;


            case StageMoveTo.WalkToDestination:

                if (dist != Mathf.Infinity && agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathComplete && dist == 0)
                {


                    

                    stages = StageMoveTo.TurnToFaceObjective;
                }
                break;

            case StageMoveTo.TurnToFaceObjective:

                this.transform.LookAt(TheDestinationObject.transform.position);

                stages = StageMoveTo.Finished;

                break;

            case StageMoveTo.Finished:

                DataDetails.SetTargetObj(TheDestinationObject);
                DataDetails.SetSenderObj(gameObject);

			EventManagerOriginal.TriggerEvent(DataDetails);

                this.enabled = false;
                //Arrived.

                break;

        }
    }
} 