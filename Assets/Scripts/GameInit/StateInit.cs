using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
public class StateInit : MonoBehaviour
{
    [SerializeField] GameObject levelStateObj;
    [SerializeField] GameObject TutuarialStateObj;
    [SerializeField] GameObject horizontalLine;
    [SerializeField] GameObject verticalLine;
    [SerializeField] int numbersOfLevel = 10;
    
    public static List<LevelState> states;

    Vector2 pos;
    [SerializeField] Vector2 fixedPos = new Vector3(3.5f/3,1.5f,0f);
    public void Awake()
    {
        
        if(states!=null)
            states.Clear();
        pos =new Vector2(-1.75f,-3f);
        states = new List<LevelState>();
         LevelState addState = new LevelState();
        addState.Pos = new Vector2(-1.75f,-3f);
        addState.Stars = 0;
        addState.IsOpen = true;
        states.Add(addState);
        GameObject tutua= GameObject.Instantiate(TutuarialStateObj,addState.Pos,Quaternion.identity);
        tutua.transform.SetParent(this.transform);
        tutua.name = "Tutuarial State";

        for(int i = 1;i<=numbersOfLevel;i++)
        {
            if(i%4 == 0)
            {
                GameObject lineH = GameObject.Instantiate(horizontalLine);
                lineH.transform.localPosition = new Vector2(0f,pos.y);
                GameObject lineV = GameObject.Instantiate(verticalLine);
                lineV.transform.localPosition = new Vector2(pos.x,pos.y+fixedPos.y/2);
                lineH.transform.SetParent(this.transform);
                lineV.transform.SetParent(this.transform);
                lineH.name = string.Format("HorizontalLine {0}",i/4 +1);
                lineV.name = string.Format("VerticalLine {0}",i/4 + 1);
                pos.y += fixedPos.y;
            }
            else if((i / 4)%2 == 0)
            {
                pos.x += fixedPos.x;
            }
            else
            {
                pos.x -= fixedPos.x;
            }
            GameObject state = GameObject.Instantiate(levelStateObj);
            
            //Create
            state.name = string.Format("State{0}",i);
            state.transform.localPosition = pos;
            state.GetComponentInChildren<TMP_Text>().text = string.Format("{0}",i);
            state.transform.SetParent(this.transform);
            //Add
            addState = new LevelState();
            addState.IsOpen = false;
            addState.Pos = pos;
            addState.Stars = 0;
            states.Add(addState);
        }
        Debug.Log("Da tao thanh cong");
    }

    // public void ListLevels()
    // {
    //     foreach(var i in states)
    //     {
    //         Debug.Log(i);
    //     }
    // }


}


[CustomEditor(typeof(StateInit))]
public class StateInitEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        
        StateInit mystate = (StateInit)target;

        // if(GUILayout.Button("Create"))
        // {
        //     mystate.CreateStateTree();
        // }
        // if(GUILayout.Button("List"))
        // {
        //     mystate.ListLevels();
        // }

    }
}