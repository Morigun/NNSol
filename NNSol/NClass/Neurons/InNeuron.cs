/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 07/21/2017
 * Время: 11:33
 */
using System;
using System.Collections.Generic;

namespace NNSol.NClass.Neurons
{
	[Serializable]
	public class InNeuron : INeuron
	{
		private double _outData;
		private double _inData;
		private double _delta;
		private List<Synapse> _outSynapse;
		
		public InNeuron()
		{
			_outSynapse = new List<Synapse>();
		}
		
		public void normalize()
		{		
			_outData = _inData;
		}
		
		public void activation()
		{
			throw new NotImplementedException();
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
			throw new NotImplementedException();
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
