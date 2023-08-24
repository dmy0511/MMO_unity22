using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class TestCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"Collision @ {other.gameObject.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);

            LayerMask mask = LayerMask.GetMask("Moster") | LayerMask.GetMask("Wall");

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                Debug.Log($"Raycast Camera @{hit.collider.gameObject.name}");
            }
        }
    }
}
