using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{

    public class Player : Character
    {

        public int Floor { get; set; }

        // Use this for initialization
        void Start()
        {
            Floor = 0;
            Energy = 30;
            Attack = 10;
            Defence = 5;
            Inventory = new List<string>();
            RoomIndex = new Vector2(2, 2);
        }

        public void AddItem(string item)
        {
            Inventory.Add(item);
        }

        public void AddItem(int item)
        {
            Inventory.Add(ItemDatabase.Instance.Items[item]);
        }

        public override void TakeDamage(int amount)
        {
            Debug.Log("You've taken damage!");
            base.TakeDamage(amount);

        }

        public override void Die()
        {
            Debug.Log("You died!");
            base.Die();
        }
    }
}