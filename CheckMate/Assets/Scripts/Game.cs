using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour  // 기물 생성, 턴
{
    public GameObject controller;
    public GameObject chesspiece;

    public GameObject Barri;
    private GameObject[,] positions = new GameObject[8, 8];

    public string CurPlayer;
    public string Player01;
    public string Player02;

    public int Player01_turn = 1;
    public int Player02_turn = 0;

    public Slider Player01_HP;
    public Slider Player02_HP;

    public float maxHealth = 100;
    public float Player01_curHealth;
    public float Player02_curHealth;

    public Sprite Turn_CM, Turn_T, Turn_L, Turn_M;
    public GameObject Turn;

    private GameObject[] KD01 = new GameObject[16];
    private GameObject[] KD02 = new GameObject[16];
    private GameObject[] KD03 = new GameObject[16];
    private GameObject[] KD04 = new GameObject[16];

    void Start()
    {
        Player01 = PlayerPrefs.GetString("player01");
        Player02 = PlayerPrefs.GetString("player02");

        CurPlayer = Player01;
        Debug.Log("Player01_turn : " + Player01_turn);

        Image turn = Turn.GetComponent<Image>();
        if (CurPlayer == "KD01") turn.sprite = Turn_CM;
        else if (CurPlayer == "KD02") turn.sprite = Turn_M;
        else if (CurPlayer == "KD03") turn.sprite = Turn_T;
        else if (CurPlayer == "KD04") turn.sprite = Turn_L;

        Player01_curHealth = maxHealth;
        Player02_curHealth = maxHealth;

        Player01_HP.value = Player01_curHealth / maxHealth;
        Player02_HP.value = Player02_curHealth / maxHealth;

        Item item = GetComponent<Item>();
        switch (CurPlayer)
        {
            case "KD01": item.KD01_item(); break;
            case "KD02": item.KD02_item(); break;
            case "KD03": item.KD03_item(); break;
            case "KD04": item.KD04_item(); break;
        }

        if (Player01 == "KD01")
        {
            KD01 = new GameObject[]
             {
                Create("KD01_Rook", 0, 0), Create("KD01_Rook", 7, 0),
                Create("KD01_Knight", 1, 0), Create("KD01_Knight", 6, 0),
                Create("KD01_Bishop", 2, 0), Create("KD01_Bishop", 5, 0),
                Create("KD01_Queen", 3, 0),
                Create("KD01_King", 4, 0),

                Create("KD01_Pawn", 0, 1), Create("KD01_Pawn", 1, 1), Create("KD01_Pawn", 2, 1),
                Create("KD01_Pawn", 3, 1), Create("KD01_Pawn", 4, 1), Create("KD01_Pawn", 5, 1),
                Create("KD01_Pawn", 6, 1), Create("KD01_Pawn", 7, 1)
              };
        }
        else if (Player02 == "KD01")
        {
            KD01 = new GameObject[]
            {
                Create("KD01_Rook", 0, 7), Create("KD01_Rook", 7, 7),
                Create("KD01_Knight", 1, 7), Create("KD01_Knight", 6, 7),
                Create("KD01_Bishop", 2, 7), Create("KD01_Bishop", 5, 7),
                Create("KD01_Queen", 3, 7),
                Create("KD01_King", 4, 7),

                Create("KD01_Pawn", 0, 6), Create("KD01_Pawn", 1, 6), Create("KD01_Pawn", 2, 6),
                Create("KD01_Pawn", 3, 6), Create("KD01_Pawn", 4, 6), Create("KD01_Pawn", 5, 6),
                Create("KD01_Pawn", 6, 6), Create("KD01_Pawn", 7, 6)
             };
        }

        if (Player01 == "KD02")
        {
            KD02 = new GameObject[]
            {
                Create("KD02_Rook", 0, 0), Create("KD02_Rook", 7, 0),
                Create("KD02_Knight", 1, 0), Create("KD02_Knight", 6, 0),
                Create("KD02_Bishop", 2, 0), Create("KD02_Bishop", 5, 0),
                Create("KD02_Queen", 3, 0),
                Create("KD02_King", 4, 0),

                Create("KD02_Pawn", 0, 1), Create("KD02_Pawn", 1, 1), Create("KD02_Pawn", 2, 1),
                Create("KD02_Pawn", 3, 1), Create("KD02_Pawn", 4, 1), Create("KD02_Pawn", 5, 1),
                Create("KD02_Pawn", 6, 1), Create("KD02_Pawn", 7, 1)

            };
        }
        else if (Player02 == "KD02")
        {
            KD02 = new GameObject[]
            {
                Create("KD02_Rook", 0, 7), Create("KD02_Rook", 7, 7),
                Create("KD02_Knight", 1, 7), Create("KD02_Knight", 6, 7),
                Create("KD02_Bishop", 2, 7), Create("KD02_Bishop", 5, 7),
                Create("KD02_Queen", 3, 7),
                Create("KD02_King", 4, 7),

                Create("KD02_Pawn", 0, 6), Create("KD02_Pawn", 1, 6), Create("KD02_Pawn", 2, 6),
                Create("KD02_Pawn", 3, 6), Create("KD02_Pawn", 4, 6), Create("KD02_Pawn", 5, 6),
                Create("KD02_Pawn", 6, 6), Create("KD02_Pawn", 7, 6)

            };
        }

        if (Player01 == "KD03")
        {
            KD03 = new GameObject[]
            {
                Create("KD03_Rook", 0, 0), Create("KD03_Rook", 7, 0),
                Create("KD03_Knight", 1, 0), Create("KD03_Knight", 6, 0),
                Create("KD03_Bishop", 2, 0), Create("KD03_Bishop", 5, 0),
                Create("KD03_Queen", 3, 0),
                Create("KD03_King", 4, 0),

                Create("KD03_Pawn", 0, 1), Create("KD03_Pawn", 1, 1), Create("KD03_Pawn", 2, 1),
                Create("KD03_Pawn", 3, 1), Create("KD03_Pawn", 4, 1), Create("KD03_Pawn", 5, 1),
                Create("KD03_Pawn", 6, 1), Create("KD03_Pawn", 7, 1)

            };
        }
        else if (Player02 == "KD03")
        {
            KD03 = new GameObject[]
            {
                Create("KD03_Rook", 0, 7), Create("KD03_Rook", 7, 7),
                Create("KD03_Knight", 1, 7), Create("KD03_Knight", 6, 7),
                Create("KD03_Bishop", 2, 7), Create("KD03_Bishop", 5, 7),
                Create("KD03_Queen", 3, 7),
                Create("KD03_King", 4, 7),

                Create("KD03_Pawn", 0, 6), Create("KD03_Pawn", 1, 6), Create("KD03_Pawn", 2, 6),
                Create("KD03_Pawn", 3, 6), Create("KD03_Pawn", 4, 6), Create("KD03_Pawn", 5, 6),
                Create("KD03_Pawn", 6, 6), Create("KD03_Pawn", 7, 6)

            };
        }

        if (Player01 == "KD04")
        {
            KD04 = new GameObject[]
            {
                Create("KD04_Rook", 0, 0), Create("KD04_Rook", 7, 0),
                Create("KD04_Knight", 1, 0), Create("KD04_Knight", 6, 0),
                Create("KD04_Bishop", 2, 0), Create("KD04_Bishop", 5, 0),
                Create("KD04_Queen", 3, 0),
                Create("KD04_King", 4, 0),

                Create("KD04_Pawn", 0, 1), Create("KD04_Pawn", 1, 1), Create("KD04_Pawn", 2, 1),
                Create("KD04_Pawn", 3, 1), Create("KD04_Pawn", 4, 1), Create("KD04_Pawn", 5, 1),
                Create("KD04_Pawn", 6, 1), Create("KD04_Pawn", 7, 1)

            };
        }
        else if (Player02 == "KD04")
        {
            KD04 = new GameObject[]
            {
                Create("KD04_Rook", 0, 7), Create("KD04_Rook", 7, 7),
                Create("KD04_Knight", 1, 7), Create("KD04_Knight", 6, 7),
                Create("KD04_Bishop", 2, 7), Create("KD04_Bishop", 5, 7),
                Create("KD04_Queen", 3, 7),
                Create("KD04_King", 4, 7),

                Create("KD04_Pawn", 0, 6), Create("KD04_Pawn", 1, 6), Create("KD04_Pawn", 2, 6),
                Create("KD04_Pawn", 3, 6), Create("KD04_Pawn", 4, 6), Create("KD04_Pawn", 5, 6),
                Create("KD04_Pawn", 6, 6), Create("KD04_Pawn", 7, 6)

            };
        }

        int maxLength = Mathf.Max(KD01.Length, KD02.Length, KD03.Length, KD04.Length);
        for (int i = 0; i < maxLength; i++)
        {
            if (i < KD01.Length && KD01[i] != null)
                SetPosition(KD01[i]);

            if (i < KD02.Length && KD02[i] != null)
                SetPosition(KD02[i]);

            if (i < KD03.Length && KD03[i] != null)
                SetPosition(KD03[i]);

            if (i < KD04.Length && KD04[i] != null)
                SetPosition(KD04[i]);
        }
    }
    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, -2), Quaternion.identity);
        Chessman cm = obj.GetComponent<Chessman>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }
    public void SetPosition(GameObject obj)
    {
        Chessman cm = obj.GetComponent<Chessman>();
        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y)
    { 
        positions[x, y] = null;
    }
    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }
    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }
    public string GetCurrentPlayer()
    {
        return CurPlayer;
    }

    public void NextTurn()
    {
        Item item = GetComponent<Item>();
        Image turn = Turn.GetComponent<Image>();
        Chessman chessman = GetComponent<Chessman>();
        if (CurPlayer == Player01 )
        {
            CurPlayer = Player02;

            if (CurPlayer == "KD01") turn.sprite = Turn_CM;
            else if (CurPlayer == "KD02") turn.sprite = Turn_M;
            else if (CurPlayer == "KD03") turn.sprite = Turn_T;
            else if (CurPlayer == "KD04") turn.sprite = Turn_L;

            PlayerPrefs.SetInt("Attack_P", 0);
            PlayerPrefs.SetInt("P_Turn", 0);
            PlayerPrefs.SetInt("Move_P", 0);

            Barri = GameObject.Find("Barricade");
            Destroy(Barri);

            Player02_turn++;
            Debug.Log("Player02_turn : " + Player02_turn);
            switch (CurPlayer)
            {
                case "KD01": item.KD01_item(); break;
                case "KD02": item.KD02_item(); break;
                case "KD03": item.KD03_item(); break;
                case "KD04": item.KD04_item(); break;
            }
        }
        else
        {
            CurPlayer = Player01;
            if (CurPlayer == "KD01") turn.sprite = Turn_CM;
            else if (CurPlayer == "KD02") turn.sprite = Turn_M;
            else if (CurPlayer == "KD03") turn.sprite = Turn_T;
            else if (CurPlayer == "KD04") turn.sprite = Turn_L;

            PlayerPrefs.SetInt("Attack_P", 0);
            PlayerPrefs.SetInt("P_Turn", 0);
            PlayerPrefs.SetInt("Move_P", 0);

            Barri = GameObject.Find("Barricade");
            Destroy(Barri);

            Player01_turn++;
            Debug.Log("Player01_turn : " + Player01_turn);
            switch (CurPlayer)
            {
                case "KD01": item.KD01_item(); break;
                case "KD02": item.KD02_item(); break;
                case "KD03": item.KD03_item(); break;
                case "KD04": item.KD04_item(); break;
            }
        }
    }
    

    public GameObject Checkmate_Lose_BG;
    public GameObject Maros_Lose_BG;
    public GameObject Tress_Lose_BG;
    public GameObject Lights_Lose_BG;

    public void HP_Dec()
    {
        Main main = chesspiece.GetComponent<Main>();
        Item item = chesspiece.GetComponent<Item>();
        int Attack_P = PlayerPrefs.GetInt("Attack_P");
        if (CurPlayer == Player01)
        {
            switch (PlayerPrefs.GetString("ChessPiece"))
            {
                case "King": Player02_curHealth -= 30 + Attack_P; break;
                case "Queen": Player02_curHealth -= 25 + Attack_P; break;
                case "Bishop": Player02_curHealth -= 15 + Attack_P; break;
                case "Rook": Player02_curHealth -= 15 + Attack_P; break;
                case "Knight": Player02_curHealth -= 10 + Attack_P; break;
                case "Pawn": Player02_curHealth -= 5 + Attack_P; break;
            }
            
            if (Player02_curHealth <= 0)
            {
                Player02_curHealth = 0;
                PlayerPrefs.SetInt("isPlayer02Alive", 0);

                if (Player02 == "KD01") { PlayerPrefs.SetInt("kd01", 0); Checkmate_Lose_BG.SetActive(true); }
                else if (Player02 == "KD02") { PlayerPrefs.SetInt("kd02", 0); Maros_Lose_BG.SetActive(true); }
                else if (Player02 == "KD03") { PlayerPrefs.SetInt("kd03", 0); Tress_Lose_BG.SetActive(true); }
                else if (Player02 == "KD04") { PlayerPrefs.SetInt("kd04", 0); Lights_Lose_BG.SetActive(true); }
                PlayerPrefs.SetString("Win_Player", Player01);
            }
        }
        else if (CurPlayer == Player02)
        {
            switch (PlayerPrefs.GetString("ChessPiece"))
            {
                case "King": Player01_curHealth -= 30 + Attack_P; break;
                case "Queen": Player01_curHealth -= 25 + Attack_P; break;
                case "Bishop": Player01_curHealth -= 15 + Attack_P; break;
                case "Rook": Player01_curHealth -= 15 + Attack_P; break;
                case "Knight": Player01_curHealth -= 10 + Attack_P; break;
                case "Pawn": Player01_curHealth -= 5 + Attack_P; break;
            }
            if (Player01_curHealth <= 0)
            {
                Player01_curHealth = 0;
                PlayerPrefs.SetInt("isPlayer01Alive", 0);

                if (Player01 == "KD01") { PlayerPrefs.SetInt("kd01", 0); Checkmate_Lose_BG.SetActive(true); }
                else if (Player01 == "KD02") { PlayerPrefs.SetInt("kd02", 0); Maros_Lose_BG.SetActive(true); }
                else if (Player01 == "KD03") {PlayerPrefs.SetInt("kd03", 0); Tress_Lose_BG.SetActive(true); }
                else if (Player01 == "KD04") { PlayerPrefs.SetInt("kd04", 0); Lights_Lose_BG.SetActive(true); }
                PlayerPrefs.SetString("Win_Player", Player02);
                IsGameOver();
            }
        }
        Player01_HP.value = (float)Player01_curHealth / maxHealth;
        Player02_HP.value = (float)Player02_curHealth / maxHealth;

        Debug.Log("Player01 : " + Player01_HP.value * 100);
        Debug.Log("Player02 : " + Player02_HP.value * 100);
    }
    public void IsGameOver()
    {
        if (PlayerPrefs.GetInt("kd01") == 0 && PlayerPrefs.GetInt("kd02") == 0 && PlayerPrefs.GetInt("kd03") == 0) SceneManager.LoadScene("EndingScene");
        else if (PlayerPrefs.GetInt("kd02") == 0 && PlayerPrefs.GetInt("kd03") == 0 && PlayerPrefs.GetInt("kd04") == 0) SceneManager.LoadScene("EndingScene");
        else if (PlayerPrefs.GetInt("kd01") == 0 && PlayerPrefs.GetInt("kd03") == 0 && PlayerPrefs.GetInt("kd04") == 0) SceneManager.LoadScene("EndingScene");
        else if (PlayerPrefs.GetInt("kd01") == 0 && PlayerPrefs.GetInt("kd02") == 0 && PlayerPrefs.GetInt("kd04") == 0) SceneManager.LoadScene("EndingScene");
        else
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    private void Update()
    {
        Player01_HP.value = Player01_curHealth / maxHealth;
        Player02_HP.value = Player02_curHealth / maxHealth;
    }
}

