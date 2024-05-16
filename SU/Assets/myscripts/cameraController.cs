using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    Transform playertransform;
    [SerializeField] GameObject player ;
    void Start()
    {
        playertransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playertransform.position.x,playertransform.position.y,transform.position.z);

    }
}
