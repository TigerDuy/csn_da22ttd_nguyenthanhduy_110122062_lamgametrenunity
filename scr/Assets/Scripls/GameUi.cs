using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUi : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI HighSroce;

    // Update is called once per frame
    void Update()
    {
        Score.SetText(GameManager.instance.Getscore().ToString());
        HighSroce.SetText(GameManager.instance.Getscore().ToString());
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
