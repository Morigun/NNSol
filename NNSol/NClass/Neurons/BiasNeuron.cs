/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 08/10/2017
 * Время: 09:19
 */
using System;
using System.Collections.Generic;

namespace NNSol.NClass.Neurons
{
	[Serializable]
	public class BiasNeuron : INeuron
	{
		private List<Synapse> _outSynapse;
		private double _outData;
		private double _delta;
		public BiasNeuron()
		{
			_outSynapse = new List<Synapse>();
		}
		
		public void normalize()
		{
			_outData = 1;
		}
		
		public void activation()
		{
			throw new NotImplementedException();
		}
		
		public void delta(double val)
		{
			_delta = 0;
			for(int i = 0; i < this._outSynapse.Count; i++)
				_delta = _delta + (_outSynapse[i].Weight * _outSynapse[i].OutNeuron.getDelta());
			_delta = derivative(this._outData) * _delta;
		}
		
		public double derivative(double val)
		{
			return (1 - val) * val;
		}
		
		public double getDelta()
		{
			return this._delta;
		}
		
		public double getOutData()
		{
			return this._outData;
		}
		
		public double getInData()
		{
			throw new NotImplementedException();
		}
		
		public void setInData(double inData)
		{
			throw new NotImplementedException();
		}
		
		public void setOutData(double outData)
		{
			throw new NotImplementedException();
		}
		
		public void addInSynapse(Synapse synapse)
		{
			throw new NotImplementedException();
		}
		
		public void addOutSynapse(Synapse synapse)
		{
			_outSynapse.Add(synapse);
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
