using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReadScriptNAT : MonoBehaviour
{
    TextAsset CSVs;
    public List<string[]> csvDatas = new List<string[]>(); // CSV�̒��g�����郊�X�g;   

    private void Awake()
    {
        CSVs = Resources.Load("CSVs/othelloCSV.NAT") as TextAsset;
        StringReader reader = new StringReader(CSVs.text);

        // , �ŕ�������s���ǂݍ���
        // ���X�g�ɒǉ����Ă���
        while (reader.Peek() != -1) // reader.Peaek��-1�ɂȂ�܂�
        {
            string line = reader.ReadLine(); // ��s���ǂݍ���
            csvDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
        }

        // csvDatas[�s][��]���w�肵�Ēl�����R�Ɏ��o����
        //Debug.Log(csvDatas[4][5]);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
