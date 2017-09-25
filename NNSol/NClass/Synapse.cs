/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 07/20/2017
 * Время: 11:03
 */
using System;
using System.Collections.Generic;

namespace NNSol.NClass
{
	[Serializable]
	public class Synapse
	{
		private static Random rnd = new Random(DateTime.Now.Millisecond);
		//private List<double> _deltaWeightHistory;
		private double _oldDeltaWeight;
		private int iter = 0;
		private double _grad;
		private double _weight;
		public double Weight
		{
			get{ return this._weight; }
		}
		
		private INeuron _inNeuron;
		public INeuron InNeuron
		{
			get{ return this._inNeuron; }
			set{ this._inNeuron = value; }
		}
		
		private INeuron _outNeuron;
		public INeuron OutNeuron
		{
			get{ return this._outNeuron; }
			set{ this._outNeuron = value; }
		}
		
		public void grad()
		{
			_grad = this.OutNeuron.getDelta() * this.InNeuron.getOutData();
			//Console.WriteLine("CALC GRAD " + _grad + " in neruon out data " + this.InNeuron.getOutData() + " out neuron delta " + this.OutNeuron.getDelta());
		}
				
		public void newWeight()
		{
			double nWeight;
			/*if(!NeuroNet.SkipInfo){
				if(iter != 0)
					Console.WriteLine("[SYNAPSE] Old weight = " + _deltaWeightHistory[iter-1]);
			}*/
			if(iter == 0)
				nWeight = NeuroNet.Speed * _grad + NeuroNet.Moment * 0;
			else
				nWeight = NeuroNet.Speed * _grad + NeuroNet.Moment * _oldDeltaWeight/*_deltaWeightHistory[iter-1]*/;
			_weight = _weight + nWeight;
			
			//_deltaWeightHistory.Add(nWeight);
			_oldDeltaWeight = nWeight;
			iter++;
		}
		
		public Synapse()
		{
			this._weight = rnd.Next(-10,10);
			_oldDeltaWeight = 0; 
			//_deltaWeightHistory = new List<double>();
		}
	}
}
