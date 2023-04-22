using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class TeamManager : MonoBehaviour
{
    public static TeamManager Instance;

    public List<Team> TEAMS;
    private void Awake()
    {
        Instance = this;
        TEAMS = GetComponentsInChildren<Team>().ToList();
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameManager.GameState state)
    {
        
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Team> getUnFinishTeams()
    {
        return TEAMS.Where(t => t.getNumsFinishPawn() < t.getNumsPawn() && t.getNumsPawn() > 0).ToList();
    }
    
}
