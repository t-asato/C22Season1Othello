using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class CSVReadScriptKMN : MonoBehaviour
{
    
    public List<string[]> csvDatas = new List<string[]>();
    
    TextAsset csvFile;
private void Awake()
{
    csvFile = Resources.Load("CSVs/OthelloCSVKMN") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }

        // csvDatas[行][列]を指定して値を自由に取り出せる
        //Debug.Log(csvDatas[y][x]);
        
        /* 
        for(int y=0; y<=9; y++)
        {
            string CSVline = ",";
            
            for(int x=0; x<=9; x++)
            {
                CSVline = CSVline + csvDatas[x][y]+",";
            }
            Debug.Log(CSVline);
        }
        */
}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
