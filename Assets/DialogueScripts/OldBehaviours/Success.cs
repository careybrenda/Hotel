using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;



    public class Success : DialogueBase
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
		return EventManagerOriginal.DialogueAction.Accepted.ToString();
        }

	protected override EventManagerOriginal.DialogueAction GetDialogueAction()
        {
		return EventManagerOriginal.DialogueAction.Accepted;
        }

        void Update()
        {
            IsEventDone();

           

        }
    }

