/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 09/18/2017
 * Время: 16:07
 */
using System;
using System.Collections.Generic;
using NNSol.NClass;
using NNSol.NClass.Neurons;

namespace NNSol.Core
{
	/// <summary>
	/// Description of NNCore.
	/// </summary>
	public class NNCore
	{
		public static NeuroNet nn;
		public static List<double> inData;
		public static List<List<double>> forRecursLearn;
		
		public static void initNeuroNer(int countInNeurons, int countOutNeurons, List<int> countHiddenNeurons, bool bias = false)
		{
			NNCore.nn = new NeuroNet(countInNeurons,countOutNeurons,countHiddenNeurons, bias);
			NNCore.nn.Initialize();
			initVars();
		}
		
		static void initVars()
		{
			forRecursLearn = new List<List<double>>();
			List<double> firstDigits = new List<double>();
			firstDigits.Add(0);
			firstDigits.Add(0);
			firstDigits.Add(0);
			List<double> secondDigits = new List<double>();
			secondDigits.Add(0);
			secondDigits.Add(1);
			secondDigits.Add(1);
			List<double> thridDigits = new List<double>();
			thridDigits.Add(1);
			thridDigits.Add(0);
			thridDigits.Add(1);
			List<double> fourDigits = new List<double>();
			fourDigits.Add(1);
			fourDigits.Add(1);
			fourDigits.Add(0);
			forRecursLearn.Add(firstDigits);
			forRecursLearn.Add(secondDigits);
			forRecursLearn.Add(thridDigits);
			forRecursLearn.Add(fourDigits);
		}
		
		public static void setInParam(List<double> param)
		{
			inData = param;
			
			nn.calcData(inData);
		}
	}
}
