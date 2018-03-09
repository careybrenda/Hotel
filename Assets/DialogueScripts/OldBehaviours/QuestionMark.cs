using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;



    public class QuestionMark : DialogueBase
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
		return EventManagerOriginal.DialogueAction.Hello.ToString();
        }

	protected override EventManagerOriginal.DialogueAction GetDialogueAction()
        {
		return EventManagerOriginal.DialogueAction.Hello;
        }

        void Update()
        {
            IsEventDone();

           
        }

    }




