using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript_Nos : MonoBehaviour
{
    float counter;

    bool countflag = false;

    public int posX;

    public int posY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        float y = Input.GetAxisRaw("Vertical");

        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -2.1f, 2.8f);

        pos.y = Mathf.Clamp(pos.y, -2.8f, 2.1f);

        transform.position = pos;
        if(x + y != 0 && !countflag)
        {
            CursorMove(x,y);
        }
        if (countflag)
        {
            counter += Time.deltaTime;
            if(counter >= 0.1)
            {
                countflag = false;
                counter = 0;
            }
        }
    }

    void CursorMove(float x, float y)
    {
        countflag = true;
        transform.Translate(x * 0.7f, y * 0.7f, 0);
    }
}
