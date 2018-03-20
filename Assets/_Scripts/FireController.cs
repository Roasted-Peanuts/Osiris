//Coded by Abishek J Reuben

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireController : MonoBehaviour 
{
    #region Variables

    public float speed = 1f;

    public bool canMove = true;

    bool portalReached = false;

    int directionValue = 0;

    public bool canRotate = false;

    Vector3 lastPosition, resultantPosition, realResultantPosition;

    Rigidbody rb;

    public float distanceFromChainEnd = 1f;

    CameraFollow camFollow;
    Score score;

    TimeBody timeBody;

    public GameObject blackHole;
    public GameObject portalRing;

    public Vector3 direction;

    HUD hud;
    AudioSource audioSource;
    public AudioClip collectible, bug, portal;

    #endregion

    #region UnityFunctions

    private void Awake()
    {
        hud = FindObjectOfType<HUD>();
        rb = GetComponent<Rigidbody>();
        camFollow = FindObjectOfType<CameraFollow>();
        score = FindObjectOfType<Score>();
        timeBody = GetComponent<TimeBody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        lastPosition = transform.position;
        realResultantPosition = transform.InverseTransformDirection(direction);
    }

    private void Update()
    {
        CalculateResultantPosition();

        if (Input.GetMouseButtonDown(0) || (Input.GetKeyDown(KeyCode.Space)) && canRotate && Input.mousePosition.x < 1800 && !hud.isPaused)
        {
            Debug.Log(Input.mousePosition);
            canRotate = false;

            canMove = true;
            camFollow.canCameraMove = true;

            rb.isKinematic = false;

            realResultantPosition = resultantPosition;
            rb.AddForce(realResultantPosition.normalized * speed);

            canMove = false;
        }

        if (canMove)
        {
            transform.Translate(realResultantPosition.normalized * speed * Time.deltaTime, Space.World);
            rb.AddForce(realResultantPosition.normalized * speed);
            canMove = false;
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Anchor") && !timeBody.isRewinding)
        { 
            canRotate = true;
            StartCoroutine(RotateFire(other.transform));
            canMove = false;
           
        }

        if(other.CompareTag("Collectible"))
        {
            hud.InsteadCollider();
            Destroy(other.gameObject);
            audioSource.PlayOneShot(collectible);
        }

        if(other.CompareTag("Wall"))
        {
            
        }

        if(other.CompareTag("Key"))
        {
            score.key++;
            Destroy(portalRing);
            Destroy(other.gameObject);
            audioSource.PlayOneShot(bug);
        }

        if(other.CompareTag("Portal"))
        {
           
            if (score.key == 1)
            {
                audioSource.PlayOneShot(portal);
                StartCoroutine(BlackHole());  
            }
        }
    }


    #endregion

    #region CustomFunctions

    void CalculateResultantPosition()
    {
        resultantPosition = transform.position - lastPosition;
        lastPosition = transform.position;
    }

    public IEnumerator RotateFire(Transform point)
    {
        while (canRotate)
        {
            camFollow.canCameraMove = false;
            rb.isKinematic = true;
            transform.RotateAround(point.position, transform.forward, -360 * Time.deltaTime);
            rb.velocity = Vector3.zero;
            yield return null;
        }
    }

    public IEnumerator BlackHole()
    {
        canMove = false;
        rb.velocity = Vector3.zero;
        while(transform.position != blackHole.transform.position)
        {
             transform.position = Vector3.MoveTowards(transform.position, blackHole.transform.position, 0.05f);
             yield return null;
        }
        yield return new WaitForSeconds(1f);
        hud.GameOver1();
    }

    #endregion
}