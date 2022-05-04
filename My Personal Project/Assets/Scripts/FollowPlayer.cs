using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float turnSpeed = 5.0f;

    private Vector3 offsetView = new Vector3(0f, 0.85f, 0f);
    private Vector3 offsetRotation = new Vector3(10.85f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //camera if following player in 1st person, and is rotating along
        transform.position = player.transform.position + offsetView;
        transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, Time.deltaTime * turnSpeed);
        
    }
}
