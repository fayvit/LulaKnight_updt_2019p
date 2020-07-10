using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RequestLocalNameExibition : MonoBehaviour
{
    [SerializeField] private string ID;
    [SerializeField] private bool sempreDiscreto = false;
    [SerializeField] private bool esperarPeloTrigger = false;
    [SerializeField] private SceneNamesForExibitions localName = SceneNamesForExibitions.buscarPeloNomeDaCena;

    private bool triggerFoirAgora = false;

    private void Start()
    {
        if (localName == SceneNamesForExibitions.buscarPeloNomeDaCena)
        {
            string n = SceneManager.GetActiveScene().name;
            Debug.Log(n);
            localName = StringParaEnum.ObterEnum<SceneNamesForExibitions>(n);
        }

        EventAgregator.AddListener(EventKey.localNameExibition, OnRequestLocalNameExibition);

        CoroutineObject.Instance.StartCoroutine(VerifiqueMostrarLocalName(SceneManager.GetActiveScene().name));
    }

    private void OnDestroy()
    {
        EventAgregator.RemoveListener(EventKey.localNameExibition, OnRequestLocalNameExibition);
    }

    IEnumerator VerifiqueMostrarLocalName(string name)
    {
        yield return new WaitForSeconds(2);

        if(SceneManager.GetActiveScene().name==name)
            EventAgregator.Publish(EventKey.localNameExibition);

    }

    void OnRequestLocalNameExibition(IGameEvent e)
    {
        if (GameController.g.MyKeys.VerificaCont(KeyCont.ultimoLocalNameExibido)!= (int)localName)
        {
            if (GameController.g.MyKeys.VerificaAutoShift(ID) && !triggerFoirAgora)
            {
                GameController.g.LocalName.RequestLocalNameExibition(
                        BancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.nomesParaCenarios)[(int)localName], true);
            }
            else if (!esperarPeloTrigger)
            {
                MostrarNomeDoCenario();
            }

            GameController.g.MyKeys.MudaCont(KeyCont.ultimoLocalNameExibido, (int)localName);
        }
    }

    private void OnValidate()
    {
        BuscadorDeID.Validate(ref ID, this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !GameController.g.MyKeys.VerificaAutoShift(ID))
        {
            if (UnicidadeDoPlayer.Verifique(collision))
            {
                triggerFoirAgora = true;
                MostrarNomeDoCenario();
                
            }
        }
    }

    void MostrarNomeDoCenario()
    {
        GameController.g.LocalName.RequestLocalNameExibition(
                        BancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.nomesParaCenarios)[(int)localName], sempreDiscreto);
        EventAgregator.Publish(new StandardSendGameEvent(EventKey.requestChangeShiftKey, ID));
        
    }
}
