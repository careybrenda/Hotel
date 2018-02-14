using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;






public abstract class DialogueBase : MonoBehaviour
{



    protected Details dataDetails;
    protected Details recievedData;

    protected RawImage Img;

    private float Timer;

    protected UnityAction<Details> someListener;

    protected abstract string GetEventTrigger();
    protected abstract EventManager.DialogueAction GetDialogueAction();








    protected void Initialise()
    {
        Img = gameObject.GetComponent<RawImage>();
        someListener = new UnityAction<Details>(RunEvent);
       // Color color = Img.material.color;
       // color.a = 255.0f; 
       // Img.material.color = color;
       // Debug.Log("RunEvent: Initialise called");
    }




    protected void SubscribeToEvent()
    {

        EventManager.StartListening(GetEventTrigger(), someListener);
    }

    protected void UnsubscribeToEvent()
    {
        EventManager.StopListening(GetEventTrigger(), someListener);
    }



    protected void RunEvent(Details data)
    {


        recievedData = data;

       // Debug.Log("RunEvent: This = " + this.ToString());

        if (data.GetTargetObj() == transform.parent.root.gameObject)
        {


            if (Img.enabled == false)
            {
                Timer = Time.time;
            }
            Img.enabled = true;
        }
    }



    protected bool IsEventDone()
    {
        if (Img != null)
        {
            if (Img.enabled == true)
            {
                if ((Time.time - Timer) > 2)
                {

                    
                    BuildEventStructForReturn();


                    EventManager.TriggerEvent(dataDetails);
                    Img.enabled = false;
                    this.enabled = false;
                    return true;
                }

            }
        }
        return false;
    }

    private void BuildEventStructForReturn()
    {

        dataDetails = recievedData;


        dataDetails.SetMoveToString(recievedData.GetMoveString());


        GameObject SwapObj = recievedData.GetSenderObj();
        dataDetails.SetSenderObj(recievedData.GetTargetObj());
        dataDetails.SetTargetObj(SwapObj);



    }

}

