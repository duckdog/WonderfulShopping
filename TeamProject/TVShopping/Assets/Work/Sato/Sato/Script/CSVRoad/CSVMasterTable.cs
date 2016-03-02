﻿using UnityEngine;
using System.Collections;

public class CSVMasterTable : MasterTableBase<CSVScenarioData> 
{
	//FileName(Path)
	private static readonly string _FilePath = "Stage1_Scenario";
	public void Load() { Load(_FilePath); }
}

public class CSVScenarioData : MasterBase
{
	/*   public string Jump { get; private set; }
    public string RoteChangeFlag { get; private set; }
    public string Route { get; private set; }
    public string text { get; private set; }*/

	public string Scenario { get; private set; }
	public int CurrentRoute{ get; private set; }
	public int NextRoute   { get; private set; }
	public float WatchTime { get; private set; }
	public CharacterAnimator.Animation JonyAnimation { get; private set; }
	public CharacterAnimator.Animation AberyAnimation { get; private set; }
	public CharacterAnimator.State JonyState { get; private set; }
	public CharacterAnimator.State AberyState { get; private set; }
	public int CameraNumber{ get; private set;}
	public CameraAnimator.Animation CameraAnimation{ get; private set;}
	public ExtraAnimator.Animation ExtraAnimation { get; private set;}
	public SEManager.SE SEPetern { get; private set;}


}


