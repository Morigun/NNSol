/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 09/19/2017
 * Время: 10:22
 */
using System;
using NNSol.NClass;

namespace NNSol
{
	/// <summary>
	/// Description of SKIP_INFOCommand.
	/// </summary>
	public class SKIP_INFOCommand : ComLibTools.Command
	{
		public SKIP_INFOCommand(String name, int cntArg) : base(name, cntArg)
		{
		}
		
		public override void Execute()
		{
			NeuroNet.SkipInfo = true;
		}
		
		public override void setArgs(System.Collections.Generic.List<string> args)
		{
			base.setArgs(args);
		}
	}
}
