using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Serve : MonoBehaviour
{
    public int thisPlate;
    private int totalSalah = 0;
    public int totalBenar = 0;
    public GameObject correctPanel;
    public GameObject incorrectPanel;
    public GameObject gamePlayPanel;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject howtoplayPanel;

    // Start is called before the first frame update
    void Start()
    {
        correctPanel.SetActive(false);
        incorrectPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        howtoplayPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (Gameflow3.orderValue[Gameflow3.plateNum] == Gameflow3.plateValue[Gameflow3.plateNum])
        {
            SFXManager.instance.UIClick();
            Debug.Log("Correct" + " " + Gameflow3.orderTimer[Gameflow3.plateNum]);
            correctPanel.SetActive(true);
            gamePlayPanel.SetActive(false);
            //gameOverPanel.SetActive(false);
            Time.timeScale = 0;

        }

        else
        {
            SFXManager.instance.UIClick();
            Debug.Log("wrong");
            incorrectPanel.SetActive(true);
            gamePlayPanel.SetActive(false);
            gameOverPanel.SetActive(false);
            Time.timeScale = 0;
            totalSalah = totalSalah + 1;

            if (totalSalah == 5)
            {
                incorrectPanel.SetActive(false);
                gamePlayPanel.SetActive(false);
                gameOverPanel.SetActive(true);
                Debug.Log("Game Over!");
            }
        }

        Gameflow3.emptyPlateNow = transform.position.x;
        StartCoroutine(platereset());
    }

    IEnumerator platereset()
    {
        yield return new WaitForSeconds(.2f);
        Gameflow3.emptyPlateNow = -1; // -1 is indicating nothing more is to be deleted
        Gameflow3.totalCash += Gameflow3.orderTimer[thisPlate] * .10f; //the remaining time after serving the food will be multiplied by 0.1 and that will be your earning
    }


    public void CorrectContinueButton()
    {
        SFXManager.instance.UIClick();
        totalBenar = totalBenar + 1;
        Debug.Log(totalBenar);

        correctPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        Time.timeScale = 1;

        if (totalBenar == 3)
        {
            SceneManager.LoadScene("Stage3");
            Time.timeScale = 1;
        }
    }

    public void IncorrectContinueButton()
    {
        SFXManager.instance.UIClick();
        incorrectPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        Time.timeScale = 1;
    }

    public void PauseButton()
    {
        SFXManager.instance.UIClick();
        gamePlayPanel.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void PauseResumeButton()
    {
        SFXManager.instance.UIClick();
        gamePlayPanel.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SFXManager.instance.UIClick();
        SceneManager.LoadScene("Stage2");
        Time.timeScale = 1;
    }

    public void BackToMainMenu()
    {
        SFXManager.instance.UIClick();
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void HowToPlayButton()
    {
        SFXManager.instance.UIClick();
        howtoplayPanel.SetActive(true);
        gamePlayPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void HowToPlayResumeButton()
    {
        SFXManager.instance.UIClick();
        howtoplayPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        Time.timeScale = 1;
    }

}
