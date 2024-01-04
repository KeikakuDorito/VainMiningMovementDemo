using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    Vector3 currentVelocity = Vector3.zero;
    [SerializeField] private float smoothTime;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + offset,ref currentVelocity,smoothTime);
    }
}
