using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OthelloMainScriptAST : MonoBehaviour
{
    public CSVreadScripASTtast boardCSV;
    public Sprite[] koma;
    public GameObject komaOBJ;
    SpriteRenderer komaSprite;

    public CursorScript CursorScript;

    void Start()
    {
        koma = Resources.LoadAll<Sprite>("Images/koma");

        komaSprite = komaOBJ.GetComponent<SpriteRenderer>();
        komaSprite.sprite = koma[0];

        boardUpdate();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            komaPut();
        }


    }
    void boardUpdate()
    {
        for (int y = 1; y <= 8; y++)
        {
            string CSVline = "";
            for (int x = 1; x <= 8; x++)
            {
                CSVline = CSVline + boardCSV.csvDatas[y][x] + ",";
                komaSprite.sprite = koma[int.Parse(boardCSV.csvDatas[y][x])];

                Instantiate(
                    komaOBJ,
                    new Vector3((x * 0.7f) - 5.6f, (y * -0.7f) + 3f, 0),
                    Quaternion.identity
                    );
            }
            //Debug.Log(CSVline);
        }
    }
    void komaPut()
    {
        int CursorX = (int)CursorScript.posX + 1;
        int CursorY = (int)CursorScript.posY + 1;

        if (boardCSV.csvDatas[CursorY][CursorX] == "0")
        {
            //boardCSV.csvDatas[CursorY][CursorX] = "1";
            komaCheck();
        }
        boardUpdate();
    }

    void komaCheck()
    {



    }




}
