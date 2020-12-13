using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public Slot[] slots;

    public bool CanUse()
    {
        bool can = false;
        for (int i=0; i<isFull.Length;i++)
        {
            if (isFull[i])
            {
                can = true;
                break;
            }
        }
        return can;
    }
    public int LastSlot()//возможно здесь будет ошибка, проверить!!!
    {
        int last = 0;
        for (int i = 0; i < isFull.Length; i++)
        {
            if (isFull[i])
            {
                last = i;
                
            }
        }
        return last;
    }
}
