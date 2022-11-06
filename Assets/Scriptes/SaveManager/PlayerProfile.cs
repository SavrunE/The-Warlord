using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
	private string name;

	private const string saveKey = "playerProfileKey";

	public string Name()
	{
		Load();
		return name;
	}

	private PlayerProfileData GetSaveSnapshot()
	{
		var data = new PlayerProfileData();

		if (name.Length != 0)
		{
			data.Name = name;
		}
		//when adding an element add here

		return data;
	}

	public void ChangeData(string name)
	{
		this.name = name;
		//when adding an element add here
		Save();
	}

	private void Load()
	{
		var data = SaveManager.Load<PlayerProfileData>(saveKey);
		name = data.Name;
		//when adding an element add here
	}

	private void Save()
	{
		SaveManager.Save(saveKey, GetSaveSnapshot());
	}
}
