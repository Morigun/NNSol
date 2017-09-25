/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 07/21/2017
 * Время: 11:47
 */
using System;
using NNSol.NClass;
using System.Collections.Generic;

namespace NNSol.NClass.Neurons
{
	[Serializable]
	public class OutNeuron : INeuron
	{
		private double _outData;
		private double _inData;
		private double _delta;
		private List<Synapse> _inSynapse;
		
		public OutNeuron()
		{
			_inSynapse = new List<Synapse>();
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
		
		public double getOutData()
		{
			return this._outData;
		}
		
		public void addInSynapse(Synapse synapse)
		{
			this._inSynapse.Add(synapse);
		}
		
		public void addOutSynapse(Synapse synapse)
		{
			throw new NotImplementedException();
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
			_delta = (val - _outData) * derivative(_outData);
			foreach(Synapse s in _inSynapse)
			{
				s.grad();
				s.newWeight();
			}
		}
		
		public double getDelta()
		{
			return _delta;
		}
		
		public string getSynapseWeight()
		{
			throw new NotImplementedException();
		}
	}
}
