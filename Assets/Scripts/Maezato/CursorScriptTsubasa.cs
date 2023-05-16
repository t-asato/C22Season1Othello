using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScriptTsubasa : MonoBehaviour
{
    float count;
    bool countFlag = false;

    float minX = -2.8f;
    float maxX = 2.1f;

    float minY = -2.1f;
    float maxY = 2.8f;
    void Start()
    {
        
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        var pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

        if (x+y != 0 && !countFlag)
        {
            CoursorMove(x,y);
        }

        if (countFlag)
        {
            count += Time.deltaTime;
            if (count >= 0.1)
            {
                countFlag = false;
                count = 0;
            }
        }
    }
    void CoursorMove(float x,float y)
    {
        countFlag = true;
        transform.Translate(x * 0.7f, y * 0.7f, 0);
    }
}
