using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCount : MonoBehaviour
{
    //code ref : https://stackoverflow.com/questions/40993722/get-number-of-children-a-game-object-has-via-script
    private int childs;
    void Start()
    {



    }
    public int getChildren(GameObject obj)
    {
        int count = 0;

        for (int i = 0; i < obj.transform.childCount; i++)
        {
            count++;
            counter(obj.transform.GetChild(i).gameObject, ref count);
        }
        return count;
    }

    private void counter(GameObject currentObj, ref int count)
    {
        for (int i = 0; i < currentObj.transform.childCount; i++)
        {
            count++;
            counter(currentObj.transform.GetChild(i).gameObject, ref count);
        }
    }
    public int GetChildsNumber()
    {
        childs = getChildren(gameObject);
        return childs;
    }
}
