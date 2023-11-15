using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Fire
{
    string pattern;
    GameObject projectile;
    public Fire(GameObject projectile, string pattern)
    {
        this.pattern = pattern;
        this.projectile = projectile;
    }

    public void changePattern(string pattern)
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