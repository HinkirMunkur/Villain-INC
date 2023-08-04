using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameDataSO", menuName = "DataSO/GameDataSO", order = 1)]
public class GameDataSO : ScriptableObject
{
    [SerializeField] private LevelDataSO[] levelData;
    public LevelDataSO[] LevelData => levelData;
    

    [SerializeField] private List<SubjectBasic> subjectBasicList;
     public List<SubjectBasic> SubjectBasicList => subjectBasicList;
}