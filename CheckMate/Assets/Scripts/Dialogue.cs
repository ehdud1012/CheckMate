using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Button Next;
    public GameObject Next_1;
    public GameObject MapNext;
    public GameObject dialogue;
    public GameObject game_info;
    private int clickCount = 0;

    public Sprite S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12, S13, S14;
    public Sprite info_1, info_2, info_3, info_4, info_5;
    public Sprite KD01, KD02, KD03, KD04;
    public GameObject CP;
    public GameObject CM,M, T, L;
    public GameObject MapChoice;
    void Start()
    {
        if(PlayerPrefs.GetInt("kd01") == 0 || PlayerPrefs.GetInt("kd02") == 0 || PlayerPrefs.GetInt("kd03") == 0 || PlayerPrefs.GetInt("kd04") == 0)
        {
            Next_1.SetActive(false);
            MapNext.SetActive(false);
            dialogue.SetActive(false);
            game_info.SetActive(false);
            CP.SetActive(false);
            MapChoice.SetActive(true);
        }
        if (Next != null)
        {
            Next.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Button not assigned in the inspector.");
        }
    }

    private void OnButtonClick()
    {
        Image next = dialogue.GetComponent<Image>();
        Image Game_Info = game_info.GetComponent<Image>();
        Image cp = CP.GetComponent<Image>();
        switch (clickCount)
        {
            case 1: next.sprite = S2; CP.SetActive(true); break;
            case 2: next.sprite = S3; break;
            case 3: next.sprite = S4; break;
            case 4: next.sprite = S5; cp.sprite = KD04; L.SetActive(true); CM.SetActive(false); break;
            case 5: next.sprite = S6; break;
            case 6: next.sprite = S7; break;
            case 7: next.sprite = S8; cp.sprite = KD03; T.SetActive(true); L.SetActive(false); break;
            case 8: next.sprite = S9; break;
            case 9: next.sprite = S10; break;
            case 10: next.sprite = S11; cp.sprite = KD02; M.SetActive(true); T.SetActive(false); break;
            case 11: next.sprite = S12; break;
            case 12: next.sprite = S13; break;
            case 13: next.sprite = S14; break;
            case 14: dialogue.SetActive(false); CP.SetActive(false); game_info.SetActive(true); Game_Info.sprite = info_1; CM.SetActive(true); M.SetActive(false); break;
            case 15: Game_Info.sprite = info_2; break;
            case 16: Game_Info.sprite = info_3; break;
            case 17: Game_Info.sprite = info_4; break;
            case 18: Game_Info.sprite = info_5; MapNext.SetActive(true); Next_1.SetActive(false); break;
        }
        clickCount++;
    }
    public void Map()
    {
        game_info.SetActive(false);
        MapChoice.SetActive(true);
    }
}
