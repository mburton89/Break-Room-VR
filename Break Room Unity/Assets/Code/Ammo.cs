using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] MeshRenderer colorShift;
    [SerializeField] Material hitColor;
    AudioSource audioSource;

    public enum ammoType
    {
        basic,
        breakable,
        reusable,
    }

    public ammoType currentAmmoType;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "SpawnZone" && collision.gameObject.tag != "Player")
        {
            HandleImpact();
        }
    }

    void HandleImpact()
    {
        if (currentAmmoType == ammoType.basic)
        {
            //Nothing?
        }
        else if (currentAmmoType == ammoType.breakable)
        {
            Destroy(this.gameObject);
        }
        else if (currentAmmoType == ammoType.reusable)
        {
            colorShift.material = hitColor;
        }

        audioSource.Play();
    }
}
