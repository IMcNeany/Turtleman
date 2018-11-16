using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public int playerNumber;

	private float Horizontal, Vertical, AimHorizontal, AimVertical, Trigger;
	private bool[] buttons = new bool[4];
	private bool start;

	// Update is called once per frame
	void Update () {
		Horizontal = Input.GetAxis("Horizontal_" + playerNumber);
		Vertical = Input.GetAxis("Vertical_" + playerNumber);
		
		AimHorizontal = Input.GetAxis("Aim_Horizontal_" + playerNumber);
		AimVertical = Input.GetAxis("Aim_Vertical_" + playerNumber);
		
		Trigger = Input.GetAxis("Trigger_" + playerNumber);

		buttons[0] = Input.GetButton("A_" + playerNumber);
		buttons[1] = Input.GetButton("B_" + playerNumber);
		buttons[2] = Input.GetButton("X_" + playerNumber);
		buttons[3] = Input.GetButton("Y_" + playerNumber);

		start = Input.GetButton("Start_" + playerNumber);
	}

	public float getHorizontal(){ return Horizontal; }
	public float getVertical(){ return Vertical; }

	public float getAimHorizontal(){ return AimHorizontal; }
	public float getAimVertical(){ return AimVertical; }

	public float getTrigger(){ return Trigger; }

    public void setHorizontal(float x) { Horizontal = x; }
    public void setVertical(float y) { Vertical = y; }

    /*0 - A, 1 - B, 2 - X, 3 - Y */
    public bool getButtons(int num){
		return buttons[num];
	}

	public bool getStart(){
		return start;
	}
}


