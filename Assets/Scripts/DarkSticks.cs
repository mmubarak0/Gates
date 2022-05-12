using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSticks : MonoBehaviour
{
    public GameObject LightStick;
    [SerializeField] private bool ON = false;
    private int NotCounter = 0;
    private int OrCounter = 0;
    private int AndCounter = 0;
    private void Awake() {
        if (!ON){
            LightStick.SetActive(false);
        } else {
            LightStick.SetActive(true);
            NotCounter++;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Not Gate
        // if (col.gameObject.tag == "notGate" && NotCounter%2 == 0){
        if (col.gameObject.tag == "notGate" && !LightStick.activeSelf && OrCounter==0 && AndCounter == 0){
            LightStick.SetActive(true);
        // } else if (col.gameObject.tag == "notGate" && NotCounter%2 != 0){
        } else if (col.gameObject.tag == "notGate" && LightStick.activeSelf && OrCounter==0 && AndCounter == 0){
            LightStick.SetActive(false);
        } else if (col.gameObject.tag == "notGate" && LightStick.activeSelf && OrCounter==0 && AndCounter != 0){
            LightStick.SetActive(false);
        }
        // increase the not counter 
        if (col.gameObject.tag == "notGate"){
            NotCounter++;
        }


        // Or Gate
        if (col.gameObject.tag == "orGate" && AndCounter==0){
            LightStick.SetActive(true);
        } else if (col.gameObject.tag == "orGate" && AndCounter!=0){
            LightStick.SetActive(false);
        }
        // increase the or counter 
        if (col.gameObject.tag == "orGate"){
            OrCounter++;
        }


        // And Gate
        if (col.gameObject.tag == "andGate" && NotCounter == 0 && OrCounter == 0){
            LightStick.SetActive(true);
        } else if (col.gameObject.tag == "andGate") {
            LightStick.SetActive(false);
        }
        // increase and counter
        if (col.gameObject.tag == "andGate"){
            AndCounter++;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        // Not Gate
        // if (col.gameObject.tag == "notGate" && NotCounter%2 != 0){
        if (col.gameObject.tag == "notGate" && LightStick.activeSelf && OrCounter==0){
            LightStick.SetActive(false);
        // } else if (col.gameObject.tag == "notGate" && NotCounter%2 == 0){
        } else if (col.gameObject.tag == "notGate" && !LightStick.activeSelf && OrCounter==0){
            LightStick.SetActive(true);
        }
        // decrease not counter 
        if (col.gameObject.tag == "notGate"){
            NotCounter--;
        }


        // Or Gate
        if (col.gameObject.tag == "orGate" && NotCounter%2 == 0) {
            if (AndCounter == 0){
                LightStick.SetActive(false);
            } else {
                LightStick.SetActive(true);
            }
        } else if (col.gameObject.tag == "orGate" && NotCounter%2 != 0) {
            if (AndCounter == 0){
                LightStick.SetActive(true);
            } else {
                LightStick.SetActive(false);
            }
        }
        // decrease or counter
        if (col.gameObject.tag == "orGate") {
            OrCounter--;
        }


        // And Gate
        if (col.gameObject.tag == "andGate" && OrCounter == 0) {
            if (col.gameObject.tag == "andGate" && NotCounter%2 == 0) {
                LightStick.SetActive(false);
            } else if (col.gameObject.tag == "andGate" && NotCounter%2 != 0) {
                LightStick.SetActive(true);
            }
        } else if (col.gameObject.tag == "andGate" && OrCounter != 0) {
            if (col.gameObject.tag == "andGate" && NotCounter%2 == 0) {
                LightStick.SetActive(true);
            } else if (col.gameObject.tag == "andGate" && NotCounter%2 != 0) {
                LightStick.SetActive(true);
            }
        }
        // decrease and counter
        if (col.gameObject.tag == "andGate") {
            AndCounter--;
        }
    }
}
