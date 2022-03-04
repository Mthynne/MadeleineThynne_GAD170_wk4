using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject fighterPrefab;
    public int teamSize = 3;
    public string[] fighterNames;
    public GameObject[] teamAFighters;
    public GameObject[] teamBFighters;


    // Start is called before the first frame update
    void Start()
    {
        teamAFighters = CreateTeam(teamAFighters);
        teamBFighters = CreateTeam(teamBFighters);
        GameObject randomA = teamAFighters[Random.Range(0, teamSize)];
        GameObject randomB = teamBFighters[Random.Range(0, teamSize)];
        Battle(randomA, randomB);
    }

    public GameObject[] CreateTeam(GameObject[] incTeam)
    {
        //create our team of fighters
        //spawn each fighter and add them to our team
        incTeam = new GameObject[teamSize]; //indexes = 0, 1 and 2
        for (int i = 0; i < teamSize; i++)
        {
            GameObject go = Instantiate(fighterPrefab);
            //assign to team
            incTeam[i] = go;
            //pick a random name from our array and give it to our fighter
            go.GetComponent<Character>().UpdateName(fighterNames[Random.Range(0, fighterNames.Length)]);

        }
        return incTeam;
    }

    public void Battle(GameObject fighterA, GameObject fighterB)
    {
        int coinFlip = Random.Range(0, 2);
        Character fAStats = fighterA.GetComponent<Character>();
        Character fBStats = fighterB.GetComponent<Character>();
        if(coinFlip == 0)
        {
            // fighterB.GetComponent<Character>().health -=
            // fighterA.GetComponent<Character>().attack - fighterB.GetComponent<Character>().defense;
            //above = bad, below = good
            fBStats.health -= fAStats.attack - fBStats.defense;
            Debug.Log("Fighter A attacks Fighter B");
            Debug.Log("Fighter B's health is now: " + fBStats.health);
        }
        else
        {
            fAStats.health -= fBStats.attack - fAStats.defense;
            Debug.Log("Fighter B attacks Fighter A");
            Debug.Log("Fighter A's health is now: " + fBStats.health);
        }
    }
}
