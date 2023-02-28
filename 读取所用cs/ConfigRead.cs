using Core;
using System.Xml;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

namespace Core
{
    public class ConfigRead
    {
        public static List<T> LoadConfig<T>(string resPath) where T : new()
        {
            TextAsset textAsset = ResourceManager.LoadAsset<TextAsset>(resPath);

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(textAsset.text);

            XmlNode rootNode = xmlDocument.DocumentElement;
            XmlNodeList xmlNodeList = rootNode.ChildNodes;

            List<T> dataList = new List<T>();

            foreach (XmlNode itemNode in xmlNodeList)
            {
                T data = new T();
                Type t = data.GetType();
                FieldInfo[] fields = t.GetFields();


                foreach (FieldInfo field in fields)
                {
                    string key = field.Name.ToString();
                    string val = itemNode.SelectSingleNode(key).InnerText;

                    if (field.FieldType == typeof(bool))
                        field.SetValue(data, int.Parse(val) == 1);

                    else if (field.FieldType == typeof(string))
                        field.SetValue(data, val);

                    else if (field.FieldType == typeof(int))
                        field.SetValue(data, int.Parse(val));

                    else if (field.FieldType == typeof(long))
                        field.SetValue(data, long.Parse(val));

                    else if (field.FieldType == typeof(float))
                        field.SetValue(data, float.Parse(val));

                    else if (field.FieldType == typeof(double))
                        field.SetValue(data, double.Parse(val));

                    else if (field.FieldType == typeof(List<int>))
                    {
                        string[] values = val.Split('|');
                        List<int> vs = new List<int>();
                        for (int i = 0; i < values.Length; i++)
                            vs.Add(int.Parse(values[i]));

                        field.SetValue(data, vs);
                    }
                    else if (field.FieldType == typeof(List<long>))
                    {
                        string[] values = val.Split('|');
                        List<long> vs = new List<long>();
                        for (int i = 0; i < values.Length; i++)
                            vs.Add(long.Parse(values[i]));

                        field.SetValue(data, vs);
                    }
                    else if (field.FieldType == typeof(List<float>))
                    {
                        string[] values = val.Split('|');
                        List<float> vs = new List<float>();
                        for (int i = 0; i < values.Length; i++)
                            vs.Add(float.Parse(values[i]));

                        field.SetValue(data, vs);
                    }
                    else if (field.FieldType == typeof(List<double>))
                    {
                        string[] values = val.Split('|');
                        List<double> vs = new List<double>();
                        for (int i = 0; i < values.Length; i++)
                            vs.Add(double.Parse(values[i]));

                        field.SetValue(data, vs);
                    }
                    else if (field.FieldType == typeof(List<string>))
                    {
                        string[] values = val.Split('|');
                        List<string> vs = new List<string>();
                        for (int i = 0; i < values.Length; i++)
                            vs.Add(values[i]);

                        field.SetValue(data, vs);
                    }
                    else if (field.FieldType == typeof(Vector2))
                    {
                        string[] values = val.Split(',');
                        Vector2 temp = new Vector2(Convert.ToSingle(values[0]),Convert.ToSingle(values[1]));
                        field.SetValue(data, temp);
                    }
                    else if (field.FieldType == typeof(Vector3))
                    {
                        string[] values = val.Split(',');
                        Vector3 temp = new Vector3(Convert.ToSingle(values[0]),Convert.ToSingle(values[1]),Convert.ToSingle(values[2]));
                        field.SetValue(data, temp);
                    }
                    else if (field.FieldType == typeof(List<Vector2>))
                    {
                        List<Vector2> tempList = new List<Vector2>();
                        string[] v2List = val.Split('|');
                        for (int i = 0; i < v2List.Length; i++)
                        {
                            string[] v2 = v2List[i].Split(',');
                            Vector2 temp = new Vector2(Convert.ToSingle(v2[0]),Convert.ToSingle(v2[1]));
                            tempList.Add(temp);
                        }
                        field.SetValue(data, tempList);
                    }
                    else if (field.FieldType == typeof(List<Vector3>))
                    {
                        List<Vector3> tempList = new List<Vector3>();
                        string[] v2List = val.Split('|');
                        for (int i = 0; i < v2List.Length; i++)
                        {
                            string[] v2 = v2List[i].Split(',');
                            Vector3 temp = new Vector3(Convert.ToSingle(v2[0]),Convert.ToSingle(v2[1]),Convert.ToSingle(v2[2]));
                            tempList.Add(temp);
                        }
                        field.SetValue(data, tempList);
                    }
                }

                dataList.Add(data);
            }
            return dataList;
        }
    }
}