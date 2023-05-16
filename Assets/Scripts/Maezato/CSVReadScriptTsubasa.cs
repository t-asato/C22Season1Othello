using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReadScriptTsubasa : MonoBehaviour
{
    TextAsset csvFile;
    public List<string[]> csvDatas = new List<string[]>();

    private void Awake()
    {
        csvFile = Resources.Load("CSVs/OthelloCSVTsubasa") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }
        //boardUpdate();  
    }

    void Start()
    {
          
    }

    void Update()
    {
        
    }

}
