using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class inputController : MonoBehaviour
{

    public GameObject pointer;
    private ActionTarget currentTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        pointer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                HandleInput(touch.position);
            }
        }

        
        if (Input.GetMouseButtonDown(0))
        {
            HandleInput(Input.mousePosition);
        }
    }

    void HandleInput(Vector3 position) {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(position);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, Physics.DefaultRaycastLayers))
        {
            Debug.Log("HIT " + hit.collider.name);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.green, 3);
            string tag = hit.collider.tag;

            if (tag == "Interactable")
            {
                if (currentTarget != null)
                {
                    currentTarget.DisableSelectionIndicator();
                }
                if (GameObject.ReferenceEquals(hit.collider.gameObject.GetComponent<ActionTarget>(), currentTarget))
                {
                    currentTarget.DisableSelectionIndicator();
                    currentTarget = null;
                }
                else
                {
                    // Highlight
                    currentTarget = hit.collider.gameObject.GetComponent<ActionTarget>();
                    currentTarget.EnableSelectionIndicator();
                    // Open action menu
                }
            }
            else if (tag == "Ground") {
                Vector3 targetPosition = hit.point;
                targetPosition.x = Mathf.Round(targetPosition.x);
                targetPosition.y = 0.1f;
                targetPosition.z = Mathf.Round(targetPosition.z);
                pointer.transform.position = targetPosition;
                pointer.SetActive(true);
            }
        }
    }
}
