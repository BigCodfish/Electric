using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCube : Prop
{
    public BreakItem[] cubes;
    private int id = 0;
    public override void Function()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            Invoke("Break", 1);
        }
    }

    void Break()
    {
        cubes[id++].Break();
    }
}
