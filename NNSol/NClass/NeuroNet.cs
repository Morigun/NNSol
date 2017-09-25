/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 07/20/2017
 * Время: 17:59
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using NNSol.NClass;
using NNSol.NClass.Neurons;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace NNSol.NClass
{
	/// <summary>
	/// Description of NeuroNet.
	/// </summary>
	public class NeuroNet
	{
		private NeuronLayer inLayer;
		private List<NeuronLayer> hiddenLayers;
		private NeuronLayer outLayer;
		private bool _bias = false;
		public static bool SkipInfo = false;
		private static double _speed = 0.7;
		public static double Speed
		{
			get {return _speed; }
			private set {_speed = value;}
		}		 
		private static double _moment = 0.3;
		public static double Moment
		{
			get{return _moment;}
			private set{_moment = value;}
		}
		private double _result;
		private double _ideal;
		private double _error;
		private int _countInNeurons = 0;
		private int _countOutNeurons = 0;
		private List<int> _countHiddenNeurons;
		public NeuroNet(int countInNeurons, int countOutNeurons, List<int> countHiddenNeurons, bool bias = false)
		{
			_countHiddenNeurons = countHiddenNeurons;
			_countInNeurons = countInNeurons;
			_countOutNeurons = countOutNeurons;
			_bias = bias;
			inLayer = new NeuronLayer();
			hiddenLayers = new List<NeuronLayer>();
			outLayer = new NeuronLayer();
		}
		
		public void Initialize()
		{
			/*Инициализация скрытых слоев*/
			for(int i = 0; i < _countHiddenNeurons.Count; i++)
			{
				hiddenLayers.Add(new NeuronLayer());
			}
			/*Инициализация нейронов входного слоя*/
			for(int i = 0; i < _countInNeurons; i++)
			{
				inLayer.AddNeuron(new InNeuron());
			}
			if(_bias)
				inLayer.AddNeuron(new BiasNeuron());
			/*Инициализация нейронов скрытого слоя*/
			for(int i = 0; i < _countHiddenNeurons.Count; i++)
			{
				for(int j = 0; j < _countHiddenNeurons[i]; j++)
				{
					hiddenLayers[i].AddNeuron(new HiddenNeuron());
				}
				if(_bias)
					hiddenLayers[i].AddNeuron(new BiasNeuron());
			}
			/*Соединение входного слоя с первым скрытым*/
			for(int i = 0; i < inLayer.Neurons.Count; i++)
			{
				for(int j = 0; j < hiddenLayers[0].Neurons.Count; j++)
				{
					if(hiddenLayers[0].Neurons[j].GetType() != Type.GetType("NNSol.NClass.Neurons.BiasNeuron"))
					{
						Synapse synapse = new Synapse();
						inLayer.Neurons[i].addOutSynapse(synapse);
						synapse.InNeuron = inLayer.Neurons[i];
						hiddenLayers[0].Neurons[j].addInSynapse(synapse);
						synapse.OutNeuron = hiddenLayers[0].Neurons[j];
					}
				}
			}
			/*Соединяем скрытые слои между собой*/
			if(hiddenLayers.Count > 1)
			{
				for(int i = 0; i < hiddenLayers.Count-1; i++)
				{
					for(int j = 0; j < hiddenLayers[i].Neurons.Count; j++)
					{
						if(hiddenLayers[i+1].Neurons[j].GetType() != Type.GetType("NNSol.NClass.Neurons.BiasNeuron"))
						{
							Synapse synapse = new Synapse();
							hiddenLayers[i].Neurons[j].addOutSynapse(synapse);
							synapse.InNeuron = hiddenLayers[i].Neurons[j];
							hiddenLayers[i+1].Neurons[j].addInSynapse(synapse);
							synapse.OutNeuron = hiddenLayers[i+1].Neurons[j]; 
						}
					}
				}
			}
			/*Инициализация нейронов выходного слоя*/
			for(int i = 0; i < _countOutNeurons; i++)
			{				
				outLayer.AddNeuron(new OutNeuron());
				
			}
			/*Соединение крайнего скрытого слоя с выходным слоем*/
			for(int i = 0; i < hiddenLayers[hiddenLayers.Count-1].Neurons.Count; i++)
			{
				for(int j = 0; j < _countOutNeurons; j++)
				{
					Synapse synapse = new Synapse();
					hiddenLayers[hiddenLayers.Count-1].Neurons[i].addOutSynapse(synapse);
					synapse.InNeuron = hiddenLayers[hiddenLayers.Count-1].Neurons[i];
					outLayer.Neurons[j].addInSynapse(synapse);
					synapse.OutNeuron = outLayer.Neurons[j]; 
				}
			}
		}
		
		public void Serialize()
		{
			Dictionary<String, NeuronLayer> neuronLayers = new Dictionary<String, NeuronLayer>();
			neuronLayers.Add("In", inLayer);
			int i = 0;
			foreach(NeuronLayer n in hiddenLayers)
				neuronLayers.Add("Hidden"+(i++), n);
			neuronLayers.Add("Out", outLayer);
			FileStream fs = new FileStream("NeuronLayers.dat", FileMode.Create);
			BinaryFormatter formatter = new BinaryFormatter();
			try
			{
				formatter.Serialize(fs, neuronLayers);
			}
			catch(SerializationException e)
			{
				Console.WriteLine("Failed to serialize. Reason: " + e.Message);
            	throw;
			}
			finally
			{
				fs.Close();
			}
		}
		
		public void Deserialize()
		{
			Dictionary<String, NeuronLayer> neuronLayers = null;
			FileStream fs = new FileStream("NeuronLayers.dat", FileMode.Open);
			try 
        	{
            	BinaryFormatter formatter = new BinaryFormatter();
            	neuronLayers = (Dictionary<String, NeuronLayer>) formatter.Deserialize(fs);
			}
			catch (SerializationException e) 
	        {
	            Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
	            throw;
	        }
	        finally 
	        {
	            fs.Close();
	        }
	        inLayer = (NeuronLayer)neuronLayers["In"];
	        foreach(KeyValuePair<String, NeuronLayer> n in neuronLayers.Where(z=> z.Key.Contains("Hidden")).OrderBy(z=>z.Key))
	        {
	        	hiddenLayers.Add(n.Value);
	        }
	        outLayer = (NeuronLayer)neuronLayers["Out"];
		}
		
		public void setIdeal(double ideal)
		{
			this._ideal = ideal;
		}
		
		public void calcData(List<double> vals)
		{
			inLayer.insertData(vals);
			inLayer.normalize();
			foreach(NeuronLayer n in hiddenLayers){
				n.normalize();
				n.activation();
			}
			outLayer.normalize();
			outLayer.activation();
			_result = outLayer.getResult();
		}
		
		public void printResult()
		{
			if(!NeuroNet.SkipInfo)
				Console.WriteLine("Result: " + Math.Round(_result,7));
		}
		
		public void printError()
		{
			if(!NeuroNet.SkipInfo)
				Console.WriteLine("Error: " + Math.Round(_error,7));
		}
		public void printIn()
		{
			Console.Write("In: ");
			foreach(INeuron n in inLayer.Neurons)
			{
				if(!(n is BiasNeuron))
					Console.Write(n.getInData() + ";");
			}
			Console.WriteLine();
		}
		
		public void calcError()
		{
			_error = Math.Pow((this._ideal - _result),2)/1;			
		}
		
		public double getError()
		{
			return _error;
		}
		
		public void MOR()
		{
			foreach(INeuron n in outLayer.Neurons)
			{
				n.delta(this._ideal);				
			}
			foreach(NeuronLayer nl in hiddenLayers)
			{
				foreach(INeuron n in nl.Neurons)
				{
					n.delta(0);
				}
			}
			foreach(INeuron n in inLayer.Neurons)
			{
				n.delta(0);
			}
		}
		
		public void printWeight()
		{
			foreach(INeuron n in inLayer.Neurons)
			{
				Console.WriteLine(n.getSynapseWeight());
			}
			foreach(NeuronLayer nl in hiddenLayers)
			{
				foreach(INeuron n in nl.Neurons)
				{
					Console.WriteLine(n.getSynapseWeight());
				}
			}
		}
	}
}
