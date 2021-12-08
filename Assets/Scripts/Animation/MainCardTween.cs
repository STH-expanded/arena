using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainCardTween : MonoBehaviour
{
    [SerializeField] public float inDelay;
    [SerializeField] public float inDuration;
    [SerializeField] public float outDelay;
    [SerializeField] public float outDuration;

    public LeanTweenType inType;
    public LeanTweenType outType;

    public GameObject unselectedCard1;
    public GameObject unselectedCard2;

    public UnityEvent onCompleteCallback;

    public void OnEnable()
    {
        transform.localScale = new Vector3();
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), inDuration).setDelay(inDelay).setOnComplete(OnComplete).setEase(inType);
    }

    public void OnComplete()
    {
        if (onCompleteCallback != null)
        {
            onCompleteCallback.Invoke();
        }
    }

    public void OnClose()
    {
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), outDuration).setDelay(outDelay).setOnComplete(DestroyMe).setEase(outType);

        GameObject[] unselectedCards = { unselectedCard1, unselectedCard2 };
        foreach (GameObject unselectedCard in unselectedCards)
        {
            LeanTween.scale(unselectedCard, new Vector3(0, 0, 0), outDuration).setDelay(0.1f).setOnComplete(DestroyMe).setEase(outType);
        }
    }

    void DestroyMe()
    {
        gameObject.SetActive(false);
        unselectedCard1.SetActive(false);
        unselectedCard2.SetActive(false);
    }
}
