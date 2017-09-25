/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 07/21/2017
 * Время: 10:54
 */
using System;
using System.Collections.Generic;
using NNSol.NClass.Neurons;

namespace NNSol.NClass
{
	/// <summary>
	/// Description of NeuronLayer.
	/// </summary>
	[Serializable]
	public class NeuronLayer
	{
		private List<INeuron> _neurons;
		public List<INeuron> Neurons
		{
			get{return this._neurons;}
			private set{this._neurons = value;}
		}
		public NeuronLayer()
		{
			_neurons = new List<INeuron>();
		}
		
		public void AddNeuron(INeuron neuron)
		{
			this._neurons.Add(neuron);
		}
		
		public void insertData(List<double> param)
		{
			int numNeuron = 0;
			foreach(double d in param)
			{
				if(!(_neurons[numNeuron] is BiasNeuron))
					_neurons[numNeuron++].setInData(d);
			}
		}
		
		public void normalize()
		{
			foreach(INeuron n in _neurons)
			{
				if(n.GetType() != Type.GetType("NNSol.NClass.Neurons.BiasNeuron"))
					n.normalize();
			}
		}
		
		public void activation()
		{
			foreach(INeuron n in _neurons)
			{
				if(n.GetType() != Type.GetType("NNSol.NClass.Neurons.BiasNeuron"))
					n.activation();
			}
		}
		
		public double getResult()
		{
			foreach(INeuron n in _neurons)
			{
				return n.getOutData();
			}
			return 666;
		}
	}
}
