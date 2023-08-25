using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pnlEndGame;
    public Button btnRestart;
    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnClick;
    public Text txtPoint;
    private int gamePoint;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pnlEndGame.SetActive(false);
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Ham tinh diem
    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }

    //Hieu ung khi hover vao button
    public void ButtonHover()
    {
        btnRestart.GetComponent<Image>().sprite = btnHover;
    }

    //Hieu ung binh thuong cua button
    public void ButtonIdle()
    {
        btnRestart.GetComponent<Image>().sprite = btnIdle;
    }

    //Hieu ung khi click vao button
    public void ButtonClick()
    {
        btnRestart.GetComponent<Image>().sprite = btnClick;
    }


    //Khi click vao restart se bat dau lai game
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        pnlEndGame.SetActive(true);
        audio.Play();
    }
}
