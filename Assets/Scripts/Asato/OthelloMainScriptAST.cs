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

    int turn = 0;

    float wait = 0;

    int[][] score =
{
            //new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            new int[] {9, 1, 4, 3, 3, 4, 1, 9},
            new int[] {1, 2, 2, 2, 2, 2, 2, 1},
            new int[] {4, 2, 4, 3, 3, 4, 2, 4},
            new int[] {3, 2, 3, 0, 0, 2, 3, 3},
            new int[] {3, 2, 3, 0, 0, 2, 3, 3},
            new int[] {4, 2, 4, 3, 3, 4, 2, 4},
            new int[] {1, 0, 2, 2, 2, 2, 0, 1},
            new int[] {9, 1, 4, 3, 3, 4, 1, 9}
            //new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

        };

    void Start()
    {


        koma = Resources.LoadAll<Sprite>("Images/koma2");

        komaSprite = komaOBJ.GetComponent<SpriteRenderer>();
        komaSprite.sprite = koma[2];

        boardUpdate();
    }

    void Update()
    {
        wait += Time.deltaTime;
        //Debug.Log(wait);
        if (Input.GetButtonDown("Jump") && turn == 0)
        {
            Debug.Log("PC");
            CursorX = (int)CursorScript.posX + 1;
            CursorY = (int)CursorScript.posY + 1;
            komaPut();
            wait = 0;
        }
        if (turn == 1 && wait > 1)
        {//CPU
            //Debug.Log("CPU");
            //Invoke("CPUkomaCheck", 1f);
            CPUkomaCheck();
            wait = 0;
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
        }

    }
    void komaPut()
    {
        if (boardCSV.csvDatas[CursorY][CursorX] == "2")
        {
            komaCheck();
        }
    }

    void komaCheck()
    {
        bool puted = false;
        for (int checkY = -1; checkY <= 1; checkY++)
        {
            for (int checkX = -1; checkX <= 1; checkX++)
            {
                if (boardCSV.csvDatas[CursorY + checkY][CursorX + checkX] == 1 - turn + "")
                {
                    int loopX = CursorX + checkX;
                    int loopY = CursorY + checkY;
                    int i = 0;
                    while (boardCSV.csvDatas[loopY][loopX] == 1 - turn + "")
                    {
                        i++; if (i > 100) break;
                        loopX += checkX;
                        loopY += checkY;
                    }
                    if (boardCSV.csvDatas[loopY][loopX] == turn + "")
                    {
                        puted = true;
                        loopX = CursorX + checkX;
                        loopY = CursorY + checkY;
                        boardCSV.csvDatas[CursorY][CursorX] = turn + "";
                        i = 0;
                        while (boardCSV.csvDatas[loopY][loopX] == 1 - turn + "")
                        {
                            i++; if (i > 100) break;
                            boardCSV.csvDatas[loopY][loopX] = turn + "";
                            loopX += checkX;
                            loopY += checkY;
                        }
                    }
                }
            }
        }
        if (puted)
        {
            turn = 1 - turn;
            boardUpdate();
        }

    }
    void CPUkomaCheck()//CPUが黒=turn=1
    {
        bool puted = false;
        int komaScore = 0;
        int scoreX = 1;
        int scoreY = 1;
        for (int cpuY = 1; cpuY <= 8; cpuY++)
        {
            for (int cpuX = 1; cpuX <= 8; cpuX++)
            {
                if (boardCSV.csvDatas[cpuY][cpuX] == "2")
                {



                    for (int y = -1; y <= 1; y++)/////////////////////////////////////////8way
                    {
                        for (int x = -1; x <= 1; x++)
                        {
                            if (boardCSV.csvDatas[cpuY + y][cpuX + x] == 1 - turn + "")
                            {
                                int loopX = cpuX + x;
                                int loopY = cpuY + y;
                                int i = 0;
                                while (boardCSV.csvDatas[loopY][loopX] == 1 - turn + "")
                                {
                                    i++; if (i > 100) break;
                                    loopX += x;
                                    loopY += y;
                                }
                                if (boardCSV.csvDatas[loopY][loopX] == turn + "")
                                {
                                    puted = true;

                                    if (komaScore < score[cpuY - 1][cpuX - 1])
                                    {
                                        komaScore = score[cpuY - 1][cpuX - 1];
                                        scoreX = cpuX;//PCカーソル的には+１必要
                                        scoreY = cpuY;
                                        //Debug.Log("put_ok" + scoreX + "," + scoreY + ":" + komaScore);

                                    }
                                }
                            }
                        }
                    }/////////////////////////////////////////////////////////////////////////
                }
            }
        }
        //Debug.Log(puted);
        if (puted)
        {
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    int loopX = scoreX + x;
                    int loopY = scoreY + y;
                    int i = 0;
                    while (boardCSV.csvDatas[loopY][loopX] == 1 - turn + "")
                    {
                        i++; if (i > 100) break;
                        loopX += x;
                        loopY += y;
                    }

                    if (boardCSV.csvDatas[loopY][loopX] == turn + "")
                    {
                        i = 0;
                        loopX = scoreX + x;
                        loopY = scoreY + y;
                        while (boardCSV.csvDatas[loopY][loopX] == 1 - turn + "")
                        {
                            i++; if (i > 100) break;
                            boardCSV.csvDatas[loopY][loopX] = turn + "";
                            loopX += x;
                            loopY += y;
                        }
                        boardCSV.csvDatas[scoreY][scoreX] = turn + "";
                    }
                }
            }
            turn = 1 - turn;
            boardUpdate();
        }
    }
}
