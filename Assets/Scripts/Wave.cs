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
        transform.DOMoveY(transform.position.y-GPCtrl.Instance.GeneralData.waveSpeed, .5f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
    }

    public int GetTilemapHeight()
    {
        tilemap.CompressBounds();
        return tilemap.cellBounds.size.y;
    }
}
