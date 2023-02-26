using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticle;
    [SerializeField] ParticleSystem leftEngineParticle;
    [SerializeField] ParticleSystem rightEngineParticle;

    Rigidbody _rigidbody;
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void StopThrusting()
    {
        _audioSource.Stop();
        mainEngineParticle.Stop();
    }

    private void StartThrusting()
    {
        _rigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            StartRightThrusting();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            StartLeftThrusting();
        }
        else
        {
            StopSideThrusting();
        }
    }

    private void StopSideThrusting()
    {
        rightEngineParticle.Stop();
        leftEngineParticle.Stop();
    }

    private void StartLeftThrusting()
    {
        ApplyRotation(-rotationThrust);
        if (!leftEngineParticle.isPlaying)
        {
            leftEngineParticle.Play();
        }
    }

    private void StartRightThrusting()
    {
        ApplyRotation(rotationThrust);
        if (!rightEngineParticle.isPlaying)
        {
            rightEngineParticle.Play();
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        _rigidbody.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        _rigidbody.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
