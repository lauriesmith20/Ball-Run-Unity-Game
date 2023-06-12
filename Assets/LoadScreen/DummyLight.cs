using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyLight : MonoBehaviour
{

    TrackerStartScreen shadowCube;

    // Start is called before the first frame update
    void Start()
    {
        shadowCube = FindObjectOfType<TrackerStartScreen>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float newx = shadowCube.transform.localPosition.x ;
        transform.localPosition = new Vector3 (newx +2.6f ,transform.localPosition.y, transform.localPosition.z);
    }
}
