using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OthelloMainScript_Nosuke : MonoBehaviour
{
    public CSVRead_Nosuke csvreaderNosuke;
    public Sprite[] koma;

    public GameObject komaObj;
    SpriteRenderer komaSprite;

    public CursorScript_Nos cursorScript;
    void Start()
    {
        koma = Resources.LoadAll<Sprite>("Images/koma");
        komaSprite = komaObj.GetComponent<SpriteRenderer>();

        boardUpdate();
    }
    void boardUpdate()
    {
        for(int y = 1; y <= 8; y++)
        {
            string CSVline = "";
            for (int x = 1; x <= 8; x++)
            {
                CSVline = CSVline + csvreaderNosuke.csvDatas[y][x] + ",";
                komaSprite.sprite = koma[int.Parse(csvreaderNosuke.csvDatas[y][x])];
                Instantiate(komaObj, new Vector3(-2.8f + x * 0.7f, 2.8f + y * -0.7f, 0), Quaternion.identity);
            }
            Debug.Log(CSVline);

            // int.Parse(csvreaderNosuke.csvDatas[y][x])
        }
    }
}


