using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TextRPG
{
    public class Encounter : MonoBehaviour
    {
        public Enemy Enemy { get; set; }
        [SerializeField] Player player;
        // Use this for initialization
        [SerializeField] Button[] dynamicControls;
        public delegate void OnEnemyDieHandler();
        public static OnEnemyDieHandler OnEnenmyDie;

        private void Start()
        {
            OnEnenmyDie += Loot;
        }

        public void ResetDynamicControls()
        {
            foreach (Button button in dynamicControls)
            {
                button.interactable = false;
            }
        }
        public void StartCombat()
        {
            this.Enemy = player.Room.Enemy;
            dynamicControls[0].interactable = true;
            dynamicControls[1].interactable = true;
        }

        public void StartChest()
        {
            dynamicControls[3].interactable = true;
        }

        public void StartExit()
        {
            dynamicControls[2].interactable = true;
        }

        public void OpenChest()
        {
            Chest chest = player.Room.Chest;
            if (chest.Trap)
            {
                int randomDamage = (int)(Random.Range(1,4));
                player.TakeDamage(randomDamage);
                Journal.Instance.Log("It was a trap! You took " + randomDamage + " damage!");
            }
            else if (chest.Heal)
            {
                int randomHeal = (int)(Random.Range(2,6));
                Journal.Instance.Log("A soothing mist fills the room... you heal for " + randomHeal + " health!");
                player.TakeDamage(-randomHeal);
            }
            else if (chest.Enemy)
            {
                player.Room.Enemy = chest.Enemy;
                player.Room.Chest = null;
                Journal.Instance.Log("Uh oh...");
                player.Investigate();
            }
            else
            {
                player.Gold +=chest.Gold;
                player.AddItem(chest.Item);
                Journal.Instance.Log("You found: <color=#FFE556FF>" + chest.Item + "</color> and <color=#FFE556FF>" + chest.Gold +"g.</color>");
            }
        player.Room.Chest = null;
        dynamicControls[3].interactable = false;
        }
        public void Attack()
        {
            int playerDamageAmount = (int)(Random.value * (player.Attack - Enemy.Defence));
            int enemyDamageAmount = (int)(Random.value * (Enemy.Attack - player.Defence));
            Journal.Instance.Log("<color=#59ffa1>You attacked and dealt <b>" + playerDamageAmount + "</b> damage!</color>");
            Journal.Instance.Log("<color=#59ffa1>The enemy retaliated, and hit you for <b>" + enemyDamageAmount + "</b> damage!</color>");
            player.TakeDamage(enemyDamageAmount);
            Enemy.TakeDamage(playerDamageAmount);
        }

		public void Flee()
		{
			int enemyDamageAmount = (int)(Random.value * (Enemy.Attack - player.Defence));
			player.Room.Enemy = null;
			player.TakeDamage(enemyDamageAmount);
			Journal.Instance.Log("<color=#59ffa1>You flee the flight, but you take <b>" + enemyDamageAmount + "</b> damage!</color>");
			player.Investigate();
		}

        public void ExitFloor()
        {
            StartCoroutine(player.world.GenerateFloor());
            player.Floor += 1;
            Journal.Instance.Log("You leave down the stairs. Floor: " + player.Floor);
            player.Investigate();
        }

        public void Loot()
        {
            player.AddItem(this.Enemy.Inventory[0]);
            player.Gold += this.Enemy.Gold;
            Journal.Instance.Log(string.Format(
                "color=#56FFC7FF>You've slain {0}. The dead {0} is suddenly replaced with a {1} and about {2} gold!. Nice.</color>",
                this.Enemy.Description, this.Enemy.Inventory[0], this.Enemy.Gold
                ));
            player.Room.Enemy = null;
            player.Room.Empty = true;
            player.Investigate();
        }
    }
}