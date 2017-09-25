/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 09/18/2017
 * Время: 16:05
 */
using System;
using ComLibTools;
using NNSol.Core;

namespace NNSol.Command
{
	/// <summary>
	/// Description of LEARNCommand.
	/// </summary>
	public class LEARNCommand : ComLibTools.Command
	{
		public LEARNCommand(String name, int cntArg) : base(name, cntArg)
		{
		}
		
		public override void Execute()
		{
			NNCore.nn.MOR();
		}
		
		public override void setArgs(System.Collections.Generic.List<string> args)
		{
			base.setArgs(args);
		}
	}
}
