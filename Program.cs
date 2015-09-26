using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 3) { Console.WriteLine("Usage: <input filepath 1> <input filePath 2> <output filepath>"); return; }
			var oldCube = read(args[0]);
			var newCube = read(args[1]);
			var outputFilePath = args[2];

			foreach (var item in newCube.Values)
			{
				if (!oldCube.ContainsKey(item)) { oldCube.Add(item, item); }
				else { oldCube[item].Mask |= item.Mask; }
			}

			File.WriteAllLines(outputFilePath, oldCube.Select(d => d.Value.ToString()));
		}

		static Dictionary<Data, Data> read(string path)
		{
			var d = new Dictionary<Data, Data>();
			foreach (var line in File.ReadAllLines(path))
			{
				var parts = line.Split('\t');
				var data = new Data { Mask = int.Parse(parts[0]), Key = parts[1].Trim(), Parts = parts.Select(p => p.Trim()).ToList().GetRange(2, parts.Length - 2) };
				d.Add(data, data);
			}

			return d;
		}
	}

	class Data
	{
		public List<string> Parts { get; set; }
		public string Key { get; set; }
		public int Mask { get; set; }
		public override string ToString()
		{
			return string.Format("{0}\t{1}{2}", this.Mask, this.Key, Parts.Aggregate(string.Empty, (acc, part) => acc + "\t" + part));
		}
		public override int GetHashCode()
		{
			return this.Key.GetHashCode();
		}
		public override bool Equals(object obj)
		{
			return this.Key.Equals(((Data)obj).Key, StringComparison.InvariantCultureIgnoreCase);
		}
	}
}
