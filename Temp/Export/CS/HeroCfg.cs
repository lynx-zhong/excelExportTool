using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Config
{
	public class HeroCfg
	{
		public int id;
		public bool isLeader;
		public string name;
		public string model;
		public int age;
		public long power;
		public float speed;
		public double hp;
		public List<int> someIntParams;
		public List<long> someLongParams;
		public List<float> someFloatParams;
		public List<double> someDoubleParams;
		public List<string> someStringParams;

		public static List<HeroCfg> LoadConfig()
		{
			List<HeroCfg> dataList = ConfigRead.LoadConfig<HeroCfg>("Assets/AssetsPackage/ConfigData/HeroCfg.xml");
			return dataList;
		}
 
		public static HeroCfg GetSingleRecore(int id)
		{
			List<HeroCfg> dataList = LoadConfig();
			foreach (var item in dataList)
			{
				if (item.id == id)
				{
					return item;
				}
			}
			return null;
		}
	}
}
