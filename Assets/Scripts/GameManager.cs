using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> LightSticks;
    public GameObject nodeNot;
    public GameObject nodeOr;
    public GameObject nodeAnd;
    private bool Won = false;
    private int level = StaticVariables.level;
    private int numOfGates = 3;
    private int xstep = 0;
    private int xinit = -850;
    private int xfinal = 850;
    public int NumOfNotGate = 1;
    public int NumOfOrGate = 1;
    public int NumOfAndGate = 1;
    private void Start()
    {
        switch (level){
            case 1:
                NumOfNotGate = 3;
                NumOfOrGate = 0;
                NumOfAndGate = 0;
                numOfGates = NumOfNotGate + NumOfOrGate + NumOfAndGate;
                break;
            case 2:
                NumOfNotGate = 2;
                NumOfOrGate = 1;
                NumOfAndGate = 1;
                numOfGates = NumOfNotGate + NumOfOrGate + NumOfAndGate;
                break;
            case 3:
                NumOfNotGate = 1;
                NumOfOrGate = 0;
                NumOfAndGate = 4;
                numOfGates = NumOfNotGate + NumOfOrGate + NumOfAndGate;
                break;
        }

        xstep = Mathf.Abs(xinit - xfinal)/(numOfGates-1);

        Vector3 pos = new Vector3(xinit, -450, 0);
        for (int i=0; i<numOfGates; i++){
            if (i >= 0 && i < NumOfNotGate){
                GameObject Nod = Instantiate(nodeNot, pos, Quaternion.identity);
                Nod.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);
            }
            else if (i >= NumOfNotGate && i < NumOfOrGate+NumOfNotGate){
                GameObject Nod = Instantiate(nodeOr, pos, Quaternion.identity);
                Nod.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);
            }
            else if (i >= NumOfOrGate && i < NumOfAndGate+NumOfOrGate+NumOfNotGate){
                GameObject Nod = Instantiate(nodeAnd, pos, Quaternion.identity);
                Nod.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);
            }
            pos.x += xstep;
        }
    }
    private void Update()
    {
        for (int i=0; i<LightSticks.Count; i++) {
            if (LightSticks[i].activeSelf==false){
                break;
            } else if (i==LightSticks.Count-1){
                Won = true;
            }
        }

        if (Won){
            LoadNextLevel();
            Won = false;
        }
    }

    private void LoadNextLevel()
    {
        // destroy dark sticks and rings and show you win UI then load next level after 5 second
        Invoke("nextlevel", 5f);
    }
    private void nextlevel()
    {
        StaticVariables.level += 1;
        SceneLoader.NextLevel();
    }


}
