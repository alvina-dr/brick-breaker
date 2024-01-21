using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Wave : MonoBehaviour
{
    void Start()
    {
        transform.DOMoveY(-GPCtrl.Instance.GeneralData.waveSpeed, .5f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
    }
}
