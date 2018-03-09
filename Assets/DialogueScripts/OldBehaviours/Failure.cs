using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Failure : DialogueBase
{

    void Awake()
    {


        Initialise();

    }

    void OnEnable()
    {
        SubscribeToEvent();
    }

    void OnDisable()
    {
        UnsubscribeToEvent();
    }


    protected override string GetEventTrigger()
    {
		return EventManagerOriginal.DialogueAction.Denied.ToString();
    }

	protected override EventManagerOriginal.DialogueAction GetDialogueAction()
    {
		return EventManagerOriginal.DialogueAction.Denied;
    }

    void Update()
    {
        IsEventDone();



    }

}
