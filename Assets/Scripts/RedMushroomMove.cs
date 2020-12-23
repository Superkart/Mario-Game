using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMushroomMove : MonoBehaviour
{
    private Vector3 positionDisplacement;
    private Vector3 positionOrigin;
    private float _timePassed;
    [Range(0f, 1f)]
    public float Speed = 0.1f;
    public float Magnitude = 0f;
    private void Start()
    {
       // float randomDistance = Random.Range(-Magnitude, Magnitude);
        positionDisplacement = new Vector3(Magnitude, 0f, 0f);
        positionOrigin = transform.position;
    }

    private void Update()
    {
        _timePassed += Time.deltaTime;
        transform.position = Vector3.Lerp(positionOrigin, positionOrigin + positionDisplacement,
            Mathf.PingPong(_timePassed * Speed, 1));

    }
}
