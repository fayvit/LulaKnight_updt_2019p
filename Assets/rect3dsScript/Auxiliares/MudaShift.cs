using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudaShift : MonoBehaviour
{
    [SerializeField] private KeyShift qualShift = KeyShift.sempretrue;
    [SerializeField] private string stringKey = "";

    [SerializeField] private bool mudarShift = false;
    [SerializeField] private bool mudarStringKey = false;

    // Start is called before the first frame update
    void Start()
    {
        if (mudarShift)
        {
            EventAgregator.Publish(new StandardSendGameEvent(EventKey.requestChangeShiftKey, qualShift));
            Debug.Log(qualShift + " : " + GameController.g.MyKeys.VerificaAutoShift(qualShift));
        }

        if (mudarStringKey)
        {
            EventAgregator.Publish(new StandardSendGameEvent(EventKey.requestChangeShiftKey, stringKey));
            Debug.Log(stringKey + " : " + GameController.g.MyKeys.VerificaAutoShift(stringKey));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
