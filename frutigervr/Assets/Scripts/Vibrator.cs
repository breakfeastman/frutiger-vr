using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;
public class Vibrator : MonoBehaviour
{ 
public float Amplitude;
public bool LeftHand;


void OnTriggerEnter(){

if(LeftHand)
{


    StartCoroutine(EasyInputs.Vibration(EasyHand.LeftHand, Amplitude, 0.15f));

    
}
if(!LeftHand)
{

    StartCoroutine(EasyInputs.Vibration(EasyHand.RightHand, Amplitude, 0.15f));


}




}

    
}
