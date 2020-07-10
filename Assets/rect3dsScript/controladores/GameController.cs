﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapConstructor;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    public static GameController g;

    #region inspector
    [SerializeField] private DisparaTexto disparaT;
    [SerializeField] private PauseMenu pauseM = null;
    [SerializeField] private GameObject sacoDeDinheiro = null;
    [SerializeField] private PainelUmaMensagem painelDeInfoEmblema = null;
    [SerializeField] private LocalNameExibition localName = null;
    #endregion

    private MapConstruct mapConstruct = new MapConstruct();

    private EstadoDoJogo estado = EstadoDoJogo.emGame;
    private KeyVar mykeys = new KeyVar();
    private CharacterManager manager = null;

    private enum EstadoDoJogo
    {
        emGame,
        emPause
    }

    public KeyVar MyKeys { get { return mykeys; } private set { mykeys = value; } }

    public CharacterManager Manager { get { return manager; } set { manager = value; } }
    public DisparaTexto DisparaT { get { return disparaT; } set { disparaT = value; } }
    public LocalNameExibition LocalName { get { return localName; } set { localName = value; } }
    public Texture2D MapTexture { get { return SaveMap.Carregar(UpdateMap.FileName); } }
    

    private void Awake()
    {
        GameController[] gg = FindObjectsOfType<GameController>();

        if (gg.Length > 1)
            Destroy(gameObject);

        if (g == null)
            g = this;

    }

    // Start is called before the first frame update
    void Start()
    {
       
        

        transform.parent = null;
        DontDestroyOnLoad(gameObject);

        EventAgregator.AddListener(EventKey.requestToFillDates, OnRequestFillDates);
        EventAgregator.AddListener(EventKey.enemyDefeatedCheck, OnEnemyDefeatedCheck);
        EventAgregator.AddListener(EventKey.destroyFixedShiftCheck, OnIdDestroyCheck);
        EventAgregator.AddListener(EventKey.requestChangeEnemyKey, OnRequestChangeEnemyKey);
        EventAgregator.AddListener(EventKey.destroyShiftCheck, MyDestroyShiftCheck);
        EventAgregator.AddListener(EventKey.requestChangeShiftKey, OnRequestChangeShiftKey);
        EventAgregator.AddListener(EventKey.enterPause, OnEnterPause);
        EventAgregator.AddListener(EventKey.exitPause, OnExitPause);
        EventAgregator.AddListener(EventKey.requestInfoEmblemPanel, OnRequestInfoEmbelmPanel);
        EventAgregator.AddListener(EventKey.sumContShift, OnRequestSumContShift);
        EventAgregator.AddListener(EventKey.getUpdateGeometry, OnGetUpdateGeometry);
        EventAgregator.AddListener(EventKey.emblemEquip, OnEquipEmblem);
        EventAgregator.AddListener(EventKey.emblemUnequip, OnUnequipEmblem);
        EventAgregator.AddListener(EventKey.requestLocalnameExibition, OnRequestNameexibition);
        EventAgregator.AddListener(EventKey.changeActiveScene, OnChangeActiveScene);
        EventAgregator.AddListener(EventKey.changeMapLimits, OnChangeMapLimits);
        EventAgregator.AddListener(EventKey.requestMapClearPixels, OnRequestMapClearPixels);
        EventAgregator.AddListener(EventKey.abriuPainelSuspenso, OnOpenExternalPanel);
        EventAgregator.AddListener(EventKey.fechouPainelSuspenso, OnCloseExternalPanel);
        //InterstialAdManager.AgendarEventos();

        //disparaT.IniciarDisparadorDeTextos();
        MyKeys.MudaShift(KeyShift.sempretrue, true);

    }

    private void OnDestroy()
    {
        EventAgregator.RemoveListener(EventKey.requestToFillDates, OnRequestFillDates);
        EventAgregator.RemoveListener(EventKey.enemyDefeatedCheck, OnEnemyDefeatedCheck);
        EventAgregator.RemoveListener(EventKey.destroyFixedShiftCheck, OnIdDestroyCheck);
        EventAgregator.RemoveListener(EventKey.requestChangeEnemyKey, OnRequestChangeEnemyKey);
        EventAgregator.RemoveListener(EventKey.destroyShiftCheck, MyDestroyShiftCheck);
        EventAgregator.RemoveListener(EventKey.requestChangeShiftKey, OnRequestChangeShiftKey);
        EventAgregator.RemoveListener(EventKey.enterPause, OnEnterPause);
        EventAgregator.RemoveListener(EventKey.exitPause, OnExitPause);
        EventAgregator.RemoveListener(EventKey.requestInfoEmblemPanel, OnRequestInfoEmbelmPanel);
        EventAgregator.RemoveListener(EventKey.sumContShift, OnRequestSumContShift);
        EventAgregator.RemoveListener(EventKey.getUpdateGeometry, OnGetUpdateGeometry);
        EventAgregator.RemoveListener(EventKey.emblemEquip, OnEquipEmblem);
        EventAgregator.RemoveListener(EventKey.emblemUnequip, OnUnequipEmblem);
        EventAgregator.RemoveListener(EventKey.requestLocalnameExibition, OnRequestNameexibition);
        EventAgregator.RemoveListener(EventKey.changeActiveScene, OnChangeActiveScene);
        EventAgregator.RemoveListener(EventKey.changeMapLimits, OnChangeMapLimits);
        EventAgregator.RemoveListener(EventKey.requestMapClearPixels, OnRequestMapClearPixels);
        EventAgregator.RemoveListener(EventKey.abriuPainelSuspenso, OnOpenExternalPanel);
        EventAgregator.RemoveListener(EventKey.fechouPainelSuspenso, OnCloseExternalPanel);
        // InterstialAdManager.RemoverEventos();
    }

    private void OnOpenExternalPanel(IGameEvent e)
    {
        pauseM.DisablePauseMenu();
    }

    private void OnCloseExternalPanel(IGameEvent e)
    {
        pauseM.RestorePauseMenu();
    }

    private void OnRequestMapClearPixels(IGameEvent e)
    {
        Tilemap myCollider = (Tilemap)((StandardSendGameEvent)e).MyObject[0];
        VerifiqueExistenciaDoMapConstruct();

        mapConstruct.DeletarPixelsDoMapa(myCollider);

        new MyInvokeMethod().InvokeAoFimDoQuadro(() =>
        {
            mapConstruct.AtualizarMapa();
        });
    }

    private void OnChangeMapLimits(IGameEvent e)
    {
        StandardSendGameEvent ssge = e as StandardSendGameEvent;
        mykeys.LimitanteDoMapaAtual = (LimitantesDeMapa)ssge.MyObject[0];
    }

    private void OnChangeActiveScene(IGameEvent e)
    {
        if (!mykeys.VerificaAutoShift(MapInfos.ThisMapID))
        {
            VerifiqueExistenciaDoMapConstruct();
            mapConstruct.AtualizarMapa();
            mykeys.MudaAutoShift(MapInfos.ThisMapID, true);
        }
    }

    void VerifiqueExistenciaDoMapConstruct()
    {
        if (mapConstruct == null)
            mapConstruct = new MapConstruct();
    }

    private void OnRequestNameexibition(IGameEvent e)
    {
        StandardSendGameEvent ssge = (StandardSendGameEvent)e;

        if (ssge.MyObject.Length < 3)
        {
            LocalName.RequestLocalNameExibition((string)ssge.MyObject[0], (bool)ssge.MyObject[1]);
        }else if (ssge.MyObject.Length == 3)
            LocalName.RequestLocalNameExibition((string)ssge.MyObject[0], (bool)ssge.MyObject[1],(float)ssge.MyObject[2]);
        else if(ssge.MyObject.Length==4)
            LocalName.RequestLocalNameExibition((string)ssge.MyObject[0], (bool)ssge.MyObject[1], (float)ssge.MyObject[2],(float)ssge.MyObject[3]);
    }

    private void OnUnequipEmblem(IGameEvent obj)
    {
        StandardSendGameEvent ssge = (StandardSendGameEvent)obj;

        NomesEmblemas nomeID = (NomesEmblemas)ssge.MyObject[0];
        switch (nomeID)
        {
            default:
                MyKeys.MudaAutoShift("equiped_" + nomeID.ToString(), false);
            break;
        }
    }

    private void OnEquipEmblem(IGameEvent obj)
    {
        StandardSendGameEvent ssge = (StandardSendGameEvent)obj;

        NomesEmblemas nomeID = (NomesEmblemas)ssge.MyObject[0];
        switch (nomeID)
        {
            default:
                MyKeys.MudaAutoShift("equiped_" + nomeID.ToString(), true);
            break;
        }

        TrophiesManager.VerifyTrophy(TrophyId.coloqueEmblemaNaEspada);
    }

    private void OnGetUpdateGeometry(IGameEvent e)
    {
        StandardSendGameEvent ssge = (StandardSendGameEvent)e;
        HexagonoColetavelBase.DadosDaGeometriaColetavel d = (HexagonoColetavelBase.DadosDaGeometriaColetavel)ssge.MyObject[0];

        OnRequestChangeShiftKey(new StandardSendGameEvent(EventKey.requestChangeShiftKey, d.ID));
    }

    private void OnRequestSumContShift(IGameEvent obj)
    {
        StandardSendGameEvent ssge = (StandardSendGameEvent)obj;

        if (ssge.MyObject[0] is KeyCont)
        {
            MyKeys.SomaCont((KeyCont)ssge.MyObject[0], (int)ssge.MyObject[1]);
            Debug.Log((KeyCont)ssge.MyObject[0] + " : " + (int)ssge.MyObject[1] + " : " + MyKeys.VerificaCont((KeyCont)ssge.MyObject[0]));
        }else if(ssge.MyObject[0] is string)
            MyKeys.SomaAutoCont((string)ssge.MyObject[0], (int)ssge.MyObject[1]);
    }

    private void OnRequestInfoEmbelmPanel(IGameEvent e)
    {
        SendMethodEvent sme = (SendMethodEvent)e;

        painelDeInfoEmblema.ConstroiPainelUmaMensagem(sme.Acao);
    }

    private void OnExitPause(IGameEvent obj)
    {
        estado = EstadoDoJogo.emGame;
    }

    private void OnEnterPause(IGameEvent e)
    {
        estado = EstadoDoJogo.emPause;
    }

    private void OnRequestChangeShiftKey(IGameEvent obj)
    {
        StandardSendGameEvent ssge = (StandardSendGameEvent)obj;

       
        if (ssge.MyObject[0] is string)
        {
            string key = (string)ssge.MyObject[0];
            if (ssge.MyObject.Length < 2)
            {
                MyKeys.MudaAutoShift(key, true);
            }
            else
            {
                MyKeys.MudaAutoShift(key, (bool)ssge.MyObject[1]);
            }
        }
        else if (ssge.MyObject[0] is KeyShift)
        {
            KeyShift keyS = (KeyShift)ssge.MyObject[0];

            if (ssge.MyObject.Length < 2)
            {
                MyKeys.MudaShift(keyS, true);
            }else
                MyKeys.MudaShift(keyS, (bool)ssge.MyObject[1]);
        }
        else
        {
            Debug.Log("O parametro não foi considerado util pelo tratamento do change key");
        }
        
        /*
        try
        {
            string key = (string)ssge.MyObject[0];
            MyKeys.MudaAutoShift(key, true);
        } catch
        {
            Debug.Log("O tratamento de erro levou para keyShift");
            KeyShift keyS = (KeyShift)ssge.MyObject[0];
            MyKeys.MudaShift(keyS, true);
        }*/
    }

    private void OnIdDestroyCheck(IGameEvent e)
    {
        StandardSendGameEvent ssge = (StandardSendGameEvent)e;
        if (MyKeys.VerificaAutoShift((KeyShift)ssge.MyObject[0]))
            Destroy((GameObject)ssge.MyObject[1]);
    }

    private void MyDestroyShiftCheck(IGameEvent obj)
    {
        StandardSendGameEvent ssge = (StandardSendGameEvent)obj;
        if (MyKeys.VerificaAutoShift((string)ssge.MyObject[0]))
            Destroy((GameObject)ssge.MyObject[1]);
    }

    private void OnRequestChangeEnemyKey(IGameEvent obj)
    {
        StandardSendGameEvent ssge = (StandardSendGameEvent)obj;
        MyKeys.MudaEnemyShift((string)ssge.MyObject[0], true);
    }

    private void OnEnemyDefeatedCheck(IGameEvent obj)
    {
        StandardSendGameEvent ssge = (StandardSendGameEvent)obj;
        if (MyKeys.VerificaEnemyShift((string)ssge.MyObject[0]))
            Destroy(ssge.Sender);
    }

    private void OnRequestFillDates(IGameEvent e)
    {
        StandardSendGameEvent ssge = (StandardSendGameEvent)e;
        SaveDates S = (SaveDates)ssge.MyObject[0];

        if (S == null)
        {
            MyKeys = new KeyVar();
        }
        else
        {
            VerifiqueDinheiroCaido(S.Dados.DinheiroCaido);

            MyKeys = S.VariaveisChave;
        }

        /*
        new InvokeAposQuadros().Invoke(3, () =>
        {
            UpdateMap.Limit = MyKeys.LimitanteDoMapaAtual;
            OnChangeActiveScene(null);
        });
        */
            
        new MyInvokeMethod().InvokeAoFimDoQuadro(() => {
            new MyInvokeMethod().InvokeAoFimDoQuadro(() => {
                new MyInvokeMethod().InvokeAoFimDoQuadro(() =>
                {
                    //mapConstruct.GetMapDates = MyKeys.MapDates;
                    UpdateMap.Limit = MyKeys.LimitanteDoMapaAtual;
                    OnChangeActiveScene(null);
                });
            });
        });

    }

    public void VerifiqueDinheiroCaido(DinheiroCaido d)
    {
        
       // Debug.Log(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name + " : " + d.cenaOndeCaiu.ToString());

        if (d.estaCaido
            &&
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == d.cenaOndeCaiu.ToString())
        {
            DestuaSacoDeDinheiroAntigo();
            GameObject G = Instantiate(sacoDeDinheiro, MelhoraPos.NovaPos(d.Pos, 2.5f), Quaternion.identity);
            G.SetActive(true);
        }
    }

    void DestuaSacoDeDinheiroAntigo()
    {
        SacoDeDinheiro saco = FindObjectOfType<SacoDeDinheiro>();

        if (saco != null)
            Destroy(saco.gameObject);


    }

        // Update is called once per frame
    void Update()
    {
        switch (estado)
        {
            case EstadoDoJogo.emGame:
                if (CommandReader.ButtonUp(6, GlobalController.g.Control) || CommandReader.ButtonUp(7, GlobalController.g.Control))
                {
                    BtnPauseMenu();
                }
            break;
            case EstadoDoJogo.emPause:
                pauseM.Update();
            break;
        }
    }

    public void BtnPauseMenu()
    {
        pauseM.BtnPauseMenu();
    }

    public void BtnMudarAba()
    {
        GameObject c = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        //Debug.Log(c.name);
        pauseM.BtnTrocarAba(c.transform.GetSiblingIndex());
    }
}