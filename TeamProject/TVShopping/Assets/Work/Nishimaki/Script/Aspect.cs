using UnityEngine;
using System.Collections;

public class Aspect : MonoBehaviour {

    public float baseWidth=640.0f;
    public float baseHeight=960.0f;

    void Awake()
    {
        Camera cam = gameObject.GetComponent<Camera>();
        float baseAspect = baseWidth / baseHeight;
        float nowAspect = (float)Screen.height / (float)Screen.width;
        float afterAspect;

        if (baseAspect > nowAspect)
        {
            afterAspect = nowAspect / baseAspect;
            cam.rect = new Rect((1 - afterAspect) * 0.5f, 0, afterAspect, 1);
        }
        else
        {
            afterAspect = baseAspect / nowAspect;
            cam.rect = new Rect(0, (1 - afterAspect) * 0.5f, 1, afterAspect);
        }
        Destroy(this);
    }

}
