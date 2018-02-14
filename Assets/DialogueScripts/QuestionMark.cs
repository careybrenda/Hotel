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
            return EventManager.DialogueAction.Hello.ToString();
        }

        protected override EventManager.DialogueAction GetDialogueAction()
        {
            return EventManager.DialogueAction.Hello;
        }

        void Update()
        {
            IsEventDone();

           
        }

    }




