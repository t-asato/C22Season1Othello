using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVreadScripASTtast : MonoBehaviour
{
    TextAsset csvFile;
    public List<string[]> csvDatas = new List<string[]>();


    void Awake()
    {
        csvFile = Resources.Load("CSVs/OthelloCSVast") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }
    }
}
