using UnityEngine;

public class HeatmapGenerator : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private Laser laserScript;
    private Laser2 laser2Script;

    private void Awake()
    {
        // Laser2スクリプトの参照を取得
        laserScript = FindObjectOfType<Laser>();
        laser2Script = FindObjectOfType<Laser2>();
    }

    void Update()
    {
        // Laser2スクリプトからHitPosを取得
        Vector4 position_left = laserScript.HitPos;
        Vector4 position_right = laser2Script.HitPos_right;

        Vector3 position = new Vector3( (position_left.x + position_right.x)/2, (position_left.y + position_right.y)/2, (position_left.z + position_right.z)/2);


        // パーティクルの色をデータに基づいて設定します。この例では、単純にランダムな色を生成しています。
        Color color = new Color(1.0f,0.0f, 0.0f, 0.1f); 

        if (position_left.w == 1 || position_right.w ==1){
            EmitParticle(position, color);
            //Debug.Log("poaition" + position);
        }
       
    }

    void EmitParticle(Vector3 position, Color color)
    {
        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
        emitParams.position = position;
        emitParams.startColor = color; // ここでパーティクルの色を設定
        

        particleSystem.Emit(emitParams, 1);
    }
}
