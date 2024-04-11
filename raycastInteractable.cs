using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastInteractable : MonoBehaviour
{
    public Transform target;
    public LineRenderer lineRenderer;
    public LayerMask Gaze_interactable;
    private float maxDistance = 50f;
    public GameObject eye_interactable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.red);
        lineRenderer.SetPosition(0, transform.position);
        Vector3 rayDirection = transform.forward;
        RaycastHit hit;
        bool isHit = Physics.Raycast(transform.position, rayDirection, out hit, maxDistance, Gaze_interactable);
        Vector3 endPosition = isHit ? hit.point : transform.position + rayDirection * maxDistance;
        lineRenderer.SetPosition(1, endPosition);
        Debug.Log("End Position: " + endPosition);
        if (isHit & hit.transform == target)
        {
            eye_interactable.SetActive(true);
        }
        else
        {
            eye_interactable.SetActive(false);
        }
    }
}
