using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuRotate : MonoBehaviour
{
    [SerializeField] float secondsRotating;
    [SerializeField] Vector3 rotation;
    [SerializeField] Ease ease;

    void Start()
    {
        StartCoroutine(MenuRotateCo());
    }

    private IEnumerator MenuRotateCo()
    {
        transform.DORotate(rotation, secondsRotating).SetEase(ease);
        yield return new WaitForSeconds(secondsRotating);
        transform.DORotate(-rotation, secondsRotating).SetEase(ease);
        yield return new WaitForSeconds(secondsRotating);
        StartCoroutine(MenuRotateCo());
    }
}