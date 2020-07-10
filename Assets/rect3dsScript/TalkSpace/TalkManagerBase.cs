using UnityEngine;
using System.Collections;

namespace TalkSpace
{
    [System.Serializable]
    public class TalkManagerBase
    {
        [SerializeField] protected Sprite fotoDoNPC;

        private ChaveDeTexto chaveDaConversa = ChaveDeTexto.bomDia;        

        protected EstadoDoNPC estado = EstadoDoNPC.parado;
        protected string[] conversa;

        protected enum EstadoDoNPC
        {
            caminhando,
            parado,
            conversando,
            finalizadoComBotao
        }

        public void ChangeTalkKey(ChaveDeTexto chave)
        {
            conversa = BancoDeTextos.RetornaListaDeTextoDoIdioma(chave).ToArray();
        }

        public void ChangeSpriteView(Sprite S)
        {
            fotoDoNPC = S;
        }

        public void Start()
        {
            conversa = BancoDeTextos.RetornaListaDeTextoDoIdioma(chaveDaConversa).ToArray();
        }

        // Update is called once per frame
        public virtual bool Update()
        {
            switch (estado)
            {

                case EstadoDoNPC.conversando:
                    
                    if (GameController.g.DisparaT.UpdateDeTextos(conversa, fotoDoNPC))
                    {
                        FinalizaConversa();
                    }
                break;
                case EstadoDoNPC.finalizadoComBotao:
                    estado = EstadoDoNPC.parado;
                    return true;
            }

            return false;
        }

        protected virtual void FinalizaConversa()
        {
            estado = EstadoDoNPC.finalizadoComBotao;

            EventAgregator.Publish(new StandardSendGameEvent(EventKey.finalizaDisparaTexto));

        }

        public virtual void IniciaConversa()
        {
            // siga.PareAgora();

            EventAgregator.Publish(new StandardSendGameEvent(EventKey.inicializaDisparaTexto));
            GameController.g.DisparaT.IniciarDisparadorDeTextos();

            estado = EstadoDoNPC.conversando;
        }
    }
}