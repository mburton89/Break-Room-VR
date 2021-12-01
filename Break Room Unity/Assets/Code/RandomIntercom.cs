using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIntercom : MonoBehaviour
{
    public AudioSource intercom;

    public AudioClip[] intercomAnnouncements;

    void Announcement()
    {
        GetComponent<AudioSource>();
    }

    void Start()
    {
        StartCoroutine(PlayRandomClip());
    }

    private void Update()
    {
        if (Input.GetKeyDown ("space"))
        {
            intercom.clip = intercomAnnouncements[Random.Range(0, intercomAnnouncements.Length)];
            intercom.PlayOneShot(intercom.clip);
        }
    }

    private IEnumerator PlayRandomClip()
    {
        intercom.clip = intercomAnnouncements[Random.Range(0, intercomAnnouncements.Length)];
        intercom.PlayOneShot(intercom.clip);
        yield return new WaitForSeconds(60);
        StartCoroutine(PlayRandomClip());
    }
}
