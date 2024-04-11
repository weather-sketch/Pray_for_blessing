using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightUpTorch : MonoBehaviour
{
    public GameObject smallFire;
    public bool isLit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("torch"))
        {
            smallFire.SetActive(true);
            isLit = true;
        }
    }

}
