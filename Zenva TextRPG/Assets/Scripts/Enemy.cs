﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{

    public class Enemy : TextRPG.Character
    {

        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);

        }

        public override void Die()
        {
            Debug.Log("Enemy has died.");
        }
    }
}