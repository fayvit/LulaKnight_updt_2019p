using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowerPauseHudManager : MonoBehaviour {
    [SerializeField] private GameObject container = default;
    [SerializeField] private Text title = default;
    [SerializeField] private Text shorDescription = default;
    [SerializeField] private Text longDescription = default;
    [SerializeField] private Image baseImage = default;

    // Use this for initialization
    void Start () {
        /*
        EventAgregator.AddListener(EventKey.enterPause,OnEnterPause);
        EventAgregator.AddListener(EventKey.exitPause, OnExitPause);
        EventAgregator.AddListener(EventKey.finishAllTabPauseMenu, OnFinishTabs);

        OnExitPause(null);
        OnFinishTabs(null);
        */
    }

    private void OnDestroy()
    {
        /*
        EventAgregator.RemoveListener(EventKey.enterPause, OnEnterPause);
        EventAgregator.RemoveListener(EventKey.exitPause, OnExitPause);
        EventAgregator.AddListener(EventKey.finishAllTabPauseMenu, OnFinishTabs);*/
    }

    private void OnFinishTabs(IGameEvent obj)
    {
        title.text = "";
        shorDescription.text = "";
        longDescription.text = "";
        baseImage.sprite = null;
    }

    private void OnExitPause(IGameEvent obj)
    {
        container.SetActive(false);
    }

    private void OnEnterPause(IGameEvent obj)
    {
        container.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
