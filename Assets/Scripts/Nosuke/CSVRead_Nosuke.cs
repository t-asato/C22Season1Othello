using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVRead_Nosuke : MonoBehaviour
{
    TextAsset csvFile;
    public List<string[]> csvDatas = new List<string[]>();
    // Start is called before the first frame update
    void Awake()
    {
        csvFile = Resources.Load("CSVs/ReadCSV_Nosuke") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); // ��s���ǂݍ���
            csvDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
        }
    }

}
