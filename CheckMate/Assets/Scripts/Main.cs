using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Button kd01;
    public Button kd02;
    public Button kd03;
    public Button kd04;
    public Button startButton;

    public GameObject map;
    
    public Sprite Checkmate_L, Checkmate_M, Checkmate_T, Checkmate_L_M, Checkmate_M_T, Checkmate_L_T;
    public Sprite Maros_CM, Maros_L, Maros_T, Maros_CM_L, Maros_CM_T, Maros_L_T;
    public Sprite Tress_CM, Tress_L, Tress_M, Tress_CM_L, Tress_CM_M, Tress_M_L;
    public Sprite Lights_CM, Lights_M, Lights_T, Lights_CM_M, Lights_CM_T, Lights_M_T;
    
    public GameObject one;
    public GameObject two;
    public Sprite CM, M, T, L;

    private string player01;
    private string player02;
    private bool isPlayer01Alive = true;
    private bool isPlayer02Alive = true;

    void Start()
    {
        Image Map = map.GetComponent<Image>();
        if (PlayerPrefs.GetInt("kd01") == 0) Destroy(kd01);
        if (PlayerPrefs.GetInt("kd02") == 0) Destroy(kd02);
        if (PlayerPrefs.GetInt("kd03") == 0) Destroy(kd03);
        if (PlayerPrefs.GetInt("kd04") == 0) Destroy(kd04);

        if (PlayerPrefs.GetString("Win_Player") == "KD01")
        {
            if(PlayerPrefs.GetInt("kd02") == 0 && PlayerPrefs.GetInt("kd03") == 1 && PlayerPrefs.GetInt("kd04") == 1) Map.sprite = Checkmate_M;
            else if (PlayerPrefs.GetInt("kd02") == 1 && PlayerPrefs.GetInt("kd03") == 0 && PlayerPrefs.GetInt("kd04") == 1) Map.sprite = Checkmate_T;
            else if (PlayerPrefs.GetInt("kd02") == 1 && PlayerPrefs.GetInt("kd03") == 1 && PlayerPrefs.GetInt("kd04") == 0) Map.sprite = Checkmate_L;
            else if (PlayerPrefs.GetInt("kd02") == 0 && PlayerPrefs.GetInt("kd03") == 0 && PlayerPrefs.GetInt("kd04") == 1) Map.sprite = Checkmate_M_T;
            else if (PlayerPrefs.GetInt("kd02") == 0 && PlayerPrefs.GetInt("kd03") == 1 && PlayerPrefs.GetInt("kd04") == 0) Map.sprite = Checkmate_L_M;
            else if (PlayerPrefs.GetInt("kd02") == 1 && PlayerPrefs.GetInt("kd03") == 0 && PlayerPrefs.GetInt("kd04") == 0) Map.sprite = Checkmate_L_T;
        }
        else if (PlayerPrefs.GetString("Win_Player") == "KD02")
        {
            if (PlayerPrefs.GetInt("kd01") == 0 && PlayerPrefs.GetInt("kd03") == 1 && PlayerPrefs.GetInt("kd04") == 1) Map.sprite = Maros_CM;
            else if (PlayerPrefs.GetInt("kd01") == 1 && PlayerPrefs.GetInt("kd03") == 0 && PlayerPrefs.GetInt("kd04") == 1) Map.sprite = Maros_T;
            else if (PlayerPrefs.GetInt("kd01") == 1 && PlayerPrefs.GetInt("kd03") == 1 && PlayerPrefs.GetInt("kd04") == 0) Map.sprite = Maros_L;
            else if (PlayerPrefs.GetInt("kd01") == 0 && PlayerPrefs.GetInt("kd03") == 0 && PlayerPrefs.GetInt("kd04") == 1) Map.sprite = Maros_CM_T;
            else if (PlayerPrefs.GetInt("kd01") == 0 && PlayerPrefs.GetInt("kd03") == 1 && PlayerPrefs.GetInt("kd04") == 0) Map.sprite = Maros_CM_L;
            else if (PlayerPrefs.GetInt("kd01") == 1 && PlayerPrefs.GetInt("kd03") == 0 && PlayerPrefs.GetInt("kd04") == 0) Map.sprite = Maros_L_T;
        }
        else if (PlayerPrefs.GetString("Win_Player") == "KD03")
        {
            if (PlayerPrefs.GetInt("kd01") == 0 && PlayerPrefs.GetInt("kd02") == 1 && PlayerPrefs.GetInt("kd04") == 1) Map.sprite = Tress_CM;
            else if (PlayerPrefs.GetInt("kd01") == 1 && PlayerPrefs.GetInt("kd02") == 0 && PlayerPrefs.GetInt("kd04") == 1) Map.sprite = Tress_M;
            else if (PlayerPrefs.GetInt("kd01") == 1 && PlayerPrefs.GetInt("kd02") == 1 && PlayerPrefs.GetInt("kd04") == 0) Map.sprite = Tress_L;
            else if (PlayerPrefs.GetInt("kd01") == 0 && PlayerPrefs.GetInt("kd02") == 0 && PlayerPrefs.GetInt("kd04") == 1) Map.sprite = Tress_CM_M;
            else if (PlayerPrefs.GetInt("kd01") == 0 && PlayerPrefs.GetInt("kd02") == 1 && PlayerPrefs.GetInt("kd04") == 0) Map.sprite = Tress_CM_L;
            else if (PlayerPrefs.GetInt("kd01") == 1 && PlayerPrefs.GetInt("kd02") == 0 && PlayerPrefs.GetInt("kd04") == 0) Map.sprite = Tress_M_L;
        }
        else if (PlayerPrefs.GetString("Win_Player") == "KD04")
        {
            if (PlayerPrefs.GetInt("kd01") == 0 && PlayerPrefs.GetInt("kd02") == 1 && PlayerPrefs.GetInt("kd03") == 1) Map.sprite = Lights_CM;
            else if (PlayerPrefs.GetInt("kd01") == 1 && PlayerPrefs.GetInt("kd02") == 0 && PlayerPrefs.GetInt("kd03") == 1) Map.sprite = Lights_M;
            else if (PlayerPrefs.GetInt("kd01") == 1 && PlayerPrefs.GetInt("kd02") == 1 && PlayerPrefs.GetInt("kd03") == 0) Map.sprite = Lights_T;
            else if (PlayerPrefs.GetInt("kd01") == 0 && PlayerPrefs.GetInt("kd02") == 0 && PlayerPrefs.GetInt("kd03") == 1) Map.sprite = Lights_CM_M;
            else if (PlayerPrefs.GetInt("kd01") == 0 && PlayerPrefs.GetInt("kd02") == 1 && PlayerPrefs.GetInt("kd03") == 0) Map.sprite = Lights_CM_T;
            else if (PlayerPrefs.GetInt("kd01") == 1 && PlayerPrefs.GetInt("kd02") == 0 && PlayerPrefs.GetInt("kd03") == 0) Map.sprite = Lights_M_T;
        }

        kd01.onClick.AddListener(() => OnCountryButtonClicked("KD01"));
        kd02.onClick.AddListener(() => OnCountryButtonClicked("KD02"));
        kd03.onClick.AddListener(() => OnCountryButtonClicked("KD03"));
        kd04.onClick.AddListener(() => OnCountryButtonClicked("KD04"));

        // Start 버튼 클릭 시 OnStartGame 함수 호출
        startButton.onClick.AddListener(OnStartGame);

        LoadPlayerHealthStatus();
    }
    void OnCountryButtonClicked(string country)
    {
        Image One = one.GetComponent<Image>();
        Image Two = two.GetComponent<Image>();

        if (string.IsNullOrEmpty(player01) || !isPlayer01Alive)
        {
            player01 = country;

            if (player01 == "KD01") One.sprite = CM;
            else if(player01 == "KD02") One.sprite = M;
            else if (player01 == "KD03") One.sprite = T;
            else if (player01 == "KD04") One.sprite = L;

            one.SetActive(true);
            isPlayer01Alive = true;
        }
        else if ((string.IsNullOrEmpty(player02) && player01 != country) || !isPlayer02Alive)
        {
            player02 = country;

            if (player02 == "KD01") Two.sprite = CM;
            else if (player02 == "KD02") Two.sprite = M;
            else if (player02 == "KD03") Two.sprite = T;
            else if (player02 == "KD04") Two.sprite = L;

            two.SetActive(true);
            isPlayer02Alive = true;
        }
        else
        {
            Debug.LogError("이미 선택되었습니다 !");
        }
    }

    void OnStartGame()
    {
        if (string.IsNullOrEmpty(player01) || string.IsNullOrEmpty(player02))
        {
            Debug.LogError("나라를 선택해주세요 !");
            return;
        }

        // 선택된 나라 정보를 저장하고 게임을 시작하는 로직을 구현합니다.
        PlayerPrefs.SetString("player01", player01);
        PlayerPrefs.SetString("player02", player02);
        PlayerPrefs.SetInt("isPlayer01Alive", isPlayer01Alive ? 1 : 0);
        PlayerPrefs.SetInt("isPlayer02Alive", isPlayer02Alive ? 1 : 0);

        SceneManager.LoadScene("GameScene");
    }

    void LoadPlayerHealthStatus()
    {
        isPlayer01Alive = PlayerPrefs.GetInt("isPlayer01Alive", 1) == 1;
        isPlayer02Alive = PlayerPrefs.GetInt("isPlayer02Alive", 1) == 1;

        Image One = one.GetComponent<Image>();
        Image Two = two.GetComponent<Image>();

        if (isPlayer01Alive)
        {
            player01 = PlayerPrefs.GetString("player01", "");

            if (player01 == "KD01") One.sprite = CM;
            else if (player01 == "KD02") One.sprite = M;
            else if (player01 == "KD03") One.sprite = T;
            else if (player01 == "KD04") One.sprite = L;

            if (!string.IsNullOrEmpty(player01))
            {
                one.SetActive(true);
            }
        }

        if (isPlayer02Alive)
        {
            player02 = PlayerPrefs.GetString("player02", "");

            if (player02 == "KD01") Two.sprite = CM;
            else if (player02 == "KD02") Two.sprite = M;
            else if (player02 == "KD03") Two.sprite = T;
            else if (player02 == "KD04") Two.sprite = L;

            if (!string.IsNullOrEmpty(player02))
            {
                two.SetActive(true);
            }
        }
    }
}
