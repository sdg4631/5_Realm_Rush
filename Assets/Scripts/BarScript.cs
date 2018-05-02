using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour 
{
	[SerializeField] private float fillAmount;
	[SerializeField] private Image content; 

	void Start() 
	{
		
	}
	
	void Update() 
	{
		HandleBar();
	}

	private void HandleBar()
	{
		content.fillAmount = fillAmount;
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax)
	{
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}
