using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeController : MonoBehaviour
{
    [SerializeField]
    private EscapeTimer escapeTimer;

    [SerializeField]
    private EscapeZone[] escapeZones;

    private float currentTime;
    private IEnumerator currentCoroutine;

    private void OnEnable()
    {
        foreach (var escapeZone in escapeZones)
        {
            escapeZone.OnEnter += HandleEnter;
            escapeZone.OnExit += HandleExit;
        }
    }

    private void OnDisable()
    {
        foreach (var escapeZone in escapeZones)
        {
            escapeZone.OnEnter -= HandleEnter;
            escapeZone.OnExit -= HandleExit;
        }
    }

    private void HandleEnter(float time)
    {
        currentTime = time;
        currentCoroutine = StartTimer();
        StartCoroutine(currentCoroutine);
        escapeTimer.Show();
    }

    private void HandleExit()
    {
        currentTime = 0;
        StopCoroutine(currentCoroutine);
        escapeTimer.Hide();
    }

    private IEnumerator StartTimer()
    {
        do
        {
            currentTime -= Time.deltaTime;
            UpdateTimeText();

            yield return null;
        } while (currentTime > 0);

        SuccessfulEscape();
    }

    public void UpdateTimeText()
    {
        float normalizedTime = Mathf.Max(0, currentTime);
        int minutes = Mathf.FloorToInt(normalizedTime / 60);
        int seconds = Mathf.FloorToInt(normalizedTime % 60);

        escapeTimer.Text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void SuccessfulEscape()
    {
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }
}
