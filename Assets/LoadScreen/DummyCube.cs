using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCube : MonoBehaviour
{
    CubeStartScreen dummyCube;
    // Start is called before the first frame update
    void Start()
    {
        dummyCube = FindObjectOfType<CubeStartScreen>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition = dummyCube.transform.localPosition + new Vector3(2.6f, 0, 0);
    }
}
