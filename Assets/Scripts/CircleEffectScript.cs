using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEffectScript : MonoBehaviour
{
    public Vector3 speed;
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
    }
}
