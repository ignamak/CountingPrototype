using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour
{
    enum CylinderState { REST, M_UP, M_DOWN, M_LEFT, M_RIGHT, P_RIGHT, P_LEFT, P_UP, P_DOWN, M_BACK}

    CylinderState cylinderState = CylinderState.REST;

    const float yz_Max = 0.5f;
    const float yz_Min = -0.5f;

    public Transform cylinderTransform;

    public int stickSpeed;

    Vector3 restPosition;


    // Start is called before the first frame update
    void Start()
    {
        restPosition = cylinderTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (cylinderState != CylinderState.P_LEFT && cylinderState == CylinderState.REST || cylinderState == CylinderState.M_BACK || cylinderState == CylinderState.M_LEFT)
            {
                cylinderState = CylinderState.M_LEFT;
                MoveStick(cylinderState);
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (cylinderState != CylinderState.P_RIGHT && cylinderState == CylinderState.REST || cylinderState == CylinderState.M_BACK || cylinderState == CylinderState.M_RIGHT)
            {
                cylinderState = CylinderState.M_RIGHT;
                MoveStick(cylinderState);
            }
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (cylinderState != CylinderState.P_UP && cylinderState == CylinderState.REST || cylinderState == CylinderState.M_BACK || cylinderState == CylinderState.M_UP)
            {
                cylinderState = CylinderState.M_UP;
                MoveStick(cylinderState);
            }
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (cylinderState != CylinderState.P_DOWN && cylinderState == CylinderState.REST || cylinderState == CylinderState.M_BACK || cylinderState == CylinderState.M_DOWN)
            {
                cylinderState = CylinderState.M_DOWN;
                MoveStick(cylinderState);
            }
        }

        else if (!Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (cylinderState != CylinderState.REST)
            {
                cylinderState = CylinderState.M_BACK;
                MoveStick(cylinderState);
            }
        }
    }

    private void MoveStick(CylinderState state) 
    {
        switch (state)
        {
            case CylinderState.M_UP:
                Vector3 upPos = new Vector3(restPosition.x, restPosition.y + 0.5f, restPosition.z);
                cylinderTransform.position = Vector3.MoveTowards(cylinderTransform.position, upPos, stickSpeed * Time.deltaTime);

                if (Vector3.Distance(cylinderTransform.position, upPos) < 0.005f)
                {
                    cylinderTransform.position = upPos;
                    cylinderState = CylinderState.P_UP;
                }

                break;
            case CylinderState.M_DOWN:
                Vector3 downPos = new Vector3(restPosition.x, restPosition.y - 0.5f, restPosition.z);
                cylinderTransform.position = Vector3.MoveTowards(cylinderTransform.position, downPos, stickSpeed * Time.deltaTime);

                if (Vector3.Distance(cylinderTransform.position, downPos) < 0.005f)
                {
                    cylinderTransform.position = downPos;
                    cylinderState = CylinderState.P_DOWN;
                }

                break;
            case CylinderState.M_LEFT:
                Vector3 leftPos = new Vector3(restPosition.x, restPosition.y , restPosition.z - 0.5f);
                cylinderTransform.position = Vector3.MoveTowards(cylinderTransform.position, leftPos, stickSpeed * Time.deltaTime);

                if (Vector3.Distance(cylinderTransform.position, leftPos) < 0.005f)
                {
                    cylinderTransform.position = leftPos;
                    cylinderState = CylinderState.P_LEFT;
                }

                break;
            case CylinderState.M_RIGHT:
                Vector3 rightPos = new Vector3(restPosition.x, restPosition.y, restPosition.z + 0.5f);
                cylinderTransform.position = Vector3.MoveTowards(cylinderTransform.position, rightPos, stickSpeed * Time.deltaTime);

                if (Vector3.Distance(cylinderTransform.position, rightPos) < 0.005f)
                {
                    cylinderTransform.position = rightPos;
                    cylinderState = CylinderState.P_RIGHT;
                }

                break;
            case CylinderState.M_BACK:
                cylinderTransform.position = Vector3.MoveTowards(cylinderTransform.position, restPosition, stickSpeed * Time.deltaTime);

                if (Vector3.Distance(cylinderTransform.position, restPosition) < 0.005f)
                {
                    cylinderTransform.position = restPosition;
                    cylinderState = CylinderState.REST;
                }

                break;
            default:
                break;
        }
    }

}
