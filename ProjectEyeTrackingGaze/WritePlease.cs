using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WritePlease : MonoBehaviour
{
    public bothEyeController eyeController;
    Material mMaterial;
    MeshRenderer mMeshRenderer;

    float[] mPoints;
    int mHitCount = 0;

    public int frameCount = 10;  // the number of frames to average over
    public float threshold = 0.1f;  // Set this to whatever value works best for you
    List<Vector2> lastHitPoints = new List<Vector2>();


    void Start()
  {

    mMeshRenderer = GetComponent<MeshRenderer>();
    mMaterial = new Material(mMeshRenderer.material);
    mMeshRenderer.material = mMaterial;


    mPoints = new float[3 * 341]; 

    }

    // Update is called once per frame
    void Update()
    {


        
        if (eyeController != null && eyeController.leftEyeGaze.EyeTrackingEnabled && eyeController.rightEyeGaze.EyeTrackingEnabled)
        {
            Vector2 hitCoordinate = eyeController.HitCo;
    
            // Add the new hit point to the list
            lastHitPoints.Add(hitCoordinate);
    
            // If the list has more than frameCount elements, remove the oldest one
            if (lastHitPoints.Count > frameCount)
            {
                lastHitPoints.RemoveAt(0);
            }
    
            // Calculate the average of the last hit points
            Vector2 averageHitPoint = Vector2.zero;
            foreach (Vector2 point in lastHitPoints)
            {
                averageHitPoint += point;
            }
            averageHitPoint /= lastHitPoints.Count;
    
            // Only add a new hit point if it's sufficiently far from the average of the last hit points
            if ((averageHitPoint - hitCoordinate).magnitude > threshold)
            {
                //Debug.Log(hitCoordinate);
                addHitPoint(hitCoordinate.x*4-2, hitCoordinate.y*4-2);
            }
        }


    }

    public void addHitPoint(float xp, float yp){
        mPoints[mHitCount * 3] = xp;
        mPoints[mHitCount * 3+1] = yp;
        mPoints[mHitCount * 3+2] = Random.Range(1f, 3f);
        
        mHitCount++;
        mHitCount %= 341;

        mMaterial.SetFloatArray("_Hits", mPoints);
        mMaterial.SetInt("_HitCount", mHitCount);

    }
}
