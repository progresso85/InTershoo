using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Fire
{
    string pattern;
    public Fire(string pattern)
    {  this.pattern = pattern; }
       

    public void shoot()
    {
        switch(pattern)
        {
            case "simple":
                simple();
                break;
            case "circle":
                circle();
                break;
            case "seeker":
                seeker();
                break;
            case "laser":
                laser();
                break;
            default: break;
        }
    }

    void simple()
    {

    }

    void circle()
    {

    }

    void seeker()
    {

    }

    void laser()
    {

    }
}