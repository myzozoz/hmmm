using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class inputController : MonoBehaviour
{

    private ActionTarget currentTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, Physics.DefaultRaycastLayers))
                {
                    Debug.Log("HIT " + hit.collider.name);
                    Debug.DrawRay(ray.origin, ray.direction * 100, Color.green, 3);

                    if (hit.collider.tag == "Interactable")
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
                }
            }
        }

        /*
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag  == "Interactable")
                {
                    Debug.Log("HIT Interactable: " + hit.collider.name);
                }
                else
                {
                    Debug.Log("Hit something else " + hit.collider.name);
                }
            }
        }*/
    }
}
