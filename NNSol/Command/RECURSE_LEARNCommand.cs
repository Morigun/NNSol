/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 09/19/2017
 * Время: 09:55
 */
using System;
using System.Collections.Generic;
using System.Linq;
using NNSol.Core;

namespace NNSol.Command
{
	/// <summary>
	/// Description of RECURSE_LEARNCommand.
	/// </summary>
	public class RECURSE_LEARNCommand : ComLibTools.Command
	{
		public RECURSE_LEARNCommand(String name, int cntArg) : base(name, cntArg)
		{
		}
		
		public override void Execute()
		{
			Executor executor = new Executor();
			List<double> listErrors = new List<double>();
			Console.WriteLine("Please wait...");
			int num = 0;
			while(listErrors.Where(x => x > 0.01) != null)
			{
				listErrors.Clear();
				foreach(List<double> digits in NNCore.forRecursLearn)
				{
					NNCore.inData.Clear();
					for(int i = 0; i < digits.Count; i++)
					{
						if(i != digits.Count-1)
						{
							NNCore.inData.Add(digits[i]);
						}
						else
						{
							NNCore.nn.setIdeal(digits[i]);
						}
					}
					NNCore.nn.calcData(NNCore.inData);
					NNCore.nn.calcError();
					NNCore.nn.MOR();
					listErrors.Add(NNCore.nn.getError());
					if(num%100000 == 0)
					{
						NNCore.nn.printIn();
						NNCore.nn.printResult();
						NNCore.nn.printError();
					}
				}
				num++;
				if(num%100000 == 0)
				{								
					Console.WriteLine("Press comand to view info, continue or break");
					String com = Console.ReadLine().ToUpper();
					while(com != "CONTINUE" && com != "BREAK")
					{
						CommandParser.Parse(com, false);
						if(CommandParser.Command != null)
						{
							executor.setArguments(CommandParser.Command, CommandParser.Args);
							executor.execute(CommandParser.Command);
						}
						com = Console.ReadLine().ToUpper();
					}
					if(com == "BREAK")
							break;					
				}
			}
		}
		
		public override void setArgs(System.Collections.Generic.List<string> args)
		{
			base.setArgs(args);
		}
	}
}
