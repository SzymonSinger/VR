using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayHandler : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject movement;
    public GameObject teleportation;
    public GameObject turning;

    public TextMeshProUGUI TM;
    private SoundManager SM;

    private bool ScreenShowed = false;
    // Start is called before the first frame update
    void Start()
    {
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

    public IEnumerator Countdown(int seconds)
    {
        if (seconds <= 0)
        {
            RestartGame();
        }
        yield return TM.text = $"Restart in {seconds}";
        yield return new WaitForSeconds(1);
        seconds--;
        StartCoroutine(Countdown(seconds));
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
