using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //GameObject reference to the player
    public GameObject player;

    //offset is private becasue we can set it here on the script
    private Vector3 offset;

    void Start()
    {
        // relationship between the position of the camera and the position of the player
        // (distance)
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is better to use camera movement updates
    // It also called once per frame but it is ensured that it will run after all the other Update functions
    void LateUpdate()
    {
        // now the camara will move with respect to the player without rotating
        transform.position = player.transform.position + offset;
    }
}
