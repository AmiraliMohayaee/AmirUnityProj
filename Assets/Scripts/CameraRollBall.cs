using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRollBall : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position = player.transform.position;
    }

    // Updates after all other objects are updated first
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
