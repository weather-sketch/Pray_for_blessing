using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class bucketManager : MonoBehaviour
{
    public List<GameObject> QianPrefabs;
    bool isStart = false;
    private float curTime = 0;
    public Transform targetPosition;
    public Quaternion targetRotation;
    public Animator animator;
    private bool shakeStarted = false;
    public AudioSource shake_bucket;
    public AudioSource stick_fall;

    public void Start()
    {
        targetRotation = Quaternion.Euler(0, 0, 90);
    }

    void Update()
    {
        if (animator != null)
        {
            animator.SetBool("isStart", isStart);
        }
        if (isStart)
        {
            curTime += Time.deltaTime;
            animator.Play("Shake");
            
            if (curTime >= 5f)
            {
                shakeStarted = true;
                StartCoroutine(DropOnePrefab());
                isStart = false;
                curTime = 0;
            }
        }
    }

    public void BeginShake()
    {
        if (!shakeStarted)
        {
            isStart = true;
        }
        shake_bucket.Play();
    }

    private IEnumerator DropOnePrefab()
    {
        if (QianPrefabs.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, QianPrefabs.Count);
            GameObject prefabToDrop = QianPrefabs[index];
          GameObject PrefabInstance = Instantiate(prefabToDrop, transform.position, Quaternion.identity);

            Rigidbody rigidbodyToDrop = PrefabInstance.GetComponent<Rigidbody>();
            if (rigidbodyToDrop == null)
            {
                rigidbodyToDrop = PrefabInstance.AddComponent<Rigidbody>();
            }
            rigidbodyToDrop.isKinematic = true;
            BoxCollider collider = PrefabInstance.GetComponent<BoxCollider>();
            XRGrabInteractable grabInteractable = PrefabInstance.GetComponent<XRGrabInteractable>();
            if (grabInteractable == null)
            {
                grabInteractable = PrefabInstance.AddComponent<XRGrabInteractable>();
            }
            if (collider == null)
            {
                collider = PrefabInstance.AddComponent<BoxCollider>();
            }
            collider.isTrigger = false;
            collider.size = new Vector3(0.05f, 0.3f, 0.1f);

            rigidbodyToDrop.collisionDetectionMode = CollisionDetectionMode.Continuous;



            float timeToMove = 2f;
            float elapsedTime = 0f;


            while (elapsedTime < timeToMove)
            {
                PrefabInstance.transform.position = Vector3.Lerp(transform.position, targetPosition.position, (elapsedTime / timeToMove));
                PrefabInstance.transform.rotation = (Quaternion.Lerp(Quaternion.identity, targetRotation, (elapsedTime / timeToMove)));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            stick_fall.Play();
            rigidbodyToDrop.isKinematic = true;
            rigidbodyToDrop.useGravity = false;
        }
    }
}

