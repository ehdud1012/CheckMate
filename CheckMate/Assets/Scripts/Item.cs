using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Item : MonoBehaviour
{
    public GameObject controller;

    public Button Item01;
    public Button Item02;
    public Button Item03;

    public Sprite KD01_Item01, KD01_Item02, KD01_Item03;
    public Sprite KD02_Item01, KD02_Item02, KD02_Item03;
    public Sprite KD03_Item01, KD03_Item02, KD03_Item03;
    public Sprite KD04_Item01, KD04_Item02, KD04_Item03;
    public Sprite KD01_XX, KD02_XX, KD03_XX, KD04_XX;

    public int KD01_Item01_Count, KD01_Item02_Count, KD01_Item03_Count = 0;
    public int KD02_Item01_Count, KD02_Item02_Count, KD02_Item03_Count = 0;
    public int KD03_Item01_Count, KD03_Item02_Count, KD03_Item03_Count = 0;
    public int KD04_Item01_Count, KD04_Item02_Count, KD04_Item03_Count = 0;

    public RaycastHit2D hit;
    private void Update()
    {
        Game turn = GetComponent<Game>();
        if (turn.Player01_turn > 4)
        {
            Item01.interactable = true;
            Item02.interactable = true;
            Item03.interactable = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        }
    }
    public void KD01_item()
    {
        if (KD01_Item01_Count >= 2) this.Item01.GetComponent<Image>().sprite = this.KD01_XX;
        else this.Item01.GetComponent<Image>().sprite = this.KD01_Item01;

        if (KD01_Item02_Count >= 1) this.Item02.GetComponent<Image>().sprite = this.KD01_XX;
        else this.Item02.GetComponent<Image>().sprite = this.KD01_Item02;

        if (KD01_Item03_Count >= 1) this.Item03.GetComponent<Image>().sprite = this.KD01_XX;
        else this.Item03.GetComponent<Image>().sprite = this.KD01_Item03;
    }
    public void KD02_item()
    {
        if (KD02_Item01_Count >= 1) this.Item01.GetComponent<Image>().sprite = this.KD02_XX;
        else this.Item01.GetComponent<Image>().sprite = this.KD02_Item01;

        if (KD02_Item02_Count >= 5) this.Item02.GetComponent<Image>().sprite = this.KD02_XX;
        else this.Item02.GetComponent<Image>().sprite = this.KD02_Item02;

        if (KD02_Item03_Count >= 3) this.Item03.GetComponent<Image>().sprite = this.KD02_XX;
        else this.Item03.GetComponent<Image>().sprite = this.KD02_Item03;
    }
    public void KD03_item()
    {
        if (KD03_Item01_Count >= 1) this.Item01.GetComponent<Image>().sprite = this.KD03_XX;
        else this.Item01.GetComponent<Image>().sprite = this.KD03_Item01;

        if (KD03_Item02_Count >= 5) this.Item02.GetComponent<Image>().sprite = this.KD03_XX;
        else this.Item02.GetComponent<Image>().sprite = this.KD03_Item02;

        if (KD03_Item03_Count >= 1) this.Item03.GetComponent<Image>().sprite = this.KD03_XX;
        else this.Item03.GetComponent<Image>().sprite = this.KD03_Item03;
    }
    public void KD04_item()
    {
        if (KD04_Item01_Count >= 1) this.Item01.GetComponent<Image>().sprite = this.KD04_XX;
        else this.Item01.GetComponent<Image>().sprite = this.KD04_Item01;

        if (KD04_Item02_Count >= 1) this.Item02.GetComponent<Image>().sprite = this.KD04_XX;
        else this.Item02.GetComponent<Image>().sprite = this.KD04_Item02;

        if (KD04_Item03_Count >= 3) this.Item03.GetComponent<Image>().sprite = this.KD04_XX;
        else this.Item03.GetComponent<Image>().sprite = this.KD04_Item03;
    }

    public bool kd01_Item01, kd01_Item02, kd01_Item03 = false;
    public bool kd02_Item01, kd02_Item02, kd02_Item03 = false;
    public bool kd03_Item01, kd03_Item02, kd03_Item03 = false;
    public bool kd04_Item01, kd04_Item02, kd04_Item03 = false;

    public String Cur_Item;
    public bool Item1_3 = false;
    public bool Item3_1 = false;
    public GameObject info;
    public GameObject True1, True2, True3;
    public Sprite Info01_1, Info01_2, Info01_3, Info02_1, Info02_2, Info02_3,
                    Info03_1, Info03_2, Info03_3, Info04_1, Info04_2, Info04_3;
    public Sprite UI;

    public void itemClick(Button clidkButton) // 아이템 구현
    {
        Image Info = info.GetComponent<Image>();
        Image image = clidkButton.GetComponent<Image>();
        Game game = controller.GetComponent<Game>();
        Sprite sprite = image.sprite;

        switch (sprite.name)
        {
            case "KD01_Item01":
                if (KD01_Item01_Count == 0)
                {
                    if (!kd01_Item02 && !kd01_Item03)
                    {
                        if (Item3_1)
                        {
                            Debug.Log(" 무적입니다. ");
                            Item3_1 = false;
                            KD01_Item01_Count++;
                            if (KD01_Item01_Count >= 2) this.Item01.GetComponent<Image>().sprite = this.KD01_XX;
                        }
                        else
                        {
                            Info.sprite = Info01_1;
                            Cur_Item = "KD01_Item01";
                            kd01_Item01 = true;
                            True1.SetActive(true);
                        }
                    }
                    else if ((!kd01_Item02 && kd01_Item03) || (kd01_Item02 && !kd01_Item03) || (kd01_Item02 && kd01_Item03))
                        Debug.Log("이미 아이템을 사용하셨습니다.");
                }
                else
                {
                    int cool = PlayerPrefs.GetInt("KD01_01_cool");
                    if (game.Player01 == "KD01")
                    {
                        if (game.Player01_turn == cool + 3)
                        {
                            if (!kd01_Item02 && !kd01_Item03)
                            {
                                if (Item3_1)
                                {
                                    Debug.Log(" 무적입니다. ");
                                    Item3_1 = false;
                                    KD01_Item01_Count++;
                                    if (KD01_Item01_Count >= 2) this.Item01.GetComponent<Image>().sprite = this.KD01_XX;
                                }
                                else
                                {
                                    Info.sprite = Info01_1;
                                    Cur_Item = "KD01_Item01";
                                    kd01_Item01 = true;
                                    True1.SetActive(true);
                                }
                            }
                            else if ((!kd01_Item02 && kd01_Item03) || (kd01_Item02 && !kd01_Item03) || (kd01_Item02 && kd01_Item03))
                                Debug.Log("이미 아이템을 사용하셨습니다.");
                        }
                        else Debug.Log("쿨타임");
                    }
                    else if (game.Player02 == "KD01")
                    {
                        if (game.Player02_turn == cool + 3)
                        {
                            if (!kd01_Item02 && !kd01_Item03)
                            {
                                if (Item3_1)
                                {
                                    Debug.Log(" 무적입니다. ");
                                    Item3_1 = false;
                                    KD01_Item01_Count++;
                                    if (KD01_Item01_Count >= 2) this.Item01.GetComponent<Image>().sprite = this.KD01_XX;
                                }
                                else
                                {
                                    Info.sprite = Info01_1;
                                    Cur_Item = "KD01_Item01";
                                    kd01_Item01 = true;
                                    True1.SetActive(true);
                                }
                            }
                            else if ((!kd01_Item02 && kd01_Item03) || (kd01_Item02 && !kd01_Item03) || (kd01_Item02 && kd01_Item03))
                                Debug.Log("이미 아이템을 사용하셨습니다.");
                        }
                        else Debug.Log("쿨타임");
                    }
                }
                break;
            case "KD01_Item02":
                if (!kd01_Item01 && !kd01_Item03)
                {
                    if (Item3_1)
                    {
                        Debug.Log(" 무적입니다. ");
                        Item3_1 = false;
                        KD01_Item02_Count++;
                        if (KD01_Item02_Count >= 1) this.Item02.GetComponent<Image>().sprite = this.KD01_XX;
                    }
                    else
                    {
                        Info.sprite = Info01_2;
                        Cur_Item = "KD01_Item02";
                        kd01_Item02 = true;
                        True2.SetActive(true);
                    }
                }
                else if ((!kd01_Item01 && kd01_Item03) || (kd01_Item01 && !kd01_Item03) || (kd01_Item01 && kd01_Item03))
                    Debug.Log("이미 아이템을 사용하셨습니다.");
                break;
            case "KD01_Item03":
                if (!kd01_Item01 && !kd01_Item02)
                {
                    if (Item3_1)
                    {
                        Debug.Log(" 무적입니다. ");
                        Item3_1 = false;
                        KD01_Item03_Count++;
                        if (KD01_Item03_Count >= 1) this.Item03.GetComponent<Image>().sprite = this.KD01_XX;
                    }
                    else
                    {
                        Info.sprite = Info01_3;
                        Cur_Item = "KD01_Item03";
                        kd01_Item03 = true;
                        True3.SetActive(true);
                    }
                }
                else if ((!kd01_Item01 && kd01_Item02) || (kd01_Item01 && !kd01_Item02) || (kd01_Item01 && kd01_Item02))
                    Debug.Log("이미 아이템을 사용하셨습니다.");
                break;

            case "KD02_Item01":
                if (!kd02_Item02 && !kd02_Item03)
                {
                    if (Item1_3 || Item3_1)
                    {
                        Debug.Log(" 무적입니다. ");
                        Item1_3 = false;
                        Item3_1 = false;
                        KD02_Item01_Count++;
                        if (KD02_Item01_Count >= 1) this.Item01.GetComponent<Image>().sprite = this.KD02_XX;
                    }
                    else
                    {
                        Info.sprite = Info02_1;
                        Cur_Item = "KD02_Item01";
                        kd02_Item01 = true;
                        True1.SetActive(true);
                    }
                }
                else if ((!kd02_Item02 && kd02_Item03) || (kd02_Item02 && !kd02_Item03) || (kd02_Item02 && kd02_Item03))
                    Debug.Log("이미 아이템을 사용하셨습니다.");
                break;
            case "KD02_Item02":
                if (!kd02_Item01 && !kd02_Item03)
                {
                    if (Item1_3 || Item3_1)
                    {
                        Debug.Log(" 무적입니다. ");
                        Item1_3 = false;
                        Item3_1 = false;
                        KD02_Item02_Count++;
                        if (KD02_Item02_Count >= 5) this.Item02.GetComponent<Image>().sprite = this.KD02_XX;
                    }
                    else
                    {
                        Info.sprite = Info02_2;
                        Cur_Item = "KD02_Item02";
                        kd02_Item02 = true;
                        True2.SetActive(true);
                    }
                }
                else if ((!kd02_Item01 && kd02_Item03) || (kd02_Item01 && !kd02_Item03) || (kd02_Item01 && kd02_Item03))
                    Debug.Log("이미 아이템을 사용하셨습니다.");
                break;
            case "KD02_Item03":
                if (KD02_Item03_Count == 0)
                {
                    if (!kd02_Item01 && !kd02_Item02)
                    {
                        if (Item1_3 || Item3_1)
                        {
                            Debug.Log(" 무적입니다. ");
                            Item1_3 = false;
                            Item3_1 = false;
                            KD02_Item03_Count++;
                            if (KD02_Item03_Count >= 3) this.Item03.GetComponent<Image>().sprite = this.KD02_XX;
                        }
                        else
                        {
                            Info.sprite = Info02_3;
                            Cur_Item = "KD02_Item03";
                            kd02_Item03 = true;
                            True3.SetActive(true);
                        }
                    }
                    else if ((!kd02_Item01 && kd02_Item02) || (kd02_Item01 && !kd02_Item02) || (kd02_Item01 && kd02_Item02))
                        Debug.Log("이미 아이템을 사용하셨습니다.");
                }
                else
                {
                    int cool = PlayerPrefs.GetInt("KD02_03_cool");
                    if (game.Player01 == "KD02")
                    {
                        if (game.Player01_turn == cool + 3)
                        {
                            if (!kd02_Item01 && !kd02_Item02)
                            {
                                if (Item1_3 || Item3_1)
                                {
                                    Debug.Log(" 무적입니다. ");
                                    Item1_3 = false;
                                    Item3_1 = false;
                                    KD02_Item03_Count++;
                                    if (KD02_Item03_Count >= 3) this.Item03.GetComponent<Image>().sprite = this.KD02_XX;
                                }
                                else
                                {
                                    Info.sprite = Info02_3;
                                    Cur_Item = "KD02_Item03";
                                    kd02_Item03 = true;
                                    True3.SetActive(true);
                                }
                            }
                            else if ((!kd02_Item01 && kd02_Item02) || (kd02_Item01 && !kd02_Item02) || (kd02_Item01 && kd02_Item02))
                                Debug.Log("이미 아이템을 사용하셨습니다.");
                        }
                        else Debug.Log("쿨타임");
                    }
                    else if (game.Player02 == "KD01")
                    {
                        if (game.Player02_turn == cool + 3)
                        {
                            if (!kd02_Item01 && !kd02_Item02)
                            {
                                if (Item1_3 || Item3_1)
                                {
                                    Debug.Log(" 무적입니다. ");
                                    Item1_3 = false;
                                    Item3_1 = false;
                                    KD02_Item03_Count++;
                                    if (KD02_Item03_Count >= 3) this.Item03.GetComponent<Image>().sprite = this.KD02_XX;
                                }
                                else
                                {
                                    Info.sprite = Info02_3;
                                    Cur_Item = "KD02_Item03";
                                    kd02_Item03 = true;
                                    True3.SetActive(true);
                                }
                            }
                            else if ((!kd02_Item01 && kd02_Item02) || (kd02_Item01 && !kd02_Item02) || (kd02_Item01 && kd02_Item02))
                                Debug.Log("이미 아이템을 사용하셨습니다.");
                        }
                        else Debug.Log("쿨타임");
                    }
                }
                break;


            case "KD03_Item01":
                if (!kd03_Item02 && !kd03_Item03)
                {
                    if (Item1_3)
                    {
                        Debug.Log(" 무적입니다. ");
                        Item1_3 = false;
                        KD03_Item01_Count++;
                        if (KD03_Item01_Count >= 1) this.Item01.GetComponent<Image>().sprite = this.KD03_XX;
                    }
                    else
                    {
                        Info.sprite = Info03_1;
                        Cur_Item = "KD03_Item01";
                        kd03_Item01 = true;
                        True1.SetActive(true);
                    }
                }
                else if ((!kd03_Item02 && kd03_Item03) || (kd03_Item02 && !kd03_Item03) || (kd03_Item02 && kd03_Item03))
                    Debug.Log("이미 아이템을 사용하셨습니다.");
                break;
            case "KD03_Item02":
                if (KD03_Item02_Count == 0)
                {
                    if (!kd03_Item01 && !kd03_Item03)
                    {
                        if (Item1_3)
                        {
                            Debug.Log(" 무적입니다. ");
                            Item1_3 = false;
                            KD03_Item02_Count++;
                            if (KD03_Item02_Count >= 5) this.Item02.GetComponent<Image>().sprite = this.KD03_XX;
                        }
                        else
                        {
                            Info.sprite = Info03_2;
                            Cur_Item = "KD03_Item02";
                            kd03_Item02 = true;
                            True2.SetActive(true);
                        }
                    }
                    else if ((!kd03_Item01 && kd03_Item03) || (kd03_Item01 && !kd03_Item03) || (kd03_Item01 && kd03_Item03))
                        Debug.Log("이미 아이템을 사용하셨습니다.");
                }
                else
                {
                    int cool = PlayerPrefs.GetInt("KD03_02_cool");
                    if (game.Player01 == "KD02")
                    {
                        if (game.Player01_turn == cool + 4)
                        {
                            if (!kd03_Item01 && !kd03_Item03)
                            {
                                if (Item1_3)
                                {
                                    Debug.Log(" 무적입니다. ");
                                    Item1_3 = false;
                                    KD03_Item02_Count++;
                                    if (KD03_Item02_Count >= 5) this.Item02.GetComponent<Image>().sprite = this.KD03_XX;
                                }
                                else
                                {
                                    Info.sprite = Info03_2;
                                    Cur_Item = "KD03_Item02";
                                    kd03_Item02 = true;
                                    True2.SetActive(true);
                                }
                            }
                            else if ((!kd03_Item01 && kd03_Item03) || (kd03_Item01 && !kd03_Item03) || (kd03_Item01 && kd03_Item03))
                                Debug.Log("이미 아이템을 사용하셨습니다.");
                        }
                        else Debug.Log("쿨타임");
                    }
                    else if (game.Player02 == "KD03")
                    {
                        if (game.Player02_turn == cool + 4)
                        {
                            if (!kd03_Item01 && !kd03_Item03)
                            {
                                if (Item1_3)
                                {
                                    Debug.Log(" 무적입니다. ");
                                    Item1_3 = false;
                                    KD03_Item02_Count++;
                                    if (KD03_Item02_Count >= 5) this.Item02.GetComponent<Image>().sprite = this.KD03_XX;
                                }
                                else
                                {
                                    Info.sprite = Info03_2;
                                    Cur_Item = "KD03_Item02";
                                    kd03_Item02 = true;
                                    True2.SetActive(true);
                                }
                            }
                            else if ((!kd03_Item01 && kd03_Item03) || (kd03_Item01 && !kd03_Item03) || (kd03_Item01 && kd03_Item03))
                                Debug.Log("이미 아이템을 사용하셨습니다.");
                        }
                        else Debug.Log("쿨타임");
                    }
                }
                break;
            case "KD03_Item03":
                if (!kd03_Item01 && !kd03_Item02)
                {
                    if (Item1_3)
                    {
                        Debug.Log(" 무적입니다. ");
                        Item1_3 = false;
                        KD03_Item03_Count++;
                        if (KD03_Item03_Count >= 1) this.Item03.GetComponent<Image>().sprite = this.KD03_XX;
                    }
                    else
                    {
                        Info.sprite = Info03_3;
                        Cur_Item = "KD03_Item03";
                        kd03_Item03 = true;
                        True3.SetActive(true);
                    }
                }
                else if ((!kd03_Item01 && kd03_Item02) || (kd03_Item01 && !kd03_Item02) || (kd03_Item01 && kd03_Item02))
                    Debug.Log("이미 아이템을 사용하셨습니다.");
                break;


            case "KD04_Item01":
                if (!kd04_Item02 && !kd04_Item03)
                {
                    if (Item1_3 || Item3_1)
                    {
                        Debug.Log(" 무적입니다. ");
                        Item1_3 = false;
                        Item3_1 = false;
                        KD04_Item01_Count++;
                        if (KD04_Item01_Count >= 1) this.Item01.GetComponent<Image>().sprite = this.KD04_XX;
                    }
                    else
                    {
                        Info.sprite = Info04_1;
                        Cur_Item = "KD04_Item01";
                        kd04_Item01 = true;
                        True1.SetActive(true);
                    }
                }
                else if ((!kd04_Item02 && kd04_Item03) || (kd04_Item02 && !kd04_Item03) || (kd04_Item02 && kd04_Item03))
                    Debug.Log("이미 아이템을 사용하셨습니다.");
                break;
            case "KD04_Item02":
                if (!kd04_Item01 && !kd04_Item03)
                {
                    if (Item1_3 || Item3_1)
                    {
                        Debug.Log(" 무적입니다. ");
                        Item1_3 = false;
                        Item3_1 = false;
                        KD04_Item02_Count++;
                        if (KD04_Item02_Count >= 1) this.Item02.GetComponent<Image>().sprite = this.KD04_XX;
                    }
                    else
                    {
                        Info.sprite = Info04_2;
                        Cur_Item = "KD04_Item02";
                        kd04_Item02 = true;
                        True2.SetActive(true);
                    }
                }
                else if ((!kd04_Item01 && kd04_Item03) || (kd04_Item01 && !kd04_Item03) || (kd04_Item01 && kd04_Item03))
                    Debug.Log("이미 아이템을 사용하셨습니다.");
                break;
            case "KD04_Item03":
                if (!kd04_Item01 && !kd04_Item02)
                {
                    if (Item1_3 || Item3_1)
                    {
                        Debug.Log(" 무적입니다. ");
                        Item1_3 = false;
                        Item3_1 = false;
                        KD04_Item03_Count++;
                        if (KD04_Item03_Count >= 3) this.Item03.GetComponent<Image>().sprite = this.KD04_XX;
                    }
                    else
                    {
                        Info.sprite = Info04_3;
                        Cur_Item = "KD04_Item03";
                        kd04_Item03 = true;
                        True3.SetActive(true);
                    }
                }
                else if ((!kd04_Item01 && kd04_Item02) || (kd04_Item01 && !kd04_Item02) || (kd04_Item01 && kd04_Item02))
                    Debug.Log("이미 아이템을 사용하셨습니다.");
                break;
        }
    }
    public int Move_P = 0;
    public int Attack_P = 0;
    public int P_Turn = 0;
    public int knight_M = 0;
    public bool barricade = false;
    public int B_x, B_y;

    private List<Vector3> hitPositions = new List<Vector3>();
    private List<GameObject> hitObjects = new List<GameObject>();
    private const int maxHits = 2;
    private const float fixedZ = -2f;

    public void Apply_Item() // 아이템 적용
    {
        Image Info = info.GetComponent<Image>();
        Game game = controller.GetComponent<Game>();
        Chessman chessman = controller.GetComponent<Chessman>();
        switch (Cur_Item)
        {
            case "KD01_Item01":
                Move_P = 1;
                PlayerPrefs.SetInt("Move_P", Move_P);
                if (game.Player01 == "KD01")
                {
                    PlayerPrefs.SetInt("KD01_01_cool", game.Player01_turn);
                }
                else if (game.Player02 == "KD01")
                {
                    PlayerPrefs.SetInt("KD01_01_cool", game.Player02_turn);
                }
                KD01_Item01_Count++;
                if (KD01_Item01_Count >= 2) this.Item01.GetComponent<Image>().sprite = this.KD01_XX;
                kd01_Item01 = false;
                Info.sprite = UI;
                True1.SetActive(false);
                break;
            case "KD01_Item02":
                string C_P;
                string[] options = { "KD01_Pawn", "KD01_Knight", "KD01_Bishop", "KD01_Rook" };
                int randomIndex = UnityEngine.Random.Range(0, options.Length);
                C_P = options[randomIndex];

                if (game.CurPlayer == game.Player01)
                {
                    if (game.Player01_curHealth <= 40)
                    {
                        for (int i = 0; i <= 7; i++)
                        {
                            if (game.GetPosition(i, 0) == null)
                            {
                                if (game.Player01 == "KD01")
                                {
                                    game.Create(C_P, i, 0);
                                    game.SetPosition(game.Create(C_P, i, 0));
                                }
                                break;
                            }
                        }
                        KD01_Item02_Count++;
                        if (KD01_Item02_Count >= 1) this.Item02.GetComponent<Image>().sprite = this.KD01_XX;
                    }
                    else Debug.Log(" 추가할 자리가 없습니다. ");
                }
                else if (game.CurPlayer == game.Player02)
                {
                    if (game.Player02_curHealth <= 40)
                    {
                        for (int i = 0; i <= 7; i++)
                        {
                            if (game.GetPosition(i, 7) == null)
                            {
                                if (game.Player01 == "KD01")
                                {
                                    game.Create(C_P, i, 7);
                                    game.SetPosition(game.Create(C_P, i, 7));
                                }
                                break;
                            }
                        }
                        KD01_Item02_Count++;
                        if (KD01_Item02_Count >= 1) this.Item02.GetComponent<Image>().sprite = this.KD01_XX;
                    }
                    else Debug.Log(" 추가할 자리가 없습니다. ");
                }
                kd01_Item02 = false;
                Info.sprite = UI;
                True2.SetActive(false);
                break;
            case "KD01_Item03":
                Item1_3 = true;
                Debug.Log(" 활성화 되었습니다. ");
                KD01_Item03_Count++;
                if (KD01_Item03_Count >= 1) this.Item03.GetComponent<Image>().sprite = this.KD01_XX;
                kd01_Item03 = false;
                Info.sprite = UI;
                True3.SetActive(false);
                break;

            case "KD02_Item01":
                if (hit.collider != null)
                {
                    Destroy(hit.collider.gameObject);
                }
                KD02_Item01_Count++;
                if (KD02_Item01_Count >= 1) this.Item01.GetComponent<Image>().sprite = this.KD02_XX;
                kd02_Item01 = false;
                Info.sprite = UI;
                True1.SetActive(false);
                break;
            case "KD02_Item02":
                if (game.Player01 == "KD02")
                {
                    for (int i = 0; i <= 7; i++)
                    {
                        if (game.GetPosition(i, 0) == null)
                        {
                            if (game.Player01 == "KD02")
                            {
                                game.Create("KD02_Pawn", i, 0);
                                game.SetPosition(game.Create("KD02_Pawn", i, 0));
                            }
                            break;
                        }
                    }
                    Debug.Log("추가할 수 있는 자리가 없습니다. ");
                }
                else if (game.Player02 == "KD02")
                {
                    for (int i = 0; i <= 7; i++)
                    {
                        if (game.GetPosition(i, 7) == null)
                        {
                            if (game.Player02 == "KD02")
                            {
                                game.Create("KD02_Pawn", i, 7);
                                game.SetPosition(game.Create("KD02_Pawn", i, 7));
                            }
                            break;
                        }
                    }
                    Debug.Log("추가할 수 있는 자리가 없습니다. ");
                }
                KD02_Item02_Count++;
                if (KD02_Item02_Count >= 5) this.Item02.GetComponent<Image>().sprite = this.KD02_XX;
                kd02_Item02 = false;
                Info.sprite = UI;
                True2.SetActive(false);
                break;
            case "KD02_Item03":
                Attack_P = 5;
                PlayerPrefs.SetInt("Attack_P", 5);
                if (game.Player01 == "KD02")
                {
                    PlayerPrefs.SetInt("KD02_03_cool", game.Player01_turn);
                }
                else if (game.Player02 == "KD02")
                {
                    PlayerPrefs.SetInt("KD02_03_cool", game.Player02_turn);
                }
                KD02_Item03_Count++;
                if (KD02_Item03_Count >= 3) this.Item03.GetComponent<Image>().sprite = this.KD02_XX;
                kd02_Item03 = false;
                Info.sprite = UI;
                True3.SetActive(false);
                break;

            case "KD03_Item01":
                Item3_1 = true;
                Debug.Log(" 활성화 되었습니다. ");
                KD03_Item01_Count++;
                if (KD03_Item01_Count >= 1) this.Item01.GetComponent<Image>().sprite = this.KD03_XX;
                kd03_Item01 = false;
                Info.sprite = UI;
                True1.SetActive(false);
                break;

            case "KD03_Item02":
                do
                {
                    B_x = Random.Range(-1, 7);
                    B_y = Random.Range(1, 5);
                } while (game.GetPosition(B_x, B_y) != null);
                game.Create("Barricade", B_x, B_y);
                game.SetPosition(game.Create("Barricade", B_x, B_y));
                PlayerPrefs.SetInt("barricade", 1);
                if (game.Player01 == "KD03")
                {
                    PlayerPrefs.SetInt("KD03_02_cool", game.Player01_turn);
                }
                else if (game.Player02 == "KD03")
                {
                    PlayerPrefs.SetInt("KD03_02_cool", game.Player02_turn);
                }
                KD03_Item02_Count++;
                if (KD03_Item02_Count >= 5) this.Item02.GetComponent<Image>().sprite = this.KD03_XX;
                kd03_Item02 = false;
                Info.sprite = UI;
                True2.SetActive(false);
                break;
            case "KD03_Item03":
                if (game.Player01 == "KD03")
                {
                    if (game.Player01_curHealth <= 50) game.Player01_curHealth += 30;
                    else Debug.Log(" 체력이 충분합니다. ");
                    KD03_Item03_Count++;
                    if (KD03_Item03_Count >= 1) this.Item03.GetComponent<Image>().sprite = this.KD03_XX;
                }
                else if (game.Player02 == "KD03")
                {
                    if (game.Player02_curHealth <= 50) game.Player02_curHealth += 30;
                    else Debug.Log(" 체력이 충분합니다. ");
                    KD03_Item03_Count++;
                    if (KD03_Item03_Count >= 1) this.Item03.GetComponent<Image>().sprite = this.KD03_XX;
                }
                kd03_Item03 = false;
                Info.sprite = UI;
                True3.SetActive(false);
                break;


            case "KD04_Item01":
                if (hit.collider != null)
                {
                    hitPositions.Add(hit.point);
                    hitObjects.Add(hit.collider.gameObject);

                    Debug.Log($"Hit position: {hit.point}");

                    if (hitPositions.Count == maxHits) // 2번
                    {
                        SwapPositions();
                        KD04_Item01_Count++;

                        if (KD04_Item01_Count >= 1) this.Item01.GetComponent<Image>().sprite = this.KD04_XX;
                        kd04_Item01 = false;
                        Info.sprite = UI;
                        True1.SetActive(false);
                    }
                }
                break;
            case "KD04_Item02":
                PlayerPrefs.SetInt("P_Turn", 1);
                KD04_Item02_Count++;
                if (KD04_Item02_Count >= 1) this.Item02.GetComponent<Image>().sprite = this.KD04_XX;
                kd04_Item02 = false;
                Info.sprite = UI;
                True2.SetActive(false);
                break;
            case "KD04_Item03":
                knight_M = 1;
                PlayerPrefs.SetInt("knight_M", knight_M);
                KD04_Item03_Count++;
                if (KD04_Item03_Count >= 3) this.Item03.GetComponent<Image>().sprite = this.KD04_XX;
                kd04_Item03 = false;
                Info.sprite = UI;
                True3.SetActive(false);
                break;
        }
    }
    void SwapPositions()
    {
        // 위치 변경 로직
        for (int i = 0; i < maxHits; i++)
        {
            int nextIndex = (i + 1) % maxHits;

            Vector3 newPosition = new Vector3(hitPositions[nextIndex].x, hitPositions[nextIndex].y, fixedZ);
            hitObjects[i].transform.position = newPosition;

            Game game = controller.GetComponent<Game>();
            game.SetPosition(hitObjects[i]);
        }

        Debug.Log("Positions swapped");
    }
}
