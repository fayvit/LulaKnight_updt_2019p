using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InterfaceLanguageConverter : MonoBehaviour
{
    private Text textoConvertivel;
#pragma warning disable 0649
    [SerializeField]private InterfaceTextKey key;
#pragma warning restore 0649
    public void MudaTexto()
    {
        if (textoConvertivel != null)
        {

            Debug.Log(BancoDeTextos.RetornaTextoDeInterface(key) + " : " + SaveDatesManager.s.ChosenLanguage);
            textoConvertivel.text = BancoDeTextos.RetornaTextoDeInterface(key);
        }
        else
        {
            new MyInvokeMethod().InvokeNoTempoReal(() => { MudaTexto(); }, 0.05f);
            Debug.Log("Fiz um Invoke de texto: "+gameObject);
        }
    }

    void OnEnable()
    {
        textoConvertivel = GetComponent<Text>();
        //MudaTexto();
        new MyInvokeMethod().InvokeNoTempoReal(gameObject,()=> { MudaTexto(); },0.05f);
    }

}