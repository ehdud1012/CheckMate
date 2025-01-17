using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void GoStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void GoMainScene()
    {
        SceneManager.LoadScene("MainScene");

        PlayerPrefs.SetInt("isPlayer01Alive", 0);
        PlayerPrefs.SetInt("isPlayer02Alive", 0);
        PlayerPrefs.SetInt("kd01", 1);
        PlayerPrefs.SetInt("kd02", 1);
        PlayerPrefs.SetInt("kd03", 1);
        PlayerPrefs.SetInt("kd04", 1);
        PlayerPrefs.SetInt("P_Turn", 0);
        PlayerPrefs.SetInt("knight_M", 0);
    }
    public void GoGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
