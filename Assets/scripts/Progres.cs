using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Progres : MonoBehaviour
{
    // Pozycja triggera startowego
    [SerializeField] Transform startPoint;
    // Pozycja triggera koñcowego
    [SerializeField] Transform finishPoint;
    // Odniesienie do obrazu wype³niaj¹cego pasek postêpu
    [SerializeField] Image progressBar;
    // Zmienna do przechowywania d³ugoœci poziomu
    float levelLength;
    // Start is called before the first frame update
    // Odniesienie do UI timera
    [SerializeField] TextMeshProUGUI timerText;
    // Czy timer dzia³a?
    bool timerRunning = false;
    // Licznik czasu
    // Referencja do tekstu rekordu
    [SerializeField] TextMeshProUGUI bestTimeText;
    // Zmienna dla rekordu
    float bestTime = Mathf.Infinity;
    float timer = 0f;
    void Start()
    {
        levelLength = finishPoint.position.z - startPoint.position.z;
        if (PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");
            bestTimeText.text = "Best Time: " + bestTime.ToString("F2");
        }
        else
        {
            bestTimeText.text = "Best Time: --";
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = transform.position.z - startPoint.position.z;
        float progress = Mathf.Clamp01(distance / levelLength);
        progressBar.fillAmount = progress;
        if (timerRunning)
        {
            timer += Time.deltaTime;
            timerText.text = "time: " + timer.ToString("F2");
        }
    
    
    
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Start") && !timerRunning)
        {
            timerRunning = true;
        }

        if (other.CompareTag("Finish") && timerRunning)
        {
            timerRunning = false;

            if (timer < bestTime)
            {
                bestTime = timer;
                PlayerPrefs.SetFloat("BestTime", bestTime);
                PlayerPrefs.Save();
                bestTimeText.text = "Best Time: " + bestTime.ToString("F2");
            }
        }
    }
}
