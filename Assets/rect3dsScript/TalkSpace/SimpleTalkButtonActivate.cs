using UnityEngine;

namespace TalkSpace
{
    public class SimpleTalkButtonActivate : TalkButtonActivate
    {
        [SerializeField] private ChaveDeTexto chaveDaConversa = ChaveDeTexto.bomDia;
        [SerializeField] private Sprite fotoDoNPC = null;
        new void Start()
        {
            base.Start();

            NPC.ChangeTalkKey(chaveDaConversa);
            NPC.ChangeSpriteView(fotoDoNPC);
            
            
        }
    }
}
