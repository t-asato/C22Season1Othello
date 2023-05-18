using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OthelloMainScriptAST : MonoBehaviour
{
    public CSVreadScripASTtast boardCSV;
    public Sprite[] koma;
    public GameObject komaOBJ;
    SpriteRenderer komaSprite;

    public Transform BoradParent;

    public CursorScript CursorScript;

    int CursorX;
    int CursorY;
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
            CursorX = (int)CursorScript.posX + 1;
            CursorY = (int)CursorScript.posY + 1;
            komaPut();
        }


    }
    void boardUpdate()
    {
        foreach (Transform borad in BoradParent)
        {
            GameObject.Destroy(borad.gameObject);
        }

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
                    , BoradParent
                    );
            }
            //Debug.Log(CSVline);
        }
    }
    void komaPut()
    {
        if (boardCSV.csvDatas[CursorY][CursorX] == "0")
        {
            //boardCSV.csvDatas[CursorY][CursorX] = "1";
            komaCheck();
        }
        boardUpdate();
    }

    void komaCheck()
    {


        for (int checkY = -1; checkY <= 1; checkY++)
        {
            for (int checkX = -1; checkX <= 1; checkX++)
            {
                if (boardCSV.csvDatas[CursorY + checkY][CursorX + checkX] == "2")
                {
                    //Debug.Log("ok");
                    int loopX = CursorX + checkX;
                    int loopY = CursorY + checkY;
                    while (boardCSV.csvDatas[loopY][loopX] == "2")
                    {
                        loopX += checkX;
                        loopY += checkY;
                    }
                    if (boardCSV.csvDatas[loopY][loopX] == "1")
                    {
                        Debug.Log("ok");
                    }
                }
                /*else
                {
                    Debug.Log(CursorX + ":" + CursorX + "=" + boardCSV.csvDatas[CursorY + checkY][CursorX + checkX] + "not");
                }*/

            }
        }


    }




}
