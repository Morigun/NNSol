/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 07/21/2017
 * Время: 11:44
 */
using System;
using System.Collections.Generic;
using NNSol.NClass;

namespace NNSol.NClass.Neurons
{
	[Serializable]
	public class HiddenNeuron : INeuron
	{
		private double _outData;
		private double _inData;
		private double _delta;
		private List<Synapse> _inSynapse;
		private List<Synapse> _outSynapse;
		
		public HiddenNeuron()
		{
			_inSynapse = new List<Synapse>();
			_outSynapse = new List<Synapse>();
		}
		
		public void normalize()
		{
			double sum = 0;
			foreach(Synapse s in _inSynapse)
			{
				sum = sum + (s.Weight * s.InNeuron.getOutData());				
			}
			_outData = sum;
		}
		
		public void activation()
		{
			_outData = 1/(1+Math.Pow(Math.E,(_outData*-1)));
		}
		
		public void setInData(double inData)
		{
			this._inData = inData;
		}
		
		public void setOutData(double outData)
		{
			this._outData = outData;
		}
		
		public void addInSynapse(Synapse synapse)
		{
			_inSynapse.Add(synapse);
		}
		
		public void addOutSynapse(Synapse synapse)
		{
			_outSynapse.Add(synapse);
		}
		
		public double getOutData()
		{
			return this._outData;
		}
		
		public double getInData()
		{
			return this._inData;
		}
		
		public double derivative(double val)
		{
			return (1 - val) * val;
		}
		
		public void delta(double val)
		{
			_delta = 0;
			for(int i = 0; i < this._outSynapse.Count; i++)
				_delta = _delta + (_outSynapse[i].Weight * _outSynapse[i].OutNeuron.getDelta());
			_delta = derivative(this._outData) * _delta;
			foreach(Synapse s in _inSynapse)
			{
				s.grad();
				s.newWeight();
			}			
		}
		
		public double getDelta()
		{
			return this._delta;
		}
		
		public string getSynapseWeight()
		{
			string res = "";
			foreach(Synapse s in _outSynapse)
			{
				res = res + s.Weight + ";";
			}
			return res;
		}
	}
}
