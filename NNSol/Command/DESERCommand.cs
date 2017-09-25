/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 09/19/2017
 * Время: 10:31
 */
using System;
using NNSol.Core;

namespace NNSol.Command
{
	/// <summary>
	/// Description of DESERCommand.
	/// </summary>
	public class DESERCommand : ComLibTools.Command
	{
		public DESERCommand(String name, int cntArg) : base(name, cntArg)
		{
		}
		
		public override void Execute()
		{
			NNCore.nn.Deserialize();
		}
		
		public override void setArgs(System.Collections.Generic.List<string> args)
		{
			base.setArgs(args);
		}
	}
}
