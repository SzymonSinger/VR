using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayHandler : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject deathScreen;
    public GameObject movement;
    public GameObject teleportation;
    public GameObject turning;

    public List<TextMeshProUGUI> restartTexts;
    private SoundManager SM;

    private bool ScreenShowed = false;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 90;
        SM = FindFirstObjectByType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ScreenShowed)
        {
            if (SM.Dead)
            {
                deathScreen.SetActive(true);
                movement.SetActive(false);
                teleportation.SetActive(false);
                turning.SetActive(false);
                ScreenShowed = true;
                StartCoroutine(Countdown(5));
            }
        }
    }

    public void CompleteGame() {
        winScreen.SetActive(true);
        movement.SetActive(false);
        teleportation.SetActive(false);
        turning.SetActive(false);
        ScreenShowed = true;
        StartCoroutine(Rave(5));
    }

    public IEnumerator Countdown(int seconds)
    {
        if (seconds <= 0)
        {
            RestartGame();
        }
        //yield return
        foreach (var TM in restartTexts) {
            TM.text = $"Restart in {seconds}";
        } 
        yield return new WaitForSeconds(1);
        seconds--;
        StartCoroutine(Countdown(seconds));
    }

    public IEnumerator Rave(int seconds)
    {
        if (seconds <= 0)
        {
            SceneManager.LoadScene(1);
        }
        //yield return
        foreach (var TM in restartTexts) {
            TM.text = $"Going to the rave in {seconds}";
        } 
        yield return new WaitForSeconds(1);
        seconds--;
        StartCoroutine(Rave(seconds));
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
