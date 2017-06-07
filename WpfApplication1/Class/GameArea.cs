using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolForDan
{
    public class GameArea
    {
        private static string GameAreas = "GameAreas";

        private static ConfigHelper cfh = new ConfigHelper();

        public static List<GameArea> GetSelectedGameAreas()
        {
            List<GameArea> ga = new List<GameArea>();
            var value = cfh.GetValue(GameAreas);
            if (!string.IsNullOrEmpty(value))
            {
                value.Split(',').ToList().ForEach(p =>
                {
                    ga.Add(Consts.LstServer.FirstOrDefault(x=>x.Code==p));
                });

            }
            return ga;
        }

        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public GameArea() { }

        public GameArea(string code)
        {
            Code = code;
        }

        public void Add(string name)
        {
            cfh.Add(GameAreas, name);
        }

        public void RemoveByCode()
        {
            cfh.Remove(GameAreas, Code);
        }

    }
}
