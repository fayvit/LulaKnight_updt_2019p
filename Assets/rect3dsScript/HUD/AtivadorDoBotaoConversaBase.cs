using UnityEngine;
using System.Collections;

public class AtivadorDoBotaoConversaBase : AtivadorDeBotao
{
    [SerializeField]
    private NameMusicaComVolumeConfig nameMusic = new NameMusicaComVolumeConfig()
    {
        Musica = NameMusic.nula,
        Volume = 1
    };

    protected NPCdeConversa NPC { get; set; }

    //private Vector3 forwardInicialDoBotao;

    // Use this for initialization
    protected void Start()
    {
        NPC.Start(transform);
        // forwardInicialDoBotao = btn.transform.parent.forward;
        SempreEstaNoTrigger();
    }

    new protected void Update()
    {
        base.Update();

        /*
        if (btn.activeSelf)
            btn.transform.parent.forward = forwardInicialDoBotao;*/

        if (NPC.Update())
        {
            OnFinishTalk();
        }
    }

    protected virtual void OnFinishTalk()
    {
        EventAgregator.Publish(EventKey.returnRememberedMusic, null);
        //GameController.g.Manager.AoHeroi();
    }

    void BotaoConversa()
    {
        if (gameObject.activeSelf)
        {
            if (nameMusic.Musica != NameMusic.nula)
            {
                EventAgregator.Publish(new StandardSendGameEvent(EventKey.changeMusicWithRecovery, nameMusic));
            }
            FluxoDeBotao();

            //Transform T = TransformPosDeConversa.MeAjude(transform);

            NPC.IniciaConversa();

            //AplicadorDeCamera.cam.InicializaCameraExibicionista(T, 1, true);
            OnStartTalk();
        }
    }

    protected virtual void OnStartTalk()
    {

    }

    public override void FuncaoDoBotao()
    {
        BotaoConversa();
    }
}
