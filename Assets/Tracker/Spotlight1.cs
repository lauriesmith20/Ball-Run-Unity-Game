using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight1 : MonoBehaviour
{
    public GameObject SpotlightHolder;
    public float spotlightHeight = 2f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3 (SpotlightHolder.transform.position.x, SpotlightHolder.transform.position.y, SpotlightHolder.transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(SpotlightHolder.transform.position.x, spotlightHeight, SpotlightHolder.transform.position.z);
        transform.rotation = SpotlightHolder.transform.rotation;
    }
}
