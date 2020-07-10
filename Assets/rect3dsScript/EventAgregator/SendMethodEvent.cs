using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMethodEvent : IGameEvent
{
    public object[] MyObject;
    public System.Action Acao;
    public GameObject sender;

    public EventKey key;

    public SendMethodEvent(EventKey key, System.Action acao, params object[] o)
    {

        this.key = key;
        Acao += acao;
        MyObject = o;

    }

    public GameObject Sender
    {
        get
        {
            return sender;
        }
    }

    public EventKey Key
    {
        get
        {
            return key;
        }
    }
}
