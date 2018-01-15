
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Man> mans = new List<Man>();
            mans.Add(new Man { Id = 1, Name = "spikie" });
            mans.Add(new Man { Id = 2, Name = "xiaolizi" });
            Mapper.Initialize(cfg => cfg.CreateMap<Man, Women>().ForMember(a => a.WomanId, b => b.MapFrom(c => c.Id)));
            List<Women> listDest = Mapper.Map<List<Man>, List<Women>>(mans);
            foreach (var item in listDest)
            {
                Console.WriteLine(item.WomanId + " " + item.Name);
            }
            Console.Read();
        }
    }
    public class Man
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Women
    {
        public int WomanId { get; set; }
        public string Name { get; set; }
    }
}
