using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;


    public class CheckIn : DialogueBase
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
		return EventManagerOriginal.DialogueAction.CheckIn.ToString();
        }

        protected override EventManagerOriginal.DialogueAction GetDialogueAction()
        {
		return EventManagerOriginal.DialogueAction.CheckIn;
        }


        void Update()
        {
            IsEventDone();

           
        }

    


}
