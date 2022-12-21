using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
    [SerializeField] private RectTransform[] symbolsOnReels;

    private readonly float exitPosition = 141;

    private void Update()
    {
        foreach(var symbol in symbolsOnReels)
        {
            if (symbol.position.y <= exitPosition)
            {
                var offest = symbol.position.y + 200 * 4;
                var newPos = new Vector3(symbol.position.x,offest);
                symbol.position = newPos;
            }
        }
    }
    public void ResetSymbolPosition(float reelCurrentPositionY)
    {
        foreach (var symbol in symbolsOnReels)
        {
            var symbolPos = symbol.localPosition;
            var newPos = symbolPos.y + reelCurrentPositionY;
            print(newPos);
            symbol.localPosition = new Vector3(symbolPos.x, newPos);
        }
    }
}
