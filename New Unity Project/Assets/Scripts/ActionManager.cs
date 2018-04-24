using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ActionManager
{
    void StartThrow(Queue<GameObject> diskQueue);
    int getDiskNumber();
    void setDiskNumber(int num);
}