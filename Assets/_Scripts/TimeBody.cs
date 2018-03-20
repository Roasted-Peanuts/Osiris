using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBody : MonoBehaviour
{
    public bool isRewinding = false;
    List<PointInTime> pointInTime;
    Rigidbody rb;
    Score score;

    int triggersCollided = 0;

    public bool isRewing = false;

    FireController fire;

    Vector3 firstPosition;

    public Vector3 direction;

    NoiseEffect noise;

    HUD hud;

    private void Awake()
    {
        hud = FindObjectOfType<HUD>();
        firstPosition = transform.position;
        fire = FindObjectOfType<FireController>();
        pointInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
        score = FindObjectOfType<Score>();
        noise = FindObjectOfType<NoiseEffect>();
    }

    private void LateUpdate()
    {
        Record();
    }

    IEnumerator Rewinding()
    {
        while (isRewing)
        {
            isRewinding = true;
            noise.isNoising = true;
            Rewind();
            rb.isKinematic = true;
            yield return null;
        }
        NotRewinding();
    }

    void NotRewinding()
    {
        isRewinding = false;
        noise.isNoising = false;
        rb.isKinematic = false;
    }

    void Record()
    {
        if (!isRewinding)
        {
            PointInTime tPointInTime = new PointInTime(transform.position, transform.rotation);
            pointInTime.Insert(0, tPointInTime);
            if (pointInTime.Count > 5000)
            {
                pointInTime.RemoveAt(pointInTime.Count - 1);
            }
        }
    }

    void Rewind()
    {
        if (pointInTime.Count > 1)
        {
            transform.position = pointInTime[0].position;
            transform.rotation = pointInTime[0].rotation;
            pointInTime.RemoveAt(0);
        }
        if(pointInTime.Count <= 1)
        {
            StartCoroutine(MoveBall());
            isRewing = false;
        }
    }

    IEnumerator MoveBall()
    {
        yield return new WaitForSeconds(1);
        rb.AddForce(direction * fire.speed);
        triggersCollided = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall") && !isRewing)
        {
            hud.InsteadCollider2();
            isRewing = true;
            StartCoroutine(Rewinding());
        }   

        if(collision.gameObject.CompareTag("Portal") && score.key != 1 )
        {
            isRewing = true;
            StartCoroutine(Rewinding());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Anchor") && isRewinding)
        {
            triggersCollided++;
            if (triggersCollided >= 1)
            {
                NotRewinding();
                isRewing = false;
                fire.canRotate = true;
                StartCoroutine(fire.RotateFire(other.transform));
                triggersCollided = 0;
            }
        }
        //if(other.gameObject.CompareTag("Start Position") && isRewinding)
        //{
        //    NotRewinding();
        //    isRewing = false;
        //    triggersCollided = 0;
        //}
    }
}