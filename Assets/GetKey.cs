using UnityEngine;

public class GetKey : DialogueBase
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
        return EventManager.DialogueAction.GetKey.ToString();
    }

    protected override EventManager.DialogueAction GetDialogueAction()
    {
        return EventManager.DialogueAction.GetKey;
    }

    void Update()
    {
        AnimateUp();
        IsEventDone();
    }

    void AnimateUp()
    {
        



        if (base.Img.IsActive())
        {
           
            base.Img.transform.Translate(new Vector3(0.0f, 0.01f, 0.0f));
            Color color = base.Img.color;
            color.a -= 0.01f;
            if((color.a) < 0)
            {
                color.a = 0.0f;
            }

            base.Img.color = color;
        }
    }

}
