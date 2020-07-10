using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MenuDosMilitantes : MenuDeEvolucoesBase
{
    [SerializeField] private Image[] militanteDeCoragemPorFormarGrupo = default;
    [SerializeField] private Image[] militanteDePerseverancaPorFormarGrupo = default;
    [SerializeField] private Sprite militanteDeCoragem = default;
    [SerializeField] private Sprite militanteDeperseveranca = default;
    [SerializeField] private Sprite sombraDoMilitante = default;

    public override void IniciarHud()
    {
        DadosDoJogador dj = GameController.g.Manager.Dados;

        militanteDeCoragemPorFormarGrupo[0].transform.parent.parent.gameObject.SetActive(true);

        for (int i = 0; i < militanteDeCoragemPorFormarGrupo.Length; i++)
        {
            if (dj.PartesDeHexagonoObtidas > i)
                militanteDeCoragemPorFormarGrupo[i].sprite = militanteDeCoragem;
            else
                militanteDeCoragemPorFormarGrupo[i].sprite = sombraDoMilitante;
        }

        for (int i = 0; i < militanteDePerseverancaPorFormarGrupo.Length; i++)
        {
            if (dj.PartesDePentagonosObtidas > i)
                militanteDePerseverancaPorFormarGrupo[i].sprite = militanteDeperseveranca;
            else
                militanteDePerseverancaPorFormarGrupo[i].sprite = sombraDoMilitante;
        }
        base.IniciarHud();
    }

    public override void FinalizarHud()
    {
        militanteDeCoragemPorFormarGrupo[0].transform.parent.parent.gameObject.SetActive(false);
    }
}
