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
            return EventManager.DialogueAction.CheckIn.ToString();
        }

        protected override EventManager.DialogueAction GetDialogueAction()
        {
            return EventManager.DialogueAction.CheckIn;
        }


        void Update()
        {
            IsEventDone();

           
        }

    


}
