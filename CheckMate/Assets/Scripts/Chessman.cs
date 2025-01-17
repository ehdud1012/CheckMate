using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chessman : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;
    
    private int xBoard = -1;
    private int yBoard = -1;

    private string player;

    public Sprite KD01_Queen, KD01_Knight, KD01_Bishop, KD01_King, KD01_Rook, KD01_Pawn;
    public Sprite KD02_Queen, KD02_Knight, KD02_Bishop, KD02_King, KD02_Rook, KD02_Pawn;
    public Sprite KD03_Queen, KD03_Knight, KD03_Bishop, KD03_King, KD03_Rook, KD03_Pawn;
    public Sprite KD04_Queen, KD04_Knight, KD04_Bishop, KD04_King, KD04_Rook, KD04_Pawn;
    public Sprite Barricade;
    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        SetCoords();
        switch (this.name)
        {
            case "KD01_Queen": this.GetComponent<SpriteRenderer>().sprite = KD01_Queen; player = "KD01"; break;
            case "KD01_Knight": this.GetComponent<SpriteRenderer>().sprite = KD01_Knight; player = "KD01"; break;
            case "KD01_Bishop": this.GetComponent<SpriteRenderer>().sprite = KD01_Bishop; player = "KD01"; break;
            case "KD01_Rook": this.GetComponent<SpriteRenderer>().sprite = KD01_Rook; player = "KD01"; break;
            case "KD01_King": this.GetComponent<SpriteRenderer>().sprite = KD01_King; player = "KD01"; break;
            case "KD01_Pawn": this.GetComponent<SpriteRenderer>().sprite = KD01_Pawn; player = "KD01"; break;

            case "KD02_Queen": this.GetComponent<SpriteRenderer>().sprite = KD02_Queen; player = "KD02"; break;
            case "KD02_Knight": this.GetComponent<SpriteRenderer>().sprite = KD02_Knight; player = "KD02"; break;
            case "KD02_Bishop": this.GetComponent<SpriteRenderer>().sprite = KD02_Bishop; player = "KD02"; break;
            case "KD02_Rook": this.GetComponent<SpriteRenderer>().sprite = KD02_Rook; player = "KD02"; break;
            case "KD02_King": this.GetComponent<SpriteRenderer>().sprite = KD02_King; player = "KD02"; break;
            case "KD02_Pawn": this.GetComponent<SpriteRenderer>().sprite = KD02_Pawn; player = "KD02"; break;

            case "KD03_Queen": this.GetComponent<SpriteRenderer>().sprite = KD03_Queen; player = "KD03"; break;
            case "KD03_Knight": this.GetComponent<SpriteRenderer>().sprite = KD03_Knight; player = "KD03"; break;
            case "KD03_Bishop": this.GetComponent<SpriteRenderer>().sprite = KD03_Bishop; player = "KD03"; break;
            case "KD03_Rook": this.GetComponent<SpriteRenderer>().sprite = KD03_Rook; player = "KD03"; break;
            case "KD03_King": this.GetComponent<SpriteRenderer>().sprite = KD03_King; player = "KD03"; break;
            case "KD03_Pawn": this.GetComponent<SpriteRenderer>().sprite = KD03_Pawn; player = "KD03"; break;

            case "KD04_Queen": this.GetComponent<SpriteRenderer>().sprite = KD04_Queen; player = "KD04"; break;
            case "KD04_Knight": this.GetComponent<SpriteRenderer>().sprite = KD04_Knight; player = "KD04"; break;
            case "KD04_Bishop": this.GetComponent<SpriteRenderer>().sprite = KD04_Bishop; player = "KD04"; break;
            case "KD04_Rook": this.GetComponent<SpriteRenderer>().sprite = KD04_Rook; player = "KD04"; break;
            case "KD04_King": this.GetComponent<SpriteRenderer>().sprite = KD04_King; player = "KD04"; break;
            case "KD04_Pawn": this.GetComponent<SpriteRenderer>().sprite = KD04_Pawn; player = "KD04"; break;

            case "Barricade": this.GetComponent<SpriteRenderer>().sprite = Barricade; break;
        }
    }

    public void SetCoords()  // 보드 위치 설정
    {
        float x = xBoard;
        float y = yBoard;

        x *= 1.1f;
        y *= 1.1f;

        x += -7.45f;
        y += -3.85f;

        this.transform.position = new Vector3(x, y, -2.0f);
    }
    public int GetXBoard()
    {
        return xBoard;
    }
    public int GetYBoard()
    {
        return yBoard;
    }
    public void SetXBoard(int x)
    {
        xBoard = x;
    }
    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    public void OnMouseUp()
    {
        Item item = controller.GetComponent<Item>();

        if (!(item.kd01_Item01) && !(item.kd01_Item02) && !(item.kd01_Item03)
            && !(item.kd02_Item01) && !(item.kd02_Item02) && !(item.kd02_Item03)
            && !(item.kd03_Item01) && !(item.kd03_Item02) && !(item.kd03_Item03)
            && !(item.kd04_Item01) && !(item.kd04_Item02) && !(item.kd04_Item03))
        {
            if (controller.GetComponent<Game>().GetCurrentPlayer() == player)
            {
                DestroyMovePlates();
                InitiateMovePlates();
            }
        }
        else
        {
            item.Apply_Item();
        }
    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }
    public void InitiateMovePlates()
    {
        int knight_M = PlayerPrefs.GetInt("knight_M");
        switch (this.name)
        {
            case "KD01_Queen":
            case "KD02_Queen":
            case "KD03_Queen":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(1, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                LineMovePlate(-1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(1, -1);
                break;

            case "KD01_Knight":
            case "KD02_Knight":
            case "KD03_Knight":
            case "KD04_Knight":
                LMovePlate();
                break;

            case "KD01_Bishop":
            case "KD02_Bishop":
            case "KD03_Bishop":
                LineMovePlate(1, 1);
                LineMovePlate(1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(-1, -1);
                break;

            case "KD01_King":
            case "KD02_King":
            case "KD03_King":
                SurroundMovePlate();
                break;

            case "KD01_Rook":
            case "KD02_Rook":
            case "KD03_Rook":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                break;

            case "KD04_King":
            case "KD04_Queen":
            case "KD04_Bishop":
            case "KD04_Rook":
                if(knight_M == 1)
                {
                    LMovePlate();
                }
                else
                {
                    switch (this.name)
                    {
                        case "KD04_Queen":
                            LineMovePlate(1, 0);
                            LineMovePlate(0, 1);
                            LineMovePlate(1, 1);
                            LineMovePlate(-1, 0);
                            LineMovePlate(0, -1);
                            LineMovePlate(-1, -1);
                            LineMovePlate(-1, 1);
                            LineMovePlate(1, -1);
                            break;
                        case "KD04_Knight":
                            LMovePlate();
                            break;
                        case "KD04_Bishop":
                            LineMovePlate(1, 1);
                            LineMovePlate(1, -1);
                            LineMovePlate(-1, 1);
                            LineMovePlate(-1, -1);
                            break;
                        case "KD04_King":
                            SurroundMovePlate();
                            break;
                        case "KD04_Rook":
                            LineMovePlate(1, 0);
                            LineMovePlate(0, 1);
                            LineMovePlate(-1, 0);
                            LineMovePlate(0, -1);
                            break;
                    }
                }
                PlayerPrefs.SetInt("knight_M", 0);
                break;
        }
        Item item = controller.GetComponent<Item>();
        int move_p = PlayerPrefs.GetInt("Move_P");
        switch (PlayerPrefs.GetString("player01"))
        {
            case "KD01":
            case "KD02":
            case "KD03":
            
                PawnMovePlate(xBoard, yBoard + 1);
                if (move_p != 0)
                {
                    PawnMovePlate(xBoard, yBoard + 1 + move_p);
                }
                break;
            case "KD04":
                if (knight_M == 1)
                {
                    LMovePlate();
                }
                else
                {
                    PawnMovePlate(xBoard, yBoard + 1);
                    if (move_p != 0)
                    {
                        PawnMovePlate(xBoard, yBoard + 1 + move_p);
                    }
                }
                PlayerPrefs.SetInt("knight_M", 0);
                break;

        }
        switch (PlayerPrefs.GetString("player02"))
        {
            case "KD01":
            case "KD02":
            case "KD03":
                PawnMovePlate(xBoard, yBoard - 1);
                if (move_p != 0)
                {
                    PawnMovePlate(xBoard, yBoard - 1 - move_p);
                }
                break;
            case "KD04":
                if (knight_M == 1)
                {
                    LMovePlate();
                }
                else
                {
                    PawnMovePlate(xBoard, yBoard - 1);
                    if (move_p != 0)
                    {
                        PawnMovePlate(xBoard, yBoard - 1 - move_p);
                    }
                }
                PlayerPrefs.SetInt("knight_M", 0);
                break;
        }
        

    }
    public void LineMovePlate(int xInc, int yInc)
    {
        Game sc = controller.GetComponent<Game>();
        int x = xBoard + xInc;
        int y = yBoard + yInc;

        while (sc.PositionOnBoard(x,y) && sc.GetPosition(x,y) == null)
        {
            MovePlateSpawn(x, y);
            x += xInc;
            y += yInc;
        }
        if (sc.PositionOnBoard(x,y) && sc.GetPosition(x,y).GetComponent<Chessman>().player != player)
        {
            MovePlateAttackSpawn(x, y);
        }
    }
    public void LMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard - 1);
    }
    public void SurroundMovePlate()
    {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 0);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard + 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 0);
        PointMovePlate(xBoard + 1, yBoard + 1);
    }
    public void PointMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        
        if (sc.PositionOnBoard(x, y))
        {
            GameObject cp = sc.GetPosition(x, y);
            if (cp == null)
            {
                MovePlateSpawn(x, y);
            }
            else if ( cp.GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }
    public void PawnMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();

        if (sc.PositionOnBoard(x, y))
        {
            if (sc.GetPosition(x,y) == null)
            {
                MovePlateSpawn(x, y);
            }
            if (sc.PositionOnBoard(x + 1, y) && sc.GetPosition(x + 1, y) != null 
                        && sc.GetPosition(x + 1, y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x + 1, y);
            }
            if (sc.PositionOnBoard(x - 1, y) && sc.GetPosition(x - 1, y) != null
                        && sc.GetPosition(x - 1, y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x - 1, y);
            }
        }
    }
    public void MovePlateSpawn(int moveX, int moveY)
    {
        float x = moveX;
        float y = moveY;

        x *= 1.1f;
        y *= 1.1f;

        x += -7.45f;
        y += -3.85f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);
        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(moveX, moveY);
    } 
    public void MovePlateAttackSpawn(int moveX, int moveY)
    {
        float x = moveX;
        float y = moveY;

        x *= 1.1f;
        y *= 1.1f;

        x += -7.45f;
        y += -3.85f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);
        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(moveX, moveY);
    }

}