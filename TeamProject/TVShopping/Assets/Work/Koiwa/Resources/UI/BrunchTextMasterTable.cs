using UnityEngine;
using System.Collections;

public class BrunchTextMasterTable : MasterTableBase<BrunchButtonText> 
{
	//FileName(Path)
	/// 
	/// ウェムさん_FilePath にファイル名をお願いします！
	private static readonly string _FilePath = "buttontextsample";
	public void Load() { Load(_FilePath); }
}

public class BrunchButtonText : MasterBase
{
	public string ButtonText{ get; set;}
	public int RouteNumber{ get; set;}
	//要素が増えた場合はここに追加
	//

}
