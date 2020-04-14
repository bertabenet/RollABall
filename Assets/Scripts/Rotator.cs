using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // if we don't put deltaTime it spins like crazy
        // deltaTime provides the time between the current and previous frame
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
