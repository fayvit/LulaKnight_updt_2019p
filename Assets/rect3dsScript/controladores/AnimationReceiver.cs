using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationReceiver : MonoBehaviour
{
    [SerializeField] private Animator A;
    [SerializeField] private string keyOfMoviment = "notAnime";
    [SerializeField] private string booleanOfJump = "notAnime";
    [SerializeField] private string jumpAnimationName = "notAnime";

    // Start is called before the first frame update
    void Start()
    {
        if (A == null)
            A = GetComponent<Animator>();

        EventAgregator.AddListener(EventKey.sendAnimationKey, OnReceivedAnimationKey);
    }

    private void OnDestroy()
    {
        EventAgregator.RemoveListener(EventKey.sendAnimationKey, OnReceivedAnimationKey);
    }

    private void OnReceivedAnimationKey(IGameEvent obj)
    {
        if (obj.Sender == gameObject)
        {
            StandardSendGameEvent ssge = (StandardSendGameEvent)obj;

            switch ((AnimationKey)ssge.MyObject[0])
            {
                case AnimationKey.movimentacao:
                    AnimeMovimentacao(ssge);
                    break;
                case AnimationKey.jumpAnimate:
                    AnimePulo(ssge);
                    break;
            }
        }
    }

    protected virtual void AnimePulo(StandardSendGameEvent ssge)
    {
        if (booleanOfJump != "notAnime")
        {
            A.SetBool(booleanOfJump, (bool)ssge.MyObject[1]);

            if((bool)ssge.MyObject[1])
                A.Play(jumpAnimationName);
        }
    }

    protected virtual void AnimeMovimentacao(StandardSendGameEvent ssge)
    {
        if (keyOfMoviment != "notAnime")
        {
            A.SetFloat(keyOfMoviment, Mathf.Abs(((Vector3)ssge.MyObject[1]).x));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum AnimationKey
{
    movimentacao,
    jumpAnimate
}
