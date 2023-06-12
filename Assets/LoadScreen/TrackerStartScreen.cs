using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerStartScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition += new Vector3(-0.008f, 0, 0);
        if (transform.localPosition.x < -1.3)
        {
            transform.localPosition = new Vector3(1.3f, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
