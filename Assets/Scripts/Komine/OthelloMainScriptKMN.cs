using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class OthelloMainScriptKMN : MonoBehaviour
{
    public CSVReadScriptKMN boardCSV;
    public Sprite[] koma;
    public GameObject komaOBJ;
    SpriteRenderer komaSprite;

    // Start is called before the first frame update
    void Start()
    {
        
        koma = Resources.LoadAll<Sprite>("Images/koma");
        komaSprite = komaOBJ.GetComponent<SpriteRenderer>();
        komaSprite.sprite = koma[0];
        //Instantiate(komaOBJ,new Vector3(0,0,0),Quaternion.identity);

        boardUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void boardUpdate()
    {
        for(int y=1; y<=8; y++)
        {
            string CSVline = ",";
            
            for(int x=1; x<=8; x++)
            {
                CSVline = CSVline + boardCSV.csvDatas[x][y]+",";
                komaSprite.sprite = koma[int.Parse(boardCSV.csvDatas[y][x])];

                Instantiate(komaOBJ, new Vector3((x * 0.7f)-3.15f,( y * 0.7f)-3.15f, 0), Quaternion.identity);
                //コマの画像が70ピクセルだから*0.7↑
            }
            Debug.Log(CSVline);
        }

    }
}
