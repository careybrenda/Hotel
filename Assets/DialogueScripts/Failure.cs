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
        return EventManager.DialogueAction.Denied.ToString();
    }

    protected override EventManager.DialogueAction GetDialogueAction()
    {
        return EventManager.DialogueAction.Denied;
    }

    void Update()
    {
        IsEventDone();



    }

}
