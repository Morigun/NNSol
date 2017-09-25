/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 07/21/2017
 * Время: 11:02
 */
using System;
using System.Collections.Generic;
using NNSol.NClass;

namespace NNSol.NClass
{
	/// <summary>
	/// Description of INeuron.
	/// </summary>
	public interface INeuron
	{
		void normalize();
		void activation();
		void delta(double val);
		double derivative(double val);
		double getDelta();
		double getOutData();
		double getInData();		
		void setInData(double inData);
		void setOutData(double outData);		
		void addInSynapse(Synapse synapse);
		void addOutSynapse(Synapse synapse);
		string getSynapseWeight();
	}
}
