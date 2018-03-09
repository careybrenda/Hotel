using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;




public class GuestManager : MonoBehaviour {

    private int _cash = 0;
    private int _checkinCost = 9900;

    // Use this for initialization
    void Start ()
    {

        SetupGuestData();
        HeadToReceptionist();
       

    }


	// Update is called once per frame
	void Update () {
	
	}

    void SetupGuestData()
    {
        _cash = Random.Range(100, 10000);
       // Debug.Log("SetupGuestData - £"+ _cash + " ");
    }

	void HeadToReceptionist()
	{
		MoveTo sn = gameObject.GetComponent<MoveTo>();

		sn.DataDetails.SetMoveToString("Receptionist");
		sn.DataDetails.SetDialogueAction(EventManagerOriginal.DialogueAction.Hello);
		sn.DataDetails.SetDialogueAction(EventManagerOriginal.DialogueAction.CheckIn);
		sn.DataDetails.SetDialogueAction(EventManagerOriginal.DialogueAction.Accepted);
		sn.DataDetails.SetDialogueAction(EventManagerOriginal.DialogueAction.Denied);
		sn.DataDetails.SetDialogueAction(EventManagerOriginal.DialogueAction.GetKey);
        sn.enabled = true;

        //Turn on Guests Scripts
        ThoughtBubbles scriptThoughtBubbles = gameObject.GetComponentInChildren<ThoughtBubbles>();
        if (scriptThoughtBubbles != null)
        {
            CheckIn scriptcheckin = scriptThoughtBubbles.GetComponentInChildren<CheckIn>();
            if (scriptcheckin != null)
            {
                scriptcheckin.enabled = true;
            }
        }

        //Turn on Receptionist Scripts
        GameObject[] AllReceptionists = GameObject.FindGameObjectsWithTag("Receptionist");

        int whichPedIndex = 0;

        for (int i = 0; i < AllReceptionists.Length - 1; i++)
        {
            //Checks for choosing a receptionist, 
            whichPedIndex = i;
            i = AllReceptionists.Length;
        }

        GameObject TheReceptionist = AllReceptionists[whichPedIndex];
        ThoughtBubbles ReceptionistThoughtBubbles = TheReceptionist.GetComponentInChildren<ThoughtBubbles>();
        if (ReceptionistThoughtBubbles != null)
        {
            QuestionMark scriptQuestion = ReceptionistThoughtBubbles.GetComponentInChildren<QuestionMark>();
            if (scriptQuestion != null)
            {
                scriptQuestion.enabled = true;
            }

            if (_cash > _checkinCost)
            {
                Success scriptSuccess = ReceptionistThoughtBubbles.GetComponentInChildren<Success>();
                if (scriptSuccess != null)
                {
                    scriptSuccess.enabled = true;
                }
            }
            else
            {
                Failure scriptSuccess = ReceptionistThoughtBubbles.GetComponentInChildren<Failure>();
                if (scriptSuccess != null)
                {
                    scriptSuccess.enabled = true;
                }
            }
        }



    }
}
