/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 09/19/2017
 * Время: 10:26
 */
using System;
using NNSol.Core;

namespace NNSol.Command
{
	/// <summary>
	/// Description of SERCommand.
	/// </summary>
	public class SERCommand : ComLibTools.Command
	{
		public SERCommand(String name, int cntArg) : base(name, cntArg)
		{
		}
		
		public override void Execute()
		{
			NNCore.nn.Serialize();
		}
		
		public override void setArgs(System.Collections.Generic.List<string> args)
		{
			base.setArgs(args);
		}
	}
}
