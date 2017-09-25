/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 09/19/2017
 * Время: 11:26
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using ComLibTools.Entityes;

namespace NNSol
{
	/// <summary>
	/// Description of CommandParser.
	/// </summary>
	public class CommandParser
	{
		public static ACommand Command;
		public static List<string> Args;
		
		public static void Parse(string command, bool error = true)
		{
			Command = null;
			Args = command.Split(' ').ToList();
			try
			{
				if(Args[0] != String.Empty)
				{
					Type ac = Type.GetType(new StringBuilder("NNSol.Command.").Append(Args[0]).Append("Command").ToString(), false, true);
					ConstructorInfo ct = ac.GetConstructor((new[] {Type.GetType("System.String"), Type.GetType("System.Int32")}));
					CommandParser.Command = ct.Invoke(new Object[]{Args[0], 1}) as ACommand;
				}
			}
			catch(NullReferenceException ex)
			{
				if(error)
					throw ex;
			}
		}
	}
}
