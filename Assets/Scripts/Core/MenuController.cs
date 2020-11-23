using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class MenuController : MonoBehaviour
{
    [SerializeField] int currentLevel = 1;
    [SerializeField] int nextLevel;
    static List<StateController> levels;
    public void AddLevelsList() {
        levels = GetComponentsInChildren<StateController>().ToList();
        Debug.Log("Add done");
    }
    public void Count() {
        nextLevel =  (int)Random.Range(1,1000);
        for(int i = currentLevel;i<=nextLevel;i++)
        {
            LevelState state = StateInit.states[i];
            state.IsOpen = true;
            levels[i].UnLock(state.IsOpen);
            state.Stars = (int)Random.Range(0,4);
            levels[i].SetStars(state.Stars);
        }
        if(nextLevel < currentLevel&& nextLevel>0)
        {
            for(int i = nextLevel+1;i<StateInit.states.Count();i++)
            {
                StateInit.states[i].IsOpen = false;
                StateInit.states[i].Stars = 0;
                levels[i].UnLock(false);
            }
        }
        currentLevel = (nextLevel>=1)?nextLevel:1;
    }
    
}


[CustomEditor(typeof(MenuController))]
public class MenuControllerEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        MenuController mine = (MenuController)target;
        if(GUILayout.Button("ListCount"))
        {
            mine.AddLevelsList();
            mine.Count();
        }
    }
}
