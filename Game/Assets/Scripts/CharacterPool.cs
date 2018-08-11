using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterPool : ScriptableObject
{
    [SerializeField] private List<Character> pool;

    public List<Character>GetRandom(int number)
    {
        List<Character> generatedList = new List<Character>();

        for (int i = 0; i < number; i++)
        {
            generatedList.Add(pool[Random.Range(0, pool.Count)]);
        }

        return generatedList;
    }
	
}
