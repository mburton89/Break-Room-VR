using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HomeMenu : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button exitButton;
    [SerializeField] float secondsToMoveButton;
    [SerializeField] float secondsBetweenButtonMoves;
    [SerializeField] Ease ease;

    void Start()
    {
        StartCoroutine(showButtons());
    }

    private void OnEnable()
    {
        playButton.onClick.AddListener(HandlePlayPressed);
        optionsButton.onClick.AddListener(HandleOptionsPressed);
        exitButton.onClick.AddListener(HandleExitPressed);
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(HandlePlayPressed);
        optionsButton.onClick.RemoveListener(HandleOptionsPressed);
        exitButton.onClick.RemoveListener(HandleExitPressed);
    }

    private IEnumerator showButtons()
    {
        playButton.transform.DOMoveX(-200, 0, false);
        optionsButton.transform.DOMoveX(-200, 0, false);
        exitButton.transform.DOMoveX(-200, 0, false);
        yield return new WaitForSeconds(secondsBetweenButtonMoves);
        playButton.transform.DOMoveX(-10, secondsToMoveButton, false).SetEase(ease);
        yield return new WaitForSeconds(secondsBetweenButtonMoves);
        optionsButton.transform.DOMoveX(-10, secondsToMoveButton, false).SetEase(ease);
        yield return new WaitForSeconds(secondsBetweenButtonMoves);
        exitButton.transform.DOMoveX(-10, secondsToMoveButton, false).SetEase(ease);
    }

    void HandlePlayPressed()
    {

    }

    void HandleOptionsPressed()
    {

    }

    void HandleExitPressed()
    {

    }
}
