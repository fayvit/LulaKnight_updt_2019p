using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UmaOpcaoDoIniciarJogo : UmaOpcao
{
    [SerializeField] private Image SpriteDoDeletar = null;
    [SerializeField] private Text txtdaqui = null;

    private System.Action<int> acaoDoIniciar;
    private System.Action<int> acaoDoDeletar;

    public bool IniciarEstaAtivo { get { return SpriteDoItem.color.a > 0; } }

    public string TxtDaqui { get { return txtdaqui.text; } }

    public void SetarOpcao(System.Action<int> acaoDoIniciar,System.Action<int> acaoDoDeletar,string txt)
    {
        this.acaoDoIniciar += acaoDoIniciar;
        this.acaoDoDeletar += acaoDoDeletar;
        txtdaqui.text = txt;
    }

    public override void FuncaoDoBotao()
    {
        acaoDoIniciar(transform.GetSiblingIndex() - 2);
    }

    public void BotaoDeletar()
    {
        Debug.Log("game number= " + (transform.GetSiblingIndex() - 2));

        acaoDoDeletar(transform.GetSiblingIndex() - 2);
    }

    public virtual void MudarOpcaoLocal()
    {
        if (SpriteDoDeletar.color.b > 0)
        {
            SpriteDoDeletar.color = new Color(1, 0, 0, 1);
            SpriteDoItem.color = new Color(1, 1, 1, 1);
        }
        else
        {
            SpriteDoDeletar.color = new Color(1, 1, 1, 1);
            SpriteDoItem.color = new Color(1, 0, 0, 1);
        }
    }

    public void ColocarTotalAlpha()
    {
        SpriteDoDeletar.color = new Color(1, 1, 1, 1);
        SpriteDoItem.color = new Color(1, 1, 1, 1);
    }

    
}
