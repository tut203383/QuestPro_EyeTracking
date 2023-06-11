using UnityEngine;
//using System.IO;
//using System;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    [SerializeField]
    GameObject hand;

    LineRenderer lineRenderer;
    public Vector4 HitPos { get; private set; }
    Vector3 tmpPos;

    float lazerDistance = 100f;
    float lazerStartPointDistance = 0.15f;
    float lineWidth = 0.01f;

    //StreamWriter sw;
    //string filePath;

    //void Awake()
    //{
    //    filePath = "/Users/ioh07/OneDrive/デスクトップ/Project/target_left.csv";
    //    sw = new StreamWriter(filePath);
    //}

    void Reset()
    {
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
    }

    void Start()
    {
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.startColor = Color.blue;
    }

    void Update()
    {
        OnRay();
    }

    void OnRay()
    {
        Vector3 direction = hand.transform.forward * lazerDistance;
        Vector3 rayStartPosition = hand.transform.forward * lazerStartPointDistance;
        Vector3 pos = hand.transform.position;
        RaycastHit hit;
        Ray ray = new Ray(pos + rayStartPosition, hand.transform.forward);

        lineRenderer.SetPosition(0, pos + rayStartPosition);

        if (Physics.Raycast(ray, out hit, lazerDistance))
        {
            HitPos = new Vector4(hit.point.x, hit.point.y, hit.point.z, 1);
            lineRenderer.SetPosition(1, hit.point);
            //string[] data = new string[4] 
            //{
            //    DateTime.Now.ToString("o"), // ISO 8601タイムスタンプ
            //    HitPos.x.ToString(),
            //    HitPos.y.ToString(),
            //    HitPos.z.ToString()
            //};
            //string csvData = string.Join(",", data);
            //sw.WriteLine(csvData);
        }
        else
        {
            lineRenderer.SetPosition(1, pos + direction);
            HitPos = new Vector4(hit.point.x, hit.point.y, hit.point.z, 0);
        }

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 0.1f);
    }

    //private void OnDestroy()
    //{
    //    sw.Close();
    //}
}
