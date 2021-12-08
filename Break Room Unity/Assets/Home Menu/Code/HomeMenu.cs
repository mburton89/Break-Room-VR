using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    [SerializeField] Button breakButton;
    [SerializeField] Button dodgeButton;
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
        breakButton.onClick.AddListener(HandleBreakPressed);
        dodgeButton.onClick.AddListener(HandleDodgePressed);
        exitButton.onClick.AddListener(HandleExitPressed);
    }

    private void OnDisable()
    {
        breakButton.onClick.RemoveListener(HandleBreakPressed);
        dodgeButton.onClick.RemoveListener(HandleDodgePressed);
        exitButton.onClick.RemoveListener(HandleExitPressed);
    }

    private IEnumerator showButtons()
    {
        breakButton.transform.DOMoveX(-200, 0, false);
        dodgeButton.transform.DOMoveX(-200, 0, false);
        exitButton.transform.DOMoveX(-200, 0, false);
        yield return new WaitForSeconds(secondsBetweenButtonMoves);
        breakButton.transform.DOMoveX(-10, secondsToMoveButton, false).SetEase(ease);
        yield return new WaitForSeconds(secondsBetweenButtonMoves);
        dodgeButton.transform.DOMoveX(-10, secondsToMoveButton, false).SetEase(ease);
        yield return new WaitForSeconds(secondsBetweenButtonMoves);
        exitButton.transform.DOMoveX(-10, secondsToMoveButton, false).SetEase(ease);
    }

    void HandleBreakPressed()
    {
        SceneManager.LoadScene(1);
    }

    void HandleDodgePressed()
    {
        SceneManager.LoadScene(2);
    }

    void HandleExitPressed()
    {

    }
}
