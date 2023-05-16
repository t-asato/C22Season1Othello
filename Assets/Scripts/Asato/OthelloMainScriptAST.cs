using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OthelloMainScriptAST : MonoBehaviour
{
    public CSVreadScripASTtast boardCSV;
    public Sprite[] koma;
    public GameObject komaOBJ;
    SpriteRenderer komaSprite;

    void Start()
    {
        koma = Resources.LoadAll<Sprite>("Images/koma");

        komaSprite = komaOBJ.GetComponent<SpriteRenderer>();
        komaSprite.sprite = koma[0];

        Instantiate(
            komaOBJ,
            new Vector3(0, 0, 0),
            Quaternion.identity
            );

        boardUpdate();

        

    }

    void Update()
    {

    }
    void boardUpdate()
    {
        for (int y = 0; y <= 9; y++)
        {
            string CSVline = "";
            for (int x = 0; x <= 9; x++)
            {
                CSVline = CSVline + boardCSV.csvDatas[y][x] + ",";
            }
            Debug.Log(CSVline);
        }
    }
}
