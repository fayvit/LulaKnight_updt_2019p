using UnityEngine;
using UnityEngine.UI;

public class PainelPentagonoHexagono : PainelUmaMensagem
{
    #region inspector
    [SerializeField] private Text textoDaDescricao = null;
    [SerializeField] private Image imgDaqui = null;
    [SerializeField] private Sprite[] labelImages = null;
    #endregion

    public enum EstiloColetavel
    {
        militanteDePerseveranca,
        militanteDeCoragem,
        diplomaHonorisCausa
    }

    protected Sprite[] LabelImages { get { return labelImages; } }

    public void ConstroiPainelDosPentagonosOuHexagonos(System.Action r,EstiloColetavel f)
    {
        string[] s = BancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.frasesDeColetaveis).ToArray();

        EventAgregator.Publish(new StandardSendGameEvent(EventKey.requestHideControllers));

        if (f == EstiloColetavel.militanteDeCoragem)
        {
            ConstroiPainelUmaMensagem(r, s[0]);
            textoDaDescricao.text = s[1];
            ModificarSprites(GameController.g.Manager.Dados.PartesDeHexagonoObtidas);
            //imgDaqui.sprite = labelImages[];
        }
        else if (f == EstiloColetavel.militanteDePerseveranca)
        {
            ConstroiPainelUmaMensagem(r, s[2]);
            textoDaDescricao.text = s[3];
            ModificarSprites(GameController.g.Manager.Dados.PartesDePentagonosObtidas);
        }
        else if (f == EstiloColetavel.diplomaHonorisCausa)
        {
            ConstroiPainelUmaMensagem(r, s[4]);
            textoDaDescricao.text = s[5];
        }
        else
        {
            ConstroiPainelUmaMensagem(r);
        }
    }

    public virtual void ModificarSprites(int quantas)
    {
        imgDaqui.sprite = labelImages[quantas];
    }
}
