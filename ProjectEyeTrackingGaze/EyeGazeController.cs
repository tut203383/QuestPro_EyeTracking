using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGazeController : MonoBehaviour
{
    public GameObject arrow;
    OVREyeGaze eyeGaze;

    // スタート時に呼ばれる
    void Start()
    {
        eyeGaze = GetComponent<OVREyeGaze>();
    }

    // フレーム更新毎に呼ばれる
    void Update()
    {
        if (eyeGaze == null) return;

        // アイトラッキングの有効時
        if (eyeGaze.EyeTrackingEnabled)
        {
            // 視線の同期
            arrow.transform.rotation = eyeGaze.transform.rotation;
            arrow.transform.position = eyeGaze.transform.position;
        }
    }
}