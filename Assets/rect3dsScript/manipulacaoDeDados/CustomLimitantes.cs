﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomLimitantes : MonoBehaviour
{
    [SerializeField] private DadosDeCena.LimitantesDaCena limitantes;
    [SerializeField] private NomesCenas cenaDosLimitantes = default(NomesCenas); 
    [SerializeField] private float time = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (UnicidadeDoPlayer.Verifique(collision))
            {

                SceneManager.activeSceneChanged += ModifiqueLimitantesAct;
                SceneManager.sceneLoaded += ModifiqueLimitantes;
            }
        }
    }

    private void ModifiqueLimitantesAct(Scene arg0,Scene arg1)
    {
        if (arg1.name == cenaDosLimitantes.ToString())
        {
            if (cenaDosLimitantes != NomesCenas.nula)
            {
                limitantes = GlobalController.g.SceneDates.GetSceneDates(cenaDosLimitantes).limitantes;
            }

            CoroutineObject.Instance.StartCoroutine(AtrasoDeMudaCam());
            SceneManager.activeSceneChanged -= ModifiqueLimitantesAct;
        }
    }

    private void ModifiqueLimitantes(Scene arg0, LoadSceneMode arg1)
    {
        CoroutineObject.Instance.StartCoroutine(AtrasoDeMudaCam());
        SceneManager.sceneLoaded -= ModifiqueLimitantes;
    }

    IEnumerator AtrasoDeMudaCam()
    {
        yield return new WaitForEndOfFrame();
        EventAgregator.Publish(new StandardSendGameEvent(EventKey.requestChangeCamLimits, limitantes, time));
    }
}
