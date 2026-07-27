using UnityEngine;
namespace CashEngine.Save{public class LocalSaveProvider:ISaveProvider{
public void Save(string k,string j)=>PlayerPrefs.SetString(k,j);
public string Load(string k)=>PlayerPrefs.GetString(k,"");
public bool Has(string k)=>PlayerPrefs.HasKey(k);
}}