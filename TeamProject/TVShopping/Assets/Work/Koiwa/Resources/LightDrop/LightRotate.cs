using UnityEngine;
using System.Collections;

public class LightRotate : MonoBehaviour
{
    private bool _doVisible = false;

    void Update()
    {
        transform.Rotate(0, 0, Random.Range(5.0f, 10.0f));

        if (GetComponent<Renderer>().isVisible)
        {
            _doVisible = true;
        }

        if (_doVisible && !GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
}
