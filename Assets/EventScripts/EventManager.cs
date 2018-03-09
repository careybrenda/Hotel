using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

	private Dictionary <string, UnityEvent> eventDictionary;
	private Dictionary <string, UnityEvent<Vector3>> eventDictionaryVector;
	private Dictionary <string, UnityEvent<float>> eventDictionaryFloat;

	private static EventManager eventManager;

	[System.Serializable]
	public class MyVector3Event : UnityEvent<Vector3>
	{
	}

	[System.Serializable]
	public class MyFloatEvent : UnityEvent<float>
	{
	}


	//#####INITIALISATION###########
	#region Initialisation

	public static EventManager instance
	{
		get
		{
			if (!eventManager)
			{
				eventManager = FindObjectOfType (typeof (EventManager)) as EventManager;

				if (!eventManager)
				{
					Debug.LogError ("There needs to be one active EventManager script on a GameObject in your scene.");
				}
				else
				{
					eventManager.Init (); 
				}
			}

			return eventManager;
		}
	}

	void Init ()
	{
		if (eventDictionary == null)
		{
			eventDictionary = new Dictionary<string, UnityEvent>();
		}
		if (eventDictionaryVector == null)
		{
			eventDictionaryVector = new Dictionary<string, UnityEvent<Vector3>>();
		}
		if (eventDictionaryFloat == null)
		{
			eventDictionaryFloat = new Dictionary<string, UnityEvent<float>>();
		}
	}


	#endregion



	#region Start Listening


	public static void StartListening (string eventName, UnityAction listener)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.AddListener (listener);
		} 
		else
		{
			thisEvent = new UnityEvent ();
			thisEvent.AddListener (listener);
			instance.eventDictionary.Add (eventName, thisEvent);
		}
	}

	public static void StartListening (string eventName, UnityAction<Vector3> listener)
	{
		UnityEvent<Vector3> thisEvent = null;
		if (instance.eventDictionaryVector.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.AddListener (listener);
		} 
		else
		{
			thisEvent = new MyVector3Event();
			thisEvent.AddListener (listener);
			instance.eventDictionaryVector.Add (eventName, thisEvent);
		}
	}

	public static void StartListening (string eventName, UnityAction<float> listener)
	{
		UnityEvent<float> thisEvent = null;
		if (instance.eventDictionaryFloat.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.AddListener (listener);
		} 
		else
		{
			thisEvent = new MyFloatEvent();
			thisEvent.AddListener (listener);
			instance.eventDictionaryFloat.Add (eventName, thisEvent);
		}
	}

	#endregion /Start listening


	#region Stop Listening



	public static void StopListening (string eventName, UnityAction listener)
	{
		if (eventManager == null) return;
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}

	public static void StopListening (string eventName, UnityAction<Vector3> listener)
	{
		if (eventManager == null) return;
		UnityEvent<Vector3>  thisEvent = null;
		if (instance.eventDictionaryVector.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}

	public static void StopListening (string eventName, UnityAction<float> listener)
	{
		if (eventManager == null) return;
		UnityEvent<float>  thisEvent = null;
		if (instance.eventDictionaryFloat.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}


	#endregion /Stop Listening




	#region Trigger Events

	public static void TriggerEvent (string eventName)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.Invoke ();
		}
	}


	public static void TriggerEvent (string eventName, Vector3 data)
	{
		UnityEvent<Vector3> thisEvent = null;
		if (instance.eventDictionaryVector.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.Invoke (data);
		}
	}

	public static void TriggerEvent (string eventName, float data)
	{
		UnityEvent<float> thisEvent = null;
		if (instance.eventDictionaryFloat.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.Invoke (data);
		}
	}

	#endregion /Trigger Events


}
