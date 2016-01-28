using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class MasterTableBase<T> where T : MasterBase, new()
{
	protected List<T> masters;
	public List<T> All { get { return masters; } }
	
	public void Load(string filePath)
	{
		var text = ((TextAsset)Resources.Load(filePath, typeof(TextAsset))).text;
		text = text.Trim().Replace("\r", "") + "\n";
		//text = text.Trim ();
		var lines = text.Split('\n').ToList();
		
		// header
		var headerElements = lines[0].Split(',');
		lines.RemoveAt(0); // header
		
		// body
		masters = new List<T>();
		foreach (var line in lines) ParseLine(line, headerElements);
	}
	
	private void ParseLine(string line, string[] headerElements)
	{
		var elements = line.Split(',');
		if (elements.Length == 1) return;
		if (elements.Length != headerElements.Length)
		{
			Debug.LogWarning(string.Format("can't load: {0}", line));
			return;
		}
		
		var param = new Dictionary<string, string>();
		for (int i = 0; i < elements.Length; ++i) 
		{
			if (elements [i] == "") {
				Debug.Log ("要素がなかったので、”−１”をいれました,意図しない場合はチェックしてください");
				elements [i] = "-1";
			}

			param.Add (headerElements [i], elements [i]);
		}
		var master = new T();
		master.Load(param);
		masters.Add(master);
	}
}

public class MasterBase
{
	public void Load(Dictionary<string, string> param)
	{
		foreach (string key in param.Keys) SetField(key, param[key]);
	}
	
	private void SetField(string key, string value)
	{
		PropertyInfo propertyInfo = this.GetType ().GetProperty (key, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
		
		if (propertyInfo.PropertyType == typeof(int))
			propertyInfo.SetValue (this, int.Parse (value), null);
		else if (propertyInfo.PropertyType == typeof(string))
			propertyInfo.SetValue (this, value, null);
		else if (propertyInfo.PropertyType == typeof(double))
			propertyInfo.SetValue (this, double.Parse (value), null);
		else if (propertyInfo.PropertyType == typeof(float))
			propertyInfo.SetValue (this, float.Parse (value), null);
		else if (propertyInfo.PropertyType == typeof(CharacterAnimator.Animation))
			propertyInfo.SetValue (this, (CharacterAnimator.Animation)Enum.Parse (typeof(CharacterAnimator.Animation), value), null);
		else if (propertyInfo.PropertyType == typeof(CharacterAnimator.State))
			propertyInfo.SetValue (this, (CharacterAnimator.State)Enum.Parse (typeof(CharacterAnimator.State), value), null);
		else if (propertyInfo.PropertyType == typeof(ExtraAnimator.Animation))
			propertyInfo.SetValue (this, (ExtraAnimator.Animation)Enum.Parse (typeof(ExtraAnimator.Animation), value), null);
		else if (propertyInfo.PropertyType == typeof(CameraAnimator.Animation))
			propertyInfo.SetValue (this, (CameraAnimator.Animation)Enum.Parse (typeof(CameraAnimator.Animation), value), null);
		else if (propertyInfo.PropertyType == typeof(SEManager.SE))
			propertyInfo.SetValue (this, (SEManager.SE)Enum.Parse (typeof(SEManager.SE), value), null);

		// 他の型にも対応させたいときには適当にここに。enumとかもどうにかなり(そう。
	}
}