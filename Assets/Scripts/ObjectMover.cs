using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementPath;
    [SerializeField] Vector3 rotationSpeed;
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RotateObject();
        ObjectMovement();
    }

    void ObjectMovement()
    {
        if (period <= Mathf.Epsilon) { return;  }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementPath = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * movementPath;
        transform.position = startingPosition + offset;
    }


    void RotateObject()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
