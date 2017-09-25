/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 07/20/2017
 * Время: 10:50
 */
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ComLibTools.Entityes;
using NNSol.Command;
using NNSol.Core;
using NNSol.NClass;
using NNSol.NClass.Neurons;

namespace NNSol
{
	class Program
	{
		public static void Main(string[] args)
		{			
			List<int> hiddenLayout = new List<int>();
			hiddenLayout.Add(2);
			NNCore.initNeuroNer(2,1,hiddenLayout,true);
			List<double> inData = new List<double>();
			inData.Add(1);
			inData.Add(0);
			NNCore.inData = inData;
			Executor executor = new Executor();
			Console.WriteLine("Press any command to continue . . . ");
			string command = Console.ReadLine().ToUpper();
			while(command != "EXIT")
			{
				try
				{
					CommandParser.Parse(command);
					executor.setArguments(CommandParser.Command, CommandParser.Args);
					executor.execute(CommandParser.Command);
				}
				catch(NullReferenceException ex)
				{
					Console.WriteLine("Не найдена команда: {0}; Error: {1}",command, ex.Message);
				}
				command = Console.ReadLine().ToUpper();
			}
		}
	}
}