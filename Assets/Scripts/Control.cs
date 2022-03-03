using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] float _Thruster = 10f;
    [SerializeField] float _Secondthruster = 500f;
    [SerializeField] AudioClip _sfxThrusting;


    [SerializeField] ParticleSystem _ThrusterFX;


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
        ReloadWhenFall();
    }

    void ThrusterActive()
    {
        Thrusting();
    }

    private void Thrusting()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            shipRb.AddRelativeForce(Vector3.up * _Thruster * Time.deltaTime);
            if (!shipAudio.isPlaying)
            {
                shipAudio.PlayOneShot(_sfxThrusting);
            }
            _ThrusterFX.Play();
        }
        else
        {
            shipAudio.Stop();
            _ThrusterFX.Stop();
        }
    }

    void ReloadWhenFall()
    {
        if (shipRb.transform.position.y <= -10)
        {
            GetComponent<CollisionController>().OutofLevel();
        }
    }

    void SecondaryThrustActive()
    {
        Rotate();
    }

    private void Rotate()
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
