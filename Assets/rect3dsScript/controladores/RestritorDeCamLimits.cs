using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class RestritorDeCamLimits {
    [SerializeField] private RestringirCamLimits[] camLimits = null;

    private DadosDeCena.LimitantesDaCena limitantes;
    private NomesCenas nomeDaCenaAlvo;

    [System.Serializable]
    private struct RestringirCamLimits
    {
        public enum QualRestricao
        {
            xMin,
            xMax,
            yMin,
            yMax
        }

        [SerializeField] private QualRestricao onde;
        [SerializeField] private float val;

        public float Val { get { return val; } set { val = value; } }
        public QualRestricao Onde { get { return onde; } set { onde = value; } }
    }

    public void VerifiqueLimitantesParaMudeCena()
    {
        VerifiqueLimitantesParaMudeCena(StringParaEnum.ObterEnum<NomesCenas>(SceneManager.GetActiveScene().name));
    }

    public void VerifiqueLimitantesParaMudeCena(NomesCenas cenaAlvo)
    {
        if(camLimits!=null)
        if (camLimits.Length > 0)
        {
            nomeDaCenaAlvo = cenaAlvo;

            SceneManager.activeSceneChanged += ModifiqueLimitantesAct;
            SceneManager.sceneLoaded += ModifiqueLimitantes;
        }
    }

    public void MudeLimitantesParaTrigger(float tempoDeLerpLimits)
    {
        MudeLimitantesParaTrigger(StringParaEnum.ObterEnum<NomesCenas>(SceneManager.GetActiveScene().name),tempoDeLerpLimits);
    }

    public void MudeLimitantesParaTrigger(NomesCenas cenaAlvo,float tempoDeLerpLimits)
    {
       
        limitantes = (DadosDeCena.LimitantesDaCena)GlobalController.g.SceneDates.GetSceneDates(cenaAlvo).limitantes.Clone();
        
        if (camLimits != null)
            if (camLimits.Length > 0)
            {

                for (int i = 0; i < camLimits.Length; i++)
                {
                    AltereLimitante(camLimits[i]);
                }

            }

        
        EventAgregator.Publish(new StandardSendGameEvent(EventKey.requestChangeCamLimits, limitantes, tempoDeLerpLimits));
    }

    private void ModifiqueLimitantesAct(Scene arg0, Scene arg1)
    {
        if (arg1.name == nomeDaCenaAlvo.ToString())
        {
            CoroutineObject.Instance.StartCoroutine(AtrasoDeMudaCam());
            SceneManager.activeSceneChanged -= ModifiqueLimitantesAct;
        }
    }

    private void ModifiqueLimitantes(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == nomeDaCenaAlvo.ToString())
        {
            CoroutineObject.Instance.StartCoroutine(AtrasoDeMudaCam());
            SceneManager.sceneLoaded -= ModifiqueLimitantes;
        }
    }

    IEnumerator AtrasoDeMudaCam()
    {
        yield return new WaitForEndOfFrame();
        limitantes = (DadosDeCena.LimitantesDaCena)GlobalController.g.SceneDates.GetSceneDates(nomeDaCenaAlvo).limitantes.Clone();

        for (int i = 0; i < camLimits.Length; i++)
        {
            AltereLimitante(camLimits[i]);
        }

        EventAgregator.Publish(new StandardSendGameEvent(EventKey.requestChangeCamLimits, limitantes, 0f));
    }

    void AltereLimitante(RestringirCamLimits camLimits)
    {
        switch (camLimits.Onde)
        {
            case RestringirCamLimits.QualRestricao.xMax:
                limitantes.xMax = camLimits.Val;
            break;
            case RestringirCamLimits.QualRestricao.xMin:
                limitantes.xMin = camLimits.Val;
            break;
            case RestringirCamLimits.QualRestricao.yMax:
                limitantes.yMax = camLimits.Val;
            break;
            case RestringirCamLimits.QualRestricao.yMin:
                limitantes.yMin = camLimits.Val;
            break;
        }
    }
}