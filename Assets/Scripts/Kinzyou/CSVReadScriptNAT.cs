using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReadScriptNAT : MonoBehaviour
{
    TextAsset CSVs;
    public List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト;   

    private void Awake()
    {
        CSVs = Resources.Load("CSVs/othelloCSV.NAT") as TextAsset;
        StringReader reader = new StringReader(CSVs.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }

        // csvDatas[行][列]を指定して値を自由に取り出せる
        //Debug.Log(csvDatas[4][5]);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
