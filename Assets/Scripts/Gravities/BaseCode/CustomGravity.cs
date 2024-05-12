using UnityEngine;
using System.Collections.Generic;

public static class CustomGravity
{
    static List<List<GravitySource>> sourcesListList = new List<List<GravitySource>>();

    public static Vector3 GetGravity(Vector3 position, int listIndex)
    {
        Vector3 g = Vector3.zero;
        for (int i = 0; i < sourcesListList[listIndex].Count; i++)
        {
            g += sourcesListList[listIndex][i].GetGravity(position);
        }
        return g;
    }

    public static Vector3 GetGravity(Vector3 position, out Vector3 upAxis, int listIndex)
    {
        Vector3 g = Vector3.zero;
        for (int i = 0; i < sourcesListList[listIndex].Count; i++)
        {
            g += sourcesListList[listIndex][i].GetGravity(position);
        }
        upAxis = -g.normalized;
        return g;
    }

    public static Vector3 GetUpAxis(Vector3 position, int listIndex)
    {
        Vector3 g = Vector3.zero;
        for (int i = 0; i < sourcesListList[listIndex].Count; i++)
        {
            g += sourcesListList[listIndex][i].GetGravity(position);
        }
        return -g.normalized;
    }

    public static void Register(GravitySource source, int listIndex)
    {
        /*if(!(sourcesListList.Count > listIndex))
        {
            sourcesListList.Add(new List<GravitySource>());
        }*/

        int neededLists = (listIndex + 1) - sourcesListList.Count;

        while (neededLists > 0) 
        {
            sourcesListList.Add(new List<GravitySource>());
            neededLists--;
        }

        Debug.Assert(!sourcesListList[listIndex].Contains(source),"Duplicate registration of gravity source!", source);

        sourcesListList[listIndex].Add(source);
    }

    public static void Unregister(GravitySource source, int listIndex)
    {
        Debug.Assert(sourcesListList[listIndex].Contains(source),"Unregistration of unknown gravity source!", source);

        sourcesListList[listIndex].Remove(source);
    }
}