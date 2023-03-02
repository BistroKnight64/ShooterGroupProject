using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFaceMouseAim : MonoBehaviour
{
    public Vector3 mousePosition;
    public Vector2 direction;

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePosition = Input.mousePosition;
             mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }
}
