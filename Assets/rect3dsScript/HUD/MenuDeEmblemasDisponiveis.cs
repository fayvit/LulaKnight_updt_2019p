using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MenuDeEmblemasDisponiveis : MenusDeEmblemabase
{
    private int lineCellCount = 0;
    private System.Action<int> Acao;

    public void IniciarHud(System.Action<int> acaoDeFora)
    {
        Acao += acaoDeFora;
        DadosDoJogador dj = GameController.g.Manager.Dados;

        /*
        for (int i = 0; i < 12; i++)
        {
            dj.MeusEmblemas.Add(
                Emblema.GetEmblem(NomesEmblemas.ataqueAprimorado)
                );
        }*/

        if (dj.MeusEmblemas.Count>0)
            IniciarHUD(dj.MeusEmblemas.Count, TipoDeRedimensionamento.emGrade);
        else
            itemDoContainer.SetActive(false);

        lineCellCount = LineCellCount();

    }

    public override void SetarComponenteAdaptavel(GameObject G, int indice)
    {
        UmaOpcaoDeImage uma = G.GetComponent<UmaOpcaoDeImage>();

        Emblema E = GameController.g.Manager.Dados.MeusEmblemas[indice];

        //Texture2D t2d = (Texture2D)Resources.Load(E.NomeId.ToString());
        Sprite S = Resources.Load<Sprite>(E.NomeId.ToString());//Sprite.Create(t2d, new Rect(0, 0, t2d.width, t2d.height), t2d.texelSize);

        uma.SetarOpcoes(S,Acao);

        if(E.EstaEquipado)
            uma.ImgDoEncaixado.gameObject.SetActive(true);
        else
            uma.ImgDoEncaixado.gameObject.SetActive(false);
    }

    protected override void FinalizarEspecifico()
    {
        Acao = null;
    }

    int LineCellCount()
    {
        GridLayoutGroup grid = painelDeTamanhoVariavel.GetComponent<GridLayoutGroup>();

        return
            (int)(painelDeTamanhoVariavel.rect.width / (grid.cellSize.x + grid.spacing.x));
    }

    int RowCellCount()
    {
        GridLayoutGroup grid = painelDeTamanhoVariavel.GetComponent<GridLayoutGroup>();

        return
            (int)(painelDeTamanhoVariavel.rect.height / (grid.cellSize.y + grid.spacing.y));
    }

    public override void MudarOpcao()
    {
        int opcaoEscolhidaAnterior = OpcaoEscolhida;

        int quanto = -lineCellCount * CommandReader.ValorDeGatilhos("VDpad", GameController.g.Manager.Control);

        if (quanto == 0)
            quanto = -lineCellCount * CommandReader.ValorDeGatilhosTeclado("vertical", GameController.g.Manager.Control);

        if (quanto == 0)
            quanto = CommandReader.ValorDeGatilhos("HDpad", GameController.g.Manager.Control) + CommandReader.ValorDeGatilhos("horizontal", GameController.g.Manager.Control);

        MudarOpcaoComVal(quanto, lineCellCount);

        if (quanto != 0)
        {
            EventAgregator.Publish(new StandardSendGameEvent(EventKey.UiDeEmblemasChange, "disponivel",
                VerificaMudouDepainel(quanto, opcaoEscolhidaAnterior), OpcaoEscolhida));
        }
    }

    bool VerificaMudouDepainel(int quanto,int opcaoEscolhidaAnterior)
    {
        bool retorno = false;

        if (opcaoEscolhidaAnterior + quanto != OpcaoEscolhida && Mathf.Abs(quanto) > 1)
        {
            SelecionarOpcaoEspecifica(opcaoEscolhidaAnterior);
            retorno = true;
        }
        return retorno;
    }
}