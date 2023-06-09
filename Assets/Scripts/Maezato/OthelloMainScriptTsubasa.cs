using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OthelloMainScriptTsubasa : MonoBehaviour
{
    public CSVReadScriptTsubasa boardCSV; 

    public Sprite[] koma;
    public GameObject komaOBJ;
    SpriteRenderer komaSprite;

    void Start()
    {   
        koma = Resources.LoadAll<Sprite>("Images/koma");

        komaSprite = komaOBJ.GetComponent<SpriteRenderer>();
        komaSprite.sprite = koma[0];

        boardUpdate();
    }

    void Update()
    {
        
    }

    
    void boardUpdate()
    {
        for(int y = 1; y<=8; y++)
        {
            string CSVline = "";
            for(int x = 1; x<=8; x++)
            {
                CSVline = CSVline + boardCSV.csvDatas[y][x]+",";
                komaSprite.sprite = koma[int.Parse(boardCSV.csvDatas[y][x])];

                Instantiate(komaOBJ, new Vector3((x * 0.7f)-3.5f, (y * -0.7f)+3.5f, 0), Quaternion.identity);

            }           
            Debug.Log(CSVline);
        } 
    }
}
