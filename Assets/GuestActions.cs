using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestActions : MonoBehaviour {
	
	Vector3 whereToWalk = new Vector3();
	Vector3 whereToLook = new Vector3();
	UnityEngine.AI.NavMeshAgent navMeshAgent;

	void Start()
	{
		SubscribeToListenerEvents ();
		navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}


	void Update () {
		if (Input.GetKeyDown ("q")) {

			EventManager.TriggerEvent ("FindFreeHotSpot");
		}

		RunWalking ();
	}



	void SubscribeToListenerEvents()
	{
		EventManager.StartListening ("WalkToHotspot", GetWalkToLocation);
		EventManager.StartListening ("EndWalkLookAt", GetEndLookAt);

	}



	void GetWalkToLocation(Vector3 destination)
	{
		whereToWalk = destination;

	}

	void GetEndLookAt(Vector3 lookat)
	{
		whereToLook = lookat;
	}
		

	StageMoveTo stages;

	enum StageMoveTo
	{
		TurnToFaceDestination,
		StartWalking,
		WalkToDestination,
		TurnToFaceObjective,
		Finished,

	}


	void RunWalking()
	{



		switch (stages) {

		case StageMoveTo.TurnToFaceDestination:

			if(!whereToWalk.Equals(new Vector3()))
			{
				this.transform.LookAt (whereToWalk);



				stages = StageMoveTo.StartWalking;
			}

			break;

		case StageMoveTo.StartWalking:

			navMeshAgent.destination = whereToWalk;

			stages = StageMoveTo.WalkToDestination;

			break;

		case StageMoveTo.WalkToDestination:
			if (navMeshAgent.remainingDistance != Mathf.Infinity
			    && navMeshAgent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathComplete
			    && navMeshAgent.remainingDistance == 0) {

				stages = StageMoveTo.TurnToFaceObjective;

			}
			break;

		case StageMoveTo.TurnToFaceObjective:

			this.transform.LookAt (whereToLook);

			stages = StageMoveTo.Finished;

			break;

		case StageMoveTo.Finished:


			whereToWalk = new Vector3 ();
			stages = StageMoveTo.TurnToFaceDestination;

			break;
		}

	}



}
