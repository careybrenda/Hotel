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
            return EventManager.DialogueAction.Accepted.ToString();
        }

        protected override EventManager.DialogueAction GetDialogueAction()
        {
            return EventManager.DialogueAction.Accepted;
        }

        void Update()
        {
            IsEventDone();

           

        }
    }

