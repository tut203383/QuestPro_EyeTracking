using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGazeController : MonoBehaviour
{
    public GameObject arrow;
    OVREyeGaze eyeGaze;

    // �X�^�[�g���ɌĂ΂��
    void Start()
    {
        eyeGaze = GetComponent<OVREyeGaze>();
    }

    // �t���[���X�V���ɌĂ΂��
    void Update()
    {
        if (eyeGaze == null) return;

        // �A�C�g���b�L���O�̗L����
        if (eyeGaze.EyeTrackingEnabled)
        {
            // �����̓���
            arrow.transform.rotation = eyeGaze.transform.rotation;
            arrow.transform.position = eyeGaze.transform.position;
        }
    }
}