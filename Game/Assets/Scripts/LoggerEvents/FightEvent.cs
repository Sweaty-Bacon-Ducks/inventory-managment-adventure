//using C5;
using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public class FightEvent : IEvent
{
	public FightEvent() { }

	public IEnumerator EventAction(params object[] obj)
	{
		Character player = obj[0] as Character;
		Character enemy = obj[1] as Character;

		float hitChance = 0.6f;

		string startString = "{0} has encountered {1}, brace yourselves!";
		string hitString = "{0} has hit {1}, dealing {2:0.0} damage!";
		string missString = "{0} has missed!";
		string dieString = "{0} has died";
		string endString = "{0} has won!";

		Character[] fightQueue = new Character[2];

		int queueIndex = 0;

		DateTime currentTime = DateTime.Now;

		float minWaitTime = 0.5f;
		float maxWaitTime = 1.5f;

		float timeBetweenTurns = 0;

		int compRes = ((IComparable)player).CompareTo(enemy);
		if (compRes < 0)
		{
			fightQueue[0] = player;
			fightQueue[1] = enemy;
		}
		else
		{
			fightQueue[0] = enemy;
			fightQueue[1] = player;
		}
		Logger.Instance.ShowLog(currentTime,
								String.Format(startString,
											  player,
											  enemy));

		while (!player.IsDead && !enemy.IsDead)
		{
			Character currentCharacter = fightQueue[queueIndex];
			Character nextCharacter = fightQueue[(queueIndex + 1) % 2];
			queueIndex = (queueIndex + 1) % 2;

			timeBetweenTurns = Random.Range(minWaitTime, maxWaitTime);

			if (Random.Range(0f, 1f) > 1 - hitChance)
			{
				Debug.Log(currentCharacter.Name);
				float dmg = Random.Range(currentCharacter.CharacterWeapon.MinDamage,
										 currentCharacter.CharacterWeapon.MaxDamage);
				nextCharacter.DealDamage(dmg);

				Logger.Instance.ShowLog(currentTime,
										String.Format(hitString,
													  currentCharacter.Name,
													  nextCharacter.Name, dmg));
			}
			else
			{
				Logger.Instance.ShowLog(currentTime,
										String.Format(missString,
													  currentCharacter.Name));
			}

			yield return new WaitForSeconds(timeBetweenTurns);

			currentTime = DateTime.Now;
		}
		Character dead;
		Character winner = CheckWinner(player, enemy, out dead);

		Logger.Instance.ShowLog(currentTime,
								String.Format(dieString,
											  winner.Name));

		Logger.Instance.ShowLog(currentTime,
								String.Format(endString,
											  winner.Name));
	}
	private Character CheckWinner(Character first, Character second, out Character dead)
	{
		if (first.IsDead)
		{
			dead = first;
			return second;
		}
		else
		{
			dead = second;
			return first;
		}
	}
}
