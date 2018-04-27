using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Vector3 startMarker;
    public Vector3 endMarker;
    public float speed = 100f;
    private float startTime;
    private float journeyLength;

    void Start()
    {
        startMarker = transform.position;
        endMarker = new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y, transform.position.z + Random.Range(-10, 10));

        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker, endMarker);


    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
    }

}
