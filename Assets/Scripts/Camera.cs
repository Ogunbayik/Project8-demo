using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public float smoothness;

    private Vector3 _offset;
    private Vector3 _rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        _rotation = new Vector3(45, 0, 0);
        transform.rotation = Quaternion.Euler(_rotation);

        _offset = new Vector3(0, 15, -7);
        transform.position = Vector3.Lerp(transform.position, player.transform.position + _offset, smoothness);
    }
}
