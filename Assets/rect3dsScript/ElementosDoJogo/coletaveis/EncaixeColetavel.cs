using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncaixeColetavel : ColetavelBase
{
    protected override void AcaoEspecificaDaColeta()
    {
        EventAgregator.Publish(EventKey.getNotch, null);
        EventAgregator.Publish(new StandardSendGameEvent(EventKey.disparaSom, SoundEffectID.painelAbrindo));
        new MyInvokeMethod().InvokeNoTempoReal(()=> {
            EventAgregator.Publish(new StandardSendGameEvent(EventKey.disparaSom, SoundEffectID.vinhetinhaDoSite));
        },.25f);
    }

    protected override void OnClosePanel()
    {
        EventAgregator.Publish(new StandardSendGameEvent(EventKey.disparaSom, SoundEffectID.Book1));
        EventAgregator.Publish(new StandardSendGameEvent(EventKey.requestShowControllers));
        base.OnClosePanel();
    }
}
