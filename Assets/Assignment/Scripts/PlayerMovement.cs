using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public Transform character;
    public float moveSpeed = 5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f; 
            Vector3 direction = (targetPosition - character.position);
            character.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
