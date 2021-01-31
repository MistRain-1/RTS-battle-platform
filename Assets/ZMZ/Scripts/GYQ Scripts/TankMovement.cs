using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float speed = 5;
    public float angularspeed = 30;
    private Rigidbody rigidbody;
    public int num=1;
    public AudioClip idleAudio;
    public AudioClip driveAudio;
    private AudioSource audio;
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        audio = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Verticalplayer"+num);
        rigidbody.velocity = transform.forward * v* speed;

        float h = Input.GetAxis("Horizontalplayer"+num);
        rigidbody.angularVelocity = transform.up * h * angularspeed;

        if(Mathf.Abs(h)>0.1||Mathf.Abs(v)>0.1)
        {
            audio.clip = driveAudio;
            audio.Play();
        }
        else
        {
            audio.clip = idleAudio;
            audio.Play();
        }
    }
}
