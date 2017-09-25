/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 09/18/2017
 * Время: 15:59
 */
using System;
using ComLibTools;

namespace NNSol.Command
{
	/// <summary>
	/// Description of HELPCommand.
	/// </summary>
	public class HELPCommand : ComLibTools.Command
	{
		public HELPCommand(String name, int cntArg) : base(name, cntArg)
		{
		}
		
		public override void Execute()
		{
			Console.WriteLine("LEARN - обучить сеть на основании текущей ошибки");
			Console.WriteLine("CALC - произвести рассчет по текущим входным данным");
			Console.WriteLine("RECURSE_LEARN - обучение на всех возможных данных, до получения ошибки менее или равной 0.01, с остановкой каждые 10000 итераций");
			Console.WriteLine("CALC [in1] [in2] [ideal] - рассчет на основе входящих чисел и идеального значения");
			Console.WriteLine("SKIP_INFO - Скрывает отладочную инфомацию");
			Console.WriteLine("VIEW_INFO - Скрывает отладочную инфомацию");
			Console.WriteLine("SER - Сохранить текущее состояние нейронной сети");
			Console.WriteLine("DESER - Загрузить последнее сохраненное состояние нейронной сети");
		}
		
		public override void setArgs(System.Collections.Generic.List<string> args)
		{
			base.setArgs(args);
		}
	}
}
