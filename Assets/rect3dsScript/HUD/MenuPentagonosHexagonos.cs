using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MenuPentagonosHexagonos : MenuDeEvolucoesBase
{
    #region inspector
    [SerializeField] private Image partesDeHexagonoObtidas = null;
    [SerializeField] private Image partesDePentagonosObtidas = null;
    [SerializeField] private Sprite[] hexagonoSprites = null;
    [SerializeField] private Sprite[] pentagonoSprites = null;
    #endregion

    public override void IniciarHud()
    {
        DadosDoJogador dj = GameController.g.Manager.Dados;

        partesDeHexagonoObtidas.transform.parent.gameObject.SetActive(true);

        partesDeHexagonoObtidas.sprite = hexagonoSprites[dj.PartesDeHexagonoObtidas];
        partesDePentagonosObtidas.sprite = pentagonoSprites[dj.PartesDePentagonosObtidas];

        base.IniciarHud();
    }

    public override void FinalizarHud()
    {
        partesDeHexagonoObtidas.transform.parent.gameObject.SetActive(false);
    }
}