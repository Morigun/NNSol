/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 09/18/2017
 * Время: 15:54
 */
using System;
using ComLibTools.Interfaces;

namespace NNSol.Command
{
	/// <summary>
	/// Description of Executor.
	/// </summary>
	public class Executor : IExecutor
	{
		public Executor()
		{
		}
		
		public void execute(ComLibTools.Entityes.ACommand command)
		{
			if(command != null)
				command.Execute();
		}
		
		public void setArguments(ComLibTools.Entityes.ACommand command, System.Collections.Generic.List<string> Args)
		{
			if(command != null)
				command.setArgs(Args);
		}
	}
}
