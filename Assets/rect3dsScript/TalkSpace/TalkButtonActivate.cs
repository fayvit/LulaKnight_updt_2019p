using UnityEngine;

namespace TalkSpace
{
    public class TalkButtonActivate : AtivadorDeBotao
    {
        
        [SerializeField]
        private NameMusicaComVolumeConfig nameMusic = new NameMusicaComVolumeConfig()
        {
            Musica = NameMusic.nula,
            Volume = 1
        };

        protected TalkManagerBase NPC { get; set; } = new TalkManagerBase();

        // Use this for initialization
        protected void Start()
        {

            NPC.Start();
            
            SempreEstaNoTrigger();
        }

        new protected void Update()
        {
            base.Update();

            if (NPC.Update())
            {
                OnFinishTalk();
            }
        }

        protected virtual void OnFinishTalk()
        {
            EventAgregator.Publish(EventKey.returnRememberedMusic, null);
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

                NPC.IniciaConversa();

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
}