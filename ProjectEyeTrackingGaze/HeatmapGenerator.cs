using UnityEngine;

public class HeatmapGenerator : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private Laser laserScript;
    private Laser2 laser2Script;

    private void Awake()
    {
        // Laser2�X�N���v�g�̎Q�Ƃ��擾
        laserScript = FindObjectOfType<Laser>();
        laser2Script = FindObjectOfType<Laser2>();
    }

    void Update()
    {
        // Laser2�X�N���v�g����HitPos���擾
        Vector4 position_left = laserScript.HitPos;
        Vector4 position_right = laser2Script.HitPos_right;

        Vector3 position = new Vector3( (position_left.x + position_right.x)/2, (position_left.y + position_right.y)/2, (position_left.z + position_right.z)/2);


        // �p�[�e�B�N���̐F���f�[�^�Ɋ�Â��Đݒ肵�܂��B���̗�ł́A�P���Ƀ����_���ȐF�𐶐����Ă��܂��B
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
        emitParams.startColor = color; // �����Ńp�[�e�B�N���̐F��ݒ�
        

        particleSystem.Emit(emitParams, 1);
    }
}
