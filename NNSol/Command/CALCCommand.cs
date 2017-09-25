/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 09/19/2017
 * Время: 09:58
 */
using System;
using NNSol.Core;

namespace NNSol.Command
{
	/// <summary>
	/// Description of CALCCommand.
	/// </summary>
	public class CALCCommand : ComLibTools.Command
	{
		public CALCCommand(String name, int cntArg) : base(name, cntArg)
		{
		}
		
		public override void Execute()
		{
			printIn();
			NNCore.nn.calcData(NNCore.inData);
			NNCore.nn.calcError();
			NNCore.nn.printResult();
			NNCore.nn.printError();
		}
		
		static void printIn()
		{
			Console.Write("In: ");
			for(int i = 0; i < NNCore.inData.Count; i++)
			{
				Console.Write(NNCore.inData[i] + ";");
			}
			Console.WriteLine();
		}
		
		public override void setArgs(System.Collections.Generic.List<string> args)
		{
			base.setArgs(args);
			NNCore.inData.Clear();
			if(args.Count > 1)
			{
				NNCore.inData.Add(Double.Parse(args[1]));
				NNCore.inData.Add(Double.Parse(args[2]));
				NNCore.nn.setIdeal(Double.Parse(args[3]));
			}
		}
	}
}
