using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OthelloScriptNat : MonoBehaviour
{
    public CSVReadScriptNAT boardCSV;
    public Sprite[] koma;
    public GameObject komaOBJ;
    SpriteRenderer komasprite;

    

    // Start is called before the first frame update
    void Start()
    {
        koma = Resources.LoadAll<Sprite>("Images/koma");

        komasprite = komaOBJ.GetComponent<SpriteRenderer>();
        komasprite.sprite = koma[0];

        boardUpdeta();
    }

    void boardUpdeta()
    {
        for (int y = 1; y <= 8; y++)
        {
            string CSVlins = "";
            for (int x = 1; x < 9; x++)
            {
                CSVlins = CSVlins + boardCSV.csvDatas[y][x] + ",";
                komasprite.sprite = koma[int.Parse(boardCSV.csvDatas[y][x])];

                Instantiate(komaOBJ, new Vector3((x * 0.7f)-3.5f,(y * -0.7f)+3.5f,0), Quaternion.identity);
            }

            Debug.Log(CSVlins);
        }
    }
}
