/**
 * Auto generated by XbufferExcelToData, do not edit it 
 * 表格名字
 */
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using xbuffer;

namespace Data
{
    public class t_AuthorInfo3Container
    {
        private List<t_AuthorInfo3> list = null;
        private Dictionary<int, t_AuthorInfo3> map = null;

        public List<t_AuthorInfo3> getList()
        {
            if (list == null || list.Count <= 0)
                loadDataFromBin();
            return list;
        }

        public Dictionary<int, t_AuthorInfo3> getMap()
        {
            if (map == null || map.Count <= 0)
                loadDataFromBin();
            return map;
        }

        public void ClearList()
        {
            if (list != null && list.Count > 0)
                list.Clear();
            if (map != null && map.Count > 0)
                map.Clear();
        }   

        public void loadDataFromBin()
        {   
            Stream fs = ConfLoader.Singleton.getStreamByteName(typeof(t_AuthorInfo3).Name);
            if(fs != null)
            {
                BinaryReader br = new BinaryReader(fs);
                uint offset = 0;
                bool frist = true;
                try{
                    while (fs.Length - fs.Position > 0)
                    {
                        if (frist)
                        {
                            frist = false;
                            ClearList();
                            var count = br.ReadInt32();
                            list =  new List<t_AuthorInfo3>(count);
                            map = new Dictionary<int, t_AuthorInfo3>(count);
                        }

                        var length = br.ReadInt32();
                        var data = br.ReadBytes(length);
                        var obj= t_AuthorInfo3Buffer.deserialize(data, ref offset);
                        offset = 0;
                        list.Add(obj);
                        map.Add(obj.id, obj); 
                    }
                }catch (Exception ex)
                {
                    Debug.LogError("import data error: " + ex.ToString());
                }           
                br.Close();
                fs.Close();
            }
        }
    }
}