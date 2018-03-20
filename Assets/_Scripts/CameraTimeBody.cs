using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTimeBody : MonoBehaviour
{
    List<PointInTime> pointInTime;
    TimeBody timeBody;

    private void Awake()
    {
        pointInTime = new List<PointInTime>();
        timeBody = FindObjectOfType<TimeBody>();
    }

    private void Start()
    {
        StartCoroutine(Rewinding());
    }

    private void LateUpdate()
    {
        Record();
    }

    IEnumerator Rewinding()
    {
        while (true)
        {
            while (timeBody.isRewing)
            {
                Rewind();
                yield return null;
            }
            yield return null;
        }
    }

    void Record()
    {
        if (!timeBody.isRewinding)
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
            if (pointInTime.Count > 2)
            {
                pointInTime.RemoveAt(0);
            }
        }
    }
}