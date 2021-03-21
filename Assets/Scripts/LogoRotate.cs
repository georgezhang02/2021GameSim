using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoRotate : MonoBehaviour
{

    private float rotZ;
    public float RoationSpeed;

    // Update is called once per frame
    void Update()
    {
        rotZ += Time.deltaTime * RoationSpeed;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
