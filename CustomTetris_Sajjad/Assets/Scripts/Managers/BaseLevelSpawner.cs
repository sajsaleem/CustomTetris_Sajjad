using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract  class BaseLevelSpawner : MonoBehaviour, ILevelSpawner
{
    [SerializeField] private List<BaseLevelSettings> levelScriptableObjects = new List<BaseLevelSettings>();

    private List<BaseLevelMaster> instantiatedLevels = new List<BaseLevelMaster>();

    public List<BaseLevelSettings> LevelScriptableObjects => levelScriptableObjects;

    public virtual void InstantiateLevelPrefab(LevelType _levelType) 
    {

        //BaseLevelSettings _levelSettings = levelScriptableObjects.First(t => t.level.levelPrefab.LevelType == _levelType);

        //if(!IsAlreadyInstantiated(_levelSettings.level.levelPrefab))
        //{
        //    BaseLevelMaster _level = Instantiate(_levelSettings.level.levelPrefab);
        //    //_level.LevelSettings = _levelSettings;
        //    _levelSettings.level.isInstantiated = true;
        //    instantiatedLevels.Add(_level);
        //}
        //else
        //{
        //    ActivateLevel(_levelType);
        //}
    }

    public bool IsAlreadyInstantiated(BaseLevelMaster _level)
    {
        if (instantiatedLevels.Contains(_level))
            return true;

        return false;
    }

    private void ActivateLevel(LevelType _levelType)
    {
        //instantiatedLevels.ForEach(
        //    obj =>
        //    {
        //        if (obj.LevelType == _levelType)
        //            obj.gameObject.SetActive(true);
        //    });
    }
}
