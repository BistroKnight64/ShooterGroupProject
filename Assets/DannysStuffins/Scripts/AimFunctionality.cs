using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimFunctionality : MonoBehaviour
{
    public Vector3 mousePosition;

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = mousePosition;
    }
}
