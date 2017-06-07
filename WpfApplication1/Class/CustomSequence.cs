using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolForDan
{
    public class CustomSequence
    {
        private static string CustomSequenceNames="CustomSequenceNames";

        private static ConfigHelper cfh = new ConfigHelper();

        public string CustomName { get; set; }

        public List<GameArea> LstCodeSequence { get; set; }

        public static List<CustomSequence> GetAllCustomSequenceName(bool? load=null)
        {
            List<CustomSequence> cs = new List<CustomSequence>();
            var value= cfh.GetValue(CustomSequenceNames);
            if (!string.IsNullOrEmpty(value))
            {
                value.Split(',').ToList().ForEach(p => { cs.Add(new CustomSequence(p)); });
            }
            if (load.HasValue && load.Value)
            {
                cs.ForEach(p => { p.LoadAllSequence(); });
            }
            return cs;
        }

        public CustomSequence() { }

        public CustomSequence(string name) 
        {
            CustomName = name;
        }

        public void Add(string name)
        {
            cfh.Add(CustomSequenceNames,name);
        }

        public void Remove()
        {
            //删名字
            cfh.Remove(CustomSequenceNames,CustomName);
            //删顺序
            cfh.Delete(CustomName);
        }

        public void AddSequence(string value)
        {
            cfh.Add(CustomName, value);
        }

        public void RemoveSequence(string value)
        {
            cfh.Remove(CustomName, value);
        }

        public void LoadAllSequence()
        {
            LstCodeSequence = new List<GameArea>();
            var value = cfh.GetValue(CustomName);
            if (!string.IsNullOrEmpty(value))
            {
               var lst = value.Split(',').ToList();
               lst.ForEach(p => { LstCodeSequence.Add(Consts.LstServer.FirstOrDefault(x => x.Code == p)); });
            }            
        }
    }
}
