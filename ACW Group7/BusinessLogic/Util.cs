using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
	public class Util
	{
		/// <summary>
		/// Generates a new guid
		/// </summary>
		/// <returns>Guid</returns>
		public static Guid generateGuid()
		{
			Guid g;
			g = Guid.NewGuid();
			return g;
		}
		/// <summary>
		/// Converts a List<string> to a string
		/// </summary>
		/// <param name="list"></param>
		/// <returns>string</returns>
		public static string GetStringFromList(List<string> list)
		{
			return String.Join(",", list.ToArray());
		}
		/// <summary>
		/// Converts a string into a List<string>
		/// </summary>
		/// <param name="str"></param>
		/// <returns>List<string></returns>
		public static List<string> GetListFromString(string str)
		{
			return str.Split(',').ToList();
		}
	}
}