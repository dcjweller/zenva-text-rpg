using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class UberChicken : Enemy
    {

        // Use this for initialization
        void Start()
        {
            Energy = 15;
            Attack = 8;
            Defence = 5;
            Gold = 30;
            Description = "Uber Chicken";
            Inventory.Add("Sniper");
        }


    }
}