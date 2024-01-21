using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

public class Wave : MonoBehaviour
{
    public Tilemap tilemap;

    void Start()
    {
        transform.DOKill();
        Debug.Log(GPCtrl.Instance.GeneralData.waveSpeed);
        Sequence _sequence = DOTween.Sequence();
        _sequence.Append(transform.DOMoveY(transform.position.y - 1, .5f).SetEase(Ease.Linear));
        _sequence.AppendInterval(GPCtrl.Instance.GeneralData.waveSpeed);
        _sequence.SetLoops(-1, LoopType.Incremental);
    }

    public int GetTilemapHeight()
    {
        tilemap.CompressBounds();
        return tilemap.cellBounds.size.y;
    }
}
