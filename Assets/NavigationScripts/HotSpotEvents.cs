using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HotSpotEvents : MonoBehaviour {

	private UnityAction walkToMe;

	Transform thistransformData;
	Transform parentTransform;

	void Start () {

		thistransformData = GetComponent<Transform>();
		parentTransform = thistransformData.parent.transform;

		EventManager.StartListening ("FindFreeHotSpot", SendReplyOfPosition);


	}



	void SendReplyOfPosition()
	{
		EventManager.TriggerEvent ("WalkToHotspot", thistransformData.position);
		EventManager.TriggerEvent ("EndWalkLookAt", parentTransform.position);
	}

}
