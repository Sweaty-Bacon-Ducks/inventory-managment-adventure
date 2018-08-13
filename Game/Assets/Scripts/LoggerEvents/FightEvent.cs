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

		const string healString = "{0} healed himself!";
		const string startString = "{0} has encountered {1}, brace yourselves!";
		const string hitString = "{0} has hit {1}, dealing {2:0.0} damage!";
		const string missString = "{0} has missed!";
		const string dieString = "{0} has died";
		const string endString = "{0} has won!";

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

			Debug.Log(currentCharacter.Name + " " + currentCharacter.HitPoints);

			if (currentCharacter.HitPoints / currentCharacter.MaxHitPoints < 0.25f) //Heal
			{
				if (currentCharacter.PatchUp())
				{
					Logger.Instance.ShowLog(currentTime,
						String.Format(healString,
									  currentCharacter.Name));
				}
			}
			else if (currentCharacter.CharacterWeapon)
			{
				if (Random.Range(0f, 1f) > 1 - currentCharacter.CharacterWeapon.HitChance)
				{
					float dmg = Random.Range(currentCharacter.CharacterWeapon.MinDamage,
												 currentCharacter.CharacterWeapon.MaxDamage);
					string toLog = hitString;
					if (Random.Range(0f, 1f) > 1 - currentCharacter.CharacterWeapon.CriticalHitChance)
					{
						toLog = "Critical! " + hitString;
						dmg = currentCharacter.CharacterWeapon.CriticalMultiplier *
									Random.Range(currentCharacter.CharacterWeapon.MinDamage,
												 currentCharacter.CharacterWeapon.MaxDamage);
					}
					float dealtDamage = nextCharacter.DealDamage(dmg);
					Logger.Instance.ShowLog(currentTime,
											String.Format(toLog,
														  currentCharacter.Name,
														  nextCharacter.Name, dealtDamage));
				}
				else
				{
					Logger.Instance.ShowLog(currentTime,
											String.Format(missString,
														  currentCharacter.Name));
				}
			}
			else if (!currentCharacter.CharacterWeapon)
			{
				float dmg = Random.Range(1, 2);
				string toLog = hitString;
				if (Random.Range(0f, 1f) > 0.3f)
				{
					toLog = "Critical! " + hitString;
					dmg = 15 * Random.Range(5,10);
				}
				float dealtDamage = nextCharacter.DealDamage(dmg);
				Logger.Instance.ShowLog(currentTime,
										String.Format(toLog,
													  currentCharacter.Name,
													  nextCharacter.Name, dealtDamage));
			}
			yield return new WaitForSeconds(timeBetweenTurns);

			currentTime = DateTime.Now;
		}
		Character dead;
		Character winner = CheckWinner(player, enemy, out dead);

		Logger.Instance.ShowLog(currentTime,
								String.Format(dieString,
											  dead.Name));

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
