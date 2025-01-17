using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;
    GameObject reference = null;

    int moveX;
    int moveY;

    public bool attack = false; //이동 true는 공격

    public void Start()
    {
        if (attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0f, 0f, 1.0f); // 빨강
        }
    }
    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if (attack)   //공격
        {
            GameObject cp = controller.GetComponent<Game>().GetPosition(moveX, moveY);

            HandleSpriteAction(cp);
            controller.GetComponent<Game>().HP_Dec();
            Destroy(cp);
        }
        controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<Chessman>().GetXBoard(), reference.GetComponent<Chessman>().GetYBoard());
        
        reference.GetComponent<Chessman>().SetXBoard(moveX);
        reference.GetComponent<Chessman>().SetYBoard(moveY);
        reference.GetComponent<Chessman>().SetCoords();

        controller.GetComponent<Game>().SetPosition(reference);

        if (PlayerPrefs.GetInt("P_Turn") == 0)
        {
            controller.GetComponent<Game>().NextTurn();
        }
        else PlayerPrefs.SetInt("P_Turn", 0);
        reference.GetComponent<Chessman>().DestroyMovePlates();
    }
    public void SetCoords(int x, int y)
    {
        moveX = x;
        moveY = y;
    }
    public void SetReference(GameObject obj)
    {
        reference = obj;
    }
    public GameObject GetReference()
    {
        return reference;
    }

    void HandleSpriteAction(GameObject hitObject)
    {
        SpriteRenderer spriteRenderer = hitObject.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            string spriteName = spriteRenderer.sprite.name;
            Attack_chessPiece(spriteName);
        }
    }

    void Attack_chessPiece(string spriteName)
    {
        string ChessPiece = "";

        switch (spriteName)
        {
            case "KD01_Queen":
            case "KD02_Queen":
            case "KD03_Queen":
            case "KD04_Queen":
                ChessPiece = "Queen";
                PlayerPrefs.SetString("ChessPiece", ChessPiece);
                break;

            case "KD01_Knight":
            case "KD02_Knight":
            case "KD03_Knight":
            case "KD04_Knight":
                ChessPiece = "Knight";
                PlayerPrefs.SetString("ChessPiece", ChessPiece);
                break;

            case "KD01_Bishop":
            case "KD02_Bishop":
            case "KD03_Bishop":
            case "KD04_Bishop":
                ChessPiece = "Bishop";
                PlayerPrefs.SetString("ChessPiece", ChessPiece);
                break;

            case "KD01_King":
            case "KD02_King":
            case "KD03_King":
            case "KD04_King":
                ChessPiece = "King";
                PlayerPrefs.SetString("ChessPiece", ChessPiece);
                break;

            case "KD01_Rook":
            case "KD02_Rook":
            case "KD03_Rook":
            case "KD04_Rook":
                ChessPiece = "Rook";
                PlayerPrefs.SetString("ChessPiece", ChessPiece);
                break;

            case "KD01_Pawn":
            case "KD02_Pawn":
            case "KD03_Pawn":
            case "KD04_Pawn":
                ChessPiece = "Pawn";
                PlayerPrefs.SetString("ChessPiece", ChessPiece);
                break;
        }
    }
}
