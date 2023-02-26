using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool firstPlayer;

    private float firstPlayerId;

    private Touch touch;
    private Vector2 touchPoint;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            MovePlayer(0);
        }

        if (Input.touchCount > 1)
        {
            MovePlayer(1);
        }
    }

    private void MovePlayer(int touchId)
    {
        touch = Input.GetTouch(touchId);

        touchPoint = Camera.main.ScreenToWorldPoint(touch.position);

        if (touch.phase == TouchPhase.Moved)
        {
            if (firstPlayer)
            {
                firstPlayerId = touchId;

                if (touchPoint.y < -0.5)
                {
                    Movement();
                }
            }
            else
            {
                if (touchPoint.y > 0.5)
                {
                    Movement();
                }
            }
        }
    }

    private void Movement()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().MovePosition(touchPoint);
    }
}
