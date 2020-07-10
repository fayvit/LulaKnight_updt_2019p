using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSoundManager : MonoBehaviour
{
    [SerializeField] private EscolhaDeAudioPonderada[] clipesParaSorteio = default;
    [SerializeField] private EventKey eventKey = default;
    [SerializeField] private bool usarSoundInterval = false;
    [SerializeField] private bool permitirNovoSom = true;
    [SerializeField] private float interval = 1;

    private void Start()
    {
        EventAgregator.AddListener(eventKey, OnRequestSound);
    }

    private void OnDestroy()
    {
        EventAgregator.RemoveListener(eventKey, OnRequestSound);
    }

    private void OnRequestSound(IGameEvent obj)
    {
        if (obj.Sender == gameObject && permitirNovoSom)
        {
            EventAgregator.Publish(
                new StandardSendGameEvent(
                    EventKey.disparaSom, 
                    EscolhaDeAudioPonderada.RetorneAudioSorteado(clipesParaSorteio)));

            if (usarSoundInterval)
            {
                permitirNovoSom = false;
                new MyInvokeMethod().InvokeNoTempoDeJogo(gameObject, () =>
                {
                    permitirNovoSom = true;
                }, interval);
            }
        }
    }
}

[System.Serializable]
public struct EscolhaDeAudioPonderada
{
    public AudioClip clip;
    public float peso;

    public static AudioClip RetorneAudioSorteado(EscolhaDeAudioPonderada[] e)
    {
        AudioClip retorno = default;
        float soma = 0;
        for (int i = 0; i < e.Length; i++)
        {
            soma += e[i].peso;
        }

        float sorteado = Random.Range(0, soma);

        soma = 0;

        for (int i = 0; i < e.Length; i++)
        {
            soma += e[i].peso;
            if (soma >= sorteado)
            {
                retorno = e[i].clip;
                break;
            }
        }
        return retorno;
    }
}
