using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MenuDeEvolucoesBase
{
    #region inspector
    [SerializeField] private Text numHexagonosCompletados = null;
    [SerializeField] private Text numPentagonosCompletados = null;
    [SerializeField] private Text totalDeHp = null;
    [SerializeField] private Text totalDeMp = null;    
    #endregion

    public virtual void IniciarHud()
    {
        DadosDoJogador dj = GameController.g.Manager.Dados;

        numHexagonosCompletados.text = dj.HexagonosCompletados.ToString();
        numPentagonosCompletados.text = dj.PentagonosCompletados.ToString();
        totalDeHp.text = dj.PontosDeVida + " / " + dj.MaxVida;
        totalDeMp.text = dj.PontosDeMana + " / " + dj.MaxMana;
    }

    public virtual void FinalizarHud()
    {
        
    }
}