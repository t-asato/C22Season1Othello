using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    float counter = 0;
    bool countFlag = false;

    public float posX = 0;
    public float posY = 0;
    void Start()
    {

    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = -1 * Input.GetAxisRaw("Vertical");

        Debug.Log(posX + ":" + posY);

        if (inputX + inputY != 0 && !countFlag)
        {
            posX += inputX;
            posY += inputY;

            posX = Mathf.Clamp(posX, 0, 7);
            posY = Mathf.Clamp(posY, 0, 7);

            CursorMove(posX, posY);
        }

        if (countFlag)
        {
            counter += Time.deltaTime;
            if (counter > 0.1f)
            {
                countFlag = false;
                counter = 0;
            }
        }
    }

    void CursorMove(float inputX, float inputY)
    {
        countFlag = true;
        transform.position
        = new Vector3((inputX * 0.7f) - 4.9f, (inputY * -0.7f) + 2.3f, -1);

    }



}
