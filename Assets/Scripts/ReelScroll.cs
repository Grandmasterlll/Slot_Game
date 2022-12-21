using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ReelScroll : MonoBehaviour
{

    [SerializeField] private RectTransform[] reelsRT;
    [SerializeField] private Reel[] reels;
    [SerializeField] private float delaySteep;
    [SerializeField] private Ease startEase;
    [SerializeField] private Ease stopEase;
    [SerializeField] private float startDist, linearDist, stopDist;
    [SerializeField] private float startD, linearD, stopD;

    private Dictionary<RectTransform, Reel> reelDictionary;

    private float reelStartPositionY;

    private void Awake()
    {
        reelDictionary = new Dictionary<RectTransform, Reel>();
        for (int i = 0; i < reelsRT.Length; i++)
        {
            reelDictionary.Add(reelsRT[i], reels[i]);
        }
        reelStartPositionY = reelsRT[0].localPosition.y;
    }

    public void ScrollStart()
    {
        for (int i = 0; i < reelsRT.Length; i++)
        {
            var reelRT = reelsRT[i];
            reelRT.DOAnchorPosY(startDist, startD)
                .SetDelay(i* delaySteep)
                .SetEase(startEase)
                .OnComplete(() => Scrolllinear(reelRT));
        }
    }

    private void Scrolllinear(RectTransform reels)
    {
        reels.DOAnchorPosY(linearDist, linearD)
            .SetEase(Ease.Linear)
            .OnComplete(() => Scrollstop(reels));


    }

    private void Scrollstop(RectTransform reelRT)
    {
        reelRT.DOAnchorPosY(stopDist, stopD)
            .SetEase(stopEase)
             .OnComplete(() => PrepareReel(reelRT));



    }

    private void PrepareReel(RectTransform reelRT)
    {
        var curentreelpos = reelRT.localPosition.y;
        print(curentreelpos);
        reelRT.localPosition = new Vector3(reelRT.localPosition.x, reelStartPositionY); //+
        
        reelDictionary[reelRT].ResetSymbolPosition(curentreelpos);
    }

   
   
}
