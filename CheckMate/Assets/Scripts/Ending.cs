using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject Checkmate_BG;
    public GameObject Maros_BG;
    public GameObject Tress_BG;
    public GameObject Lights_BG;
    void Start()
    {
        if (PlayerPrefs.GetInt("kd01") == 0 && PlayerPrefs.GetInt("kd02") == 0 && PlayerPrefs.GetInt("kd03") == 0) Lights_BG.SetActive(true);
        else if (PlayerPrefs.GetInt("kd02") == 0 && PlayerPrefs.GetInt("kd03") == 0 && PlayerPrefs.GetInt("kd04") == 0) Checkmate_BG.SetActive(true);
        else if (PlayerPrefs.GetInt("kd01") == 0 && PlayerPrefs.GetInt("kd03") == 0 && PlayerPrefs.GetInt("kd04") == 0) Maros_BG.SetActive(true);
        else if (PlayerPrefs.GetInt("kd01") == 0 && PlayerPrefs.GetInt("kd02") == 0 && PlayerPrefs.GetInt("kd04") == 0) Tress_BG.SetActive(true);
    }  
    
}
