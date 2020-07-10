using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeAposQuadros
{
    private System.Action acao;
    private int contQuadros = 0;
    private uint totalQuadros = 1;
    private MyInvokeMethod my = new MyInvokeMethod();

    void Acao()
    {
        acao();
        acao = null;
    }

    public void Invoke(uint quadros, System.Action acao)
    {
        contQuadros = 0;
        totalQuadros = quadros;
        this.acao = acao;
        my.InvokeAoFimDoQuadro(()=> { ContaQuadros(); });
    }

    void ContaQuadros()
    {
        contQuadros++;
        if (contQuadros >= totalQuadros)
        {
            Acao();
        }
        else
        {
            my.InvokeAoFimDoQuadro(() => { ContaQuadros(); });
        }
    }
}

public class MyInvokeMethod
{
    private System.Action acao;

    public void InvokeAoFimDoQuadro(System.Action acao)
    {
        this.acao = acao;
        CoroutineObject.Instance.StartCoroutine(EndFrameInvoke());
    }

    public void InvokeAoFimDoQuadro(GameObject G,System.Action acao)
    {
        this.acao = acao;
        CoroutineObject.Instance.StartCoroutine(EndFrameInvokeWithObject(G));
    }

    public void InvokeNoTempoDeJogo(System.Action acao, float tempo)
    {
        this.acao = acao;
        CoroutineObject.Instance.StartCoroutine(TimedInvoke(tempo));
    }

    public void InvokeNoTempoDeJogo(GameObject G,System.Action acao, float tempo)
    {
        this.acao = acao;
        CoroutineObject.Instance.StartCoroutine(TimedInvokeWithObject(G,tempo));
    }

    public void InvokeNoTempoReal(System.Action acao, float tempo)
    {
        this.acao = acao;
        CoroutineObject.Instance.StartCoroutine(RealTimeTimedInvoke(tempo));
    }

    public void InvokeNoTempoReal(GameObject G,System.Action acao, float tempo)
    {
        this.acao = acao;
        CoroutineObject.Instance.StartCoroutine(RealTimeTimedInvokeWithObject(tempo,G));
    }

    IEnumerator TimedInvokeWithObject(GameObject G,float time)
    {
        yield return new WaitForSeconds(time);

        if (G != null)
        {            
            Acao();
        }
    }

    IEnumerator TimedInvoke(float time)
    {
        yield return new WaitForSeconds(time);
        Acao();        
    }

    IEnumerator RealTimeTimedInvokeWithObject(float time,GameObject G)
    {
        yield return new WaitForSecondsRealtime(time);
        if(G!=null)
            Acao();
    }

    IEnumerator RealTimeTimedInvoke(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Acao();
    }

    IEnumerator EndFrameInvokeWithObject(GameObject G)
    {
        yield return new WaitForEndOfFrame();
        if(G!=null)
            Acao();
    }

    IEnumerator EndFrameInvoke()
    {
        yield return new WaitForEndOfFrame();

        Acao();
    }

    void Acao()
    {
        acao();
        acao = null;
    }
}

public class CoroutineObject:MonoBehaviour
{
    private static CoroutineObject instance;

    public static CoroutineObject Instance 
    {
        get {
            if (instance == null)
            {
                GameObject G = new GameObject();
                G.name = "CoroutineObject";
                DontDestroyOnLoad(G);

                instance = G.AddComponent<CoroutineObject>();
            }
        
            return instance;

        }
    }
}
