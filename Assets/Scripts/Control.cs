using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] float _Thruster = 10f;
    [SerializeField] float _Secondthruster = 500f;
    [SerializeField] AudioClip _sfxThrusting;

    Rigidbody shipRb;
    AudioSource shipAudio;
    

    // Start is called before the first frame update
    void Start()
    {
        shipRb = GetComponent<Rigidbody>();
        shipAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        ThrusterActive();
        SecondaryThrustActive();
    }

    void ThrusterActive()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
          
            shipRb.AddRelativeForce(Vector3.up * _Thruster * Time.deltaTime);
            if (!shipAudio.isPlaying)
            {
                shipAudio.Play();
            }
           
        }
        else
        {
            shipAudio.Stop();
        }


    }

    void SecondaryThrustActive()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ActivateSecondaryThrust(_Secondthruster);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ActivateSecondaryThrust(-_Secondthruster);
        }
    }

    void ActivateSecondaryThrust(float secondarythruster)
    {
        shipRb.freezeRotation = true;
        transform.Rotate(Vector3.right * secondarythruster * Time.deltaTime);
        shipRb.freezeRotation = false;
    }
}
