using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScriptNat : MonoBehaviour
{
    float Counter;
    bool CountFlag = false;

    bool InputFlag;

    public int posx = 0;
    public int posy = 0;

    float minX = -2.8f;
    float maxX = 2.1f;

    float minY = -2.1f;
    float maxY = 2.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if(x + y != 0 && !CountFlag)
        {
            posx += (int)x;
            posx += (int)y;
            CursorMove(x,y);
        }

        if (CountFlag)
        {
            Counter += Time.deltaTime;
            if (Counter >= 0.1f)
            {
                CountFlag = false;
                Counter = 0;
            }
        }
    }

    void CursorMove(float x, float y)
    {
        CountFlag = true;
        transform.Translate(x*0.7f, y*0.7f, 0);
    }
}
