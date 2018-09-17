using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{

    public class Player : Character
    {

        public int Floor { get; set; }
<<<<<<< HEAD
        public Room Room { get; set; }
        public World world;
        [SerializeField] Encounter encounter;
=======
>>>>>>> parent of 4dd1d68... Day 5

        // Use this for initialization
        void Start()
        {
            Floor = 0;
            Energy = 30;
            Attack = 10;
            Defence = 5;
            Inventory = new List<string>();
            RoomIndex = new Vector2(2, 2);
<<<<<<< HEAD
            this.Room = world.Dungeon[((int)RoomIndex.x), ((int)RoomIndex.y)];
            this.Room.Empty = true;
            AddItem("Goose Brains");
            
        }

        public void Move(int direction)
        {
            if (this.Room.Enemy)
            {
                return;
            }

            if (direction == 0 && RoomIndex.y > 0)
            {
                RoomIndex -= Vector2.up; 
            }
            
            if (direction == 1 && RoomIndex.x < world.Dungeon.GetLength(0)-1)
            {
                Journal.Instance.Log("You head East.");
                RoomIndex += Vector2.right;
            }

            if (direction == 2 && RoomIndex.y < world.Dungeon.GetLength(1)-1)
            {
                Journal.Instance.Log("You head South.");
                RoomIndex -=Vector2.down;
            }

            if (direction == 3 && RoomIndex.x > 0)
            {
                Journal.Instance.Log("You head West.");
                RoomIndex += Vector2.left;
            }
            if (this.Room.RoomIndex != RoomIndex)
            Investigate();
        }

        public void Investigate()
        {
            encounter.ResetDynamicControls();
            this.Room = world.Dungeon[(int)RoomIndex.x, (int)RoomIndex.y];
            if (this.Room.Empty)
            {
                Journal.Instance.Log("There's nothing interesting in this room...");
            }
            else if (this.Room.Chest != null)
            {
                Journal.Instance.Log("You've found a chest! What will you do?");
                encounter.StartChest();
            }
            else if (this.Room.Enemy != null)
            {
                Journal.Instance.Log("Suddenly, a " + Room.Enemy.Description + " appears! What will you do?");
                encounter.StartCombat();
            }
            else if (this.Room.Exit)
            {
                encounter.StartExit();
                Journal.Instance.Log("You've found some stairs leading downwards...");
            }
=======
>>>>>>> parent of 4dd1d68... Day 5
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