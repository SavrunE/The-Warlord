using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class TextInput : MonoBehaviour
{
	private TMP_InputField thisText;
	[SerializeField] private TMP_Text text;

	private void Start()
	{
		thisText = GetComponent<TMP_InputField>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			text.text = thisText.text;
		}
	}
}
