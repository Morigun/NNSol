/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 09/19/2017
 * Время: 10:24
 */
using System;
using NNSol.NClass;

namespace NNSol.Command
{
	/// <summary>
	/// Description of VIEW_INFOCommand.
	/// </summary>
	public class VIEW_INFOCommand : ComLibTools.Command
	{
		public VIEW_INFOCommand(String name, int cntArg) : base(name, cntArg)
		{
		}
		
		public override void Execute()
		{
			NeuroNet.SkipInfo = false;
		}
		
		public override void setArgs(System.Collections.Generic.List<string> args)
		{
			base.setArgs(args);
		}
	}
}
