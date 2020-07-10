using UnityEngine;

[System.Serializable]
public class MenuBasico : UiDeOpcoes
{
    private string[] opcoes;
    private System.Action<int> acao;
    private bool estadoDeAcao = false;

    protected System.Action<int> Acao
    {
        get { return acao; }
    }

    protected string[] Opcoes
    {
        get { return opcoes; }
    }

    public void IniciarHud(
        System.Action<int> acao,
        string[] txDeOpcoes,
        TipoDeRedimensionamento tipoDeR = TipoDeRedimensionamento.vertical)
    {
        this.opcoes = txDeOpcoes;
        this.acao += (int x) => {
            if (!estadoDeAcao)
            {
                estadoDeAcao = true;
                MudarSelecaoParaEspecifico(x);

                new MyInvokeMethod().InvokeNoTempoReal(() =>
                {
                    Debug.Log("Função chamada com delay para destaque do botão");
                    acao(x);
                    estadoDeAcao = false;
                }, .05f);
            }
        };

        IniciarHUD(opcoes.Length, tipoDeR);

        
    }

    public override void SetarComponenteAdaptavel(GameObject G, int indice)
    {
        UmaOpcaoDeMenu uma = G.GetComponent<UmaOpcaoDeMenu>();
        uma.SetarOpcao(acao, opcoes[indice]);
    }

    protected override void FinalizarEspecifico()
    {
        
        acao = null;
        //Seria preciso uma finalização especifica??
    }
}
