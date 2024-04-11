using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class lightUPLantern : MonoBehaviour
{
    public GameObject skyFire;
    private float movingSpeed = 0.5f;
    public float maxHeight = 100f;
    public lightUpTorch lightUpTorch;
    public float minWind = -0.1f;
    public float maxWind = -1f;
   
    public GameObject partical;
    public Material lightmat;
    public AudioSource firework;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("torch") && lightUpTorch.isLit == true)
        {
            skyFire.SetActive(true);
            StartCoroutine(LanternRise());
        }
    }

    private IEnumerator LanternRise()
    {
        float windZ = Random.Range(minWind, maxWind);
        Vector3 windForce = new Vector3(0, 0, windZ);
        partical.SetActive(true);
        firework.Play();
        GetComponent<MeshRenderer>().material = lightmat;
        while (transform.position.y < maxHeight)
        {
            transform.position += Vector3.up * movingSpeed * Time.deltaTime;
            transform.position += windForce * Time.deltaTime;
            yield return null;
        }

    }

}
