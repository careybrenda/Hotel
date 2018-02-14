using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;



public struct DialogueOptions
{
    string _actionName;

    public DialogueOptions(string name)
    {

        _actionName = name;

    }

    public string GetDialogueName()
    {
        return _actionName;
    }

}



public struct Details
{
	private GameObject _sender;
	private GameObject _target;

	private string _whoToMoveTo;

    private Dictionary<EventManager.DialogueAction, DialogueOptions> allOptions;


    

	public void SetTargetObj(GameObject obj)
	{
		_target = obj;
	}

	public void SetSenderObj(GameObject obj)
	{
		_sender = obj;
	}

	public void SetMoveToString(string whoToMoveTo)
	{
		_whoToMoveTo = whoToMoveTo;
	}

	public void SetDialogueAction(EventManager.DialogueAction action)
	{
        DialogueOptions newDialogue = new DialogueOptions(action.ToString());
        if(allOptions == null)
        {
            allOptions = new Dictionary<EventManager.DialogueAction, DialogueOptions>();
        }

        allOptions.Add(action, newDialogue);


    }

 
    public EventManager.DialogueAction GetNextDialogueAction()
    {
        foreach (KeyValuePair<EventManager.DialogueAction, DialogueOptions> entry in allOptions)
        {
          
            return entry.Key;
            
        }
        return EventManager.DialogueAction.None;

    }

    public void SetDialogueAsComplete(EventManager.DialogueAction finished)
    {
        bool remove = false;
        foreach (KeyValuePair<EventManager.DialogueAction, DialogueOptions> entry in allOptions)
        {
            if (entry.Key == finished)
            {           
                remove = true;  
            }
        }
        if(remove == true)
        {
           // Debug.Log("SetDialogueAsComplete: remove = " + finished.ToString());
            allOptions.Remove(finished);
        }
       
    }

    public string GetMoveString()
	{
		return _whoToMoveTo;
	}

	



    public GameObject GetTargetObj()
	{
		return _target;
	}

	public GameObject GetSenderObj()
	{
		return _sender;
	}



}


[System.Serializable]
public class SenderEvent : UnityEvent<Details> { }


public class EventManager : MonoBehaviour
{

	public const int MAX_INTERACTIONS = 4;

	public enum DialogueAction
	{
		None,
		Hello,
		CheckIn,
		Accepted,
		Denied,
        GetKey,
	}
		

	private Dictionary<string, SenderEvent> eventDictionary;

    private static EventManager eventManager;


	[SerializeField]
	public SenderEvent DoneEvent;

    public static EventManager instance
    {
        get
        {
            if(!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if(!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManager script on a GameObject in your scene. ");
                }
                else
                {
                    eventManager.Initialise();
                }
            }
            return eventManager;
        }
    }

    void Initialise()
    {
        if(eventDictionary == null)
        {
			eventDictionary = new Dictionary<string, SenderEvent>();
        }
    }

	public static void StartListening(string eventName, UnityAction<Details> listener)
    {

       


        SenderEvent thisEvent = null;
        if(instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
			
			thisEvent.AddListener(listener);
        }
        else
        {
			thisEvent = new SenderEvent();
			thisEvent.AddListener(listener);

            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

	public static void StopListening(string eventName, UnityAction<Details> listener)
    {
        if(eventManager == null)
        {
            return;
        }

		SenderEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
			thisEvent.RemoveListener(listener);
        }
    }


	public static void TriggerEvent(Details data)
    {

       

        //Debug.Log("TriggerEvent: GetNextDialogueAction = " + data.GetNextDialogueAction().ToString());
        SenderEvent thisEvent = null;
		if(instance.eventDictionary.TryGetValue(data.GetNextDialogueAction().ToString(), out thisEvent))
		{
            
			thisEvent.Invoke(data);
            
		}

        data.SetDialogueAsComplete(data.GetNextDialogueAction());

    }

	
}
