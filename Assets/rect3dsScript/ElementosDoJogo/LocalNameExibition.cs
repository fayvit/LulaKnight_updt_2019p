using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalNameExibition : MonoBehaviour
{
    [SerializeField] private GameObject grandeDestaque = default;
    [SerializeField] private GameObject nomeDiscreto = default;

    private Image[] imgs;
    private Text txt;
    private EstadoDaqui estado = EstadoDaqui.emEspera;
    private float tempoDecorrido = 0;

    private float TEMPO_DE_FADE = 1f;
    private float TEMPO_MOSTRANDO = 5;

    private enum EstadoDaqui
    {
        emEspera,
        fadeIn,
        mostrando,
        fadeOut,
        concluido
    }

    private void Start()
    {
        EventAgregator.AddListener(EventKey.fadeOutStart, OnFadeOutStart);
    }

    private void OnDestroy()
    {
        EventAgregator.RemoveListener(EventKey.fadeOutStart, OnFadeOutStart);
    }

    void OnFadeOutStart(IGameEvent e)
    {
        if (estado == EstadoDaqui.fadeIn || estado == EstadoDaqui.mostrando)
        {
            estado = EstadoDaqui.fadeOut;
        }
    }

    private void Update()
    {
        switch (estado)
        {
            case EstadoDaqui.fadeIn:
                #region fadeIn
                tempoDecorrido += Time.deltaTime;
                if (tempoDecorrido <= TEMPO_DE_FADE)
                {
                    foreach (Image img in imgs)
                    {
                        Color C = img.color;
                        C.a = Mathf.Lerp(0, 1, tempoDecorrido / TEMPO_DE_FADE);
                        img.color = C;
                    }

                    Color Cc = txt.color;
                    Cc.a = Mathf.Lerp(0, 1, tempoDecorrido / TEMPO_DE_FADE);
                    txt.color = Cc;
                }
                else
                {
                    foreach (Image img in imgs)
                    {
                        Color C = img.color;
                        C.a = 1;
                        img.color = C;
                    }

                    Color Cc = txt.color;
                    Cc.a = 1;
                    txt.color = Cc;

                    estado = EstadoDaqui.mostrando;
                    tempoDecorrido = 0;
                }
                #endregion
            break;
            case EstadoDaqui.mostrando:

                #region mostrando
                tempoDecorrido += Time.deltaTime;

                if (tempoDecorrido > TEMPO_MOSTRANDO)
                {
                    estado = EstadoDaqui.fadeOut;
                    tempoDecorrido = 0;
                }
                #endregion

            break;
            case EstadoDaqui.fadeOut:

                #region fadeOut
                tempoDecorrido += Time.deltaTime;
                if (tempoDecorrido <= TEMPO_DE_FADE)
                {
                    foreach (Image img in imgs)
                    {
                        Color C = img.color;
                        C.a = Mathf.Lerp(1, 0, tempoDecorrido / TEMPO_DE_FADE);
                        img.color = C;
                    }

                    Color Cc = txt.color;
                    Cc.a = Mathf.Lerp(1, 0, tempoDecorrido / TEMPO_DE_FADE);
                    txt.color = Cc;
                }
                else
                {
                    foreach (Image img in imgs)
                    {
                        Color C = img.color;
                        C.a = 0;
                        img.color = C;
                    }

                    Color Cc = txt.color;
                    Cc.a = 0;
                    txt.color = Cc;

                    estado = EstadoDaqui.concluido;

                    grandeDestaque.SetActive(false);
                    nomeDiscreto.SetActive(false);

                    tempoDecorrido = 0;
                }
                #endregion
            break;
        }
    }

    public void RequestLocalNameExibition(string name,bool discreto,float tempoMostrando=5,float tempoDefade = 1)
    {
        TEMPO_DE_FADE = tempoDefade;
        TEMPO_MOSTRANDO = tempoMostrando;
        grandeDestaque.SetActive(false);
        nomeDiscreto.SetActive(false);
        if (discreto)
        {
            nomeDiscreto.SetActive(true);
            imgs = nomeDiscreto.GetComponentsInChildren<Image>();
            txt = nomeDiscreto.GetComponentInChildren<Text>();
            
        }
        else
        {
            grandeDestaque.SetActive(true);
            imgs = grandeDestaque.GetComponentsInChildren<Image>();
            txt = grandeDestaque.GetComponentInChildren<Text>();
            
        }

        foreach (Image img in imgs)
        {
            Color C = img.color;
            C.a = 0;
            img.color = C;
        }

        Color Cc = txt.color;
        Cc.a = 0;
        txt.color = Cc;

        txt.text = name;
        estado = EstadoDaqui.fadeIn;
        
    }

    
}

public enum SceneNamesForExibitions
{
    buscarPeloNomeDaCena=-1,
    ocupacaoDosResistentes,
    esgotoDosOportunistas,
    ExilioDasProfundezas,
    oAquiferoDoBuscador,
    caminhoDasCorredeiras,
    asGrandesCorredeiras,
    pontalDoAnteTeorema,
    cenaAtivaComunsDeFase
}
