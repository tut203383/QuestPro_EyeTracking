using UnityEngine;
using System.IO;
using System;

public class bothEyeController: MonoBehaviour
{
    public GameObject arrow;
    public GameObject dotPrefab; // 点を描画するためのプレハブ
    public OVREyeGaze leftEyeGaze;  // 左目のEyeGazeController
    public OVREyeGaze rightEyeGaze; // 右目のEyeGazeController
    public GameObject CenterEye;
    public Vector3 offset;
    public float scaleing;
    public Vector3 HitPos { get; private set; }
    public Vector2 HitCo { get; private set; }
    public GameObject dot;
    public string csvFilePath = "/Users/ioh07/OneDrive/デスクトップ/Project/UVCoor.csv";

    void Update()
    {
        if (leftEyeGaze == null || rightEyeGaze == null) return;

        // アイトラッキングの有効時
        if (leftEyeGaze.EyeTrackingEnabled && rightEyeGaze.EyeTrackingEnabled)
        {
            // 両目の位置と回転の平均を計算
            Vector3 centerPosition = (leftEyeGaze.transform.position + rightEyeGaze.transform.position) / 2f;

            centerPosition += offset;

            Vector3 centerDirection = (leftEyeGaze.transform.forward + rightEyeGaze.transform.forward).normalized;

            // レイキャストでオブジェクトの当たり判定を取得
            RaycastHit hit;
            if (Physics.Raycast(centerPosition, centerDirection, out hit))
            {
                // 当たった座標に点を描画（既存の点があれば削除）
                if (dot == null)
                {
                    dot = Instantiate(dotPrefab, hit.point, Quaternion.identity);
                    dot.name = "Dot";
                }
                else // Otherwise, move the existing dot to the hit point
                {
                    dot.transform.position = hit.point;
                }

                HitPos = hit.point;
                Vector3 localHitPoint = hit.transform.InverseTransformPoint(hit.point);
                HitCo = hit.textureCoord;

                float distance = Vector3.Distance(CenterEye.transform.position, hit.point);
                float scale = distance / scaleing;
                dot.transform.localScale = new Vector3(scale, scale, scale);
                Debug.Log("UV; " + HitCo);
                Debug.Log("Hit Object: "+ hit.collider.gameObject.name);

                // Write the HitCo to the CSV file
                using (StreamWriter writer = new StreamWriter(csvFilePath, true))
                {
                    writer.WriteLine("{0},{1},{2},{3}", DateTime.Now, hit.collider.gameObject.name, HitCo.x, HitCo.y);
                }
            }
        }
    }
}
