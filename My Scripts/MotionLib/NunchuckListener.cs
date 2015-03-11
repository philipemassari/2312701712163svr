using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

namespace Assets.Scripts.MyScripts.MotionLib
{

    /*************************************************
     * Autor: Davi Salles
     * Função: Classe de listener do nunchuck, para 
     * poder usar, basta extender uma classe com essa
     * e em seguida reescrever a função Listener()
     * ***********************************************/

    public abstract class NunchuckListener : SAOBehaviour
    {

        // Variáveis de configuração do componente
        public string portSerial = "COM5";          // Nome da porta USB
        public int baunds = 9600;                   // Baund rate para a conexão
        public float segundosPorLeitura = 0.01F;    // Tempo demorado para cada leitura do nunchuck

        // Variáveis do sistema
        private static SerialPort stream = null;    // Stream criada para a comunicação
        public static List<NunchuckListener> listenerList = new List<NunchuckListener>();

        // Função chamada antes do Start para iniciar a comunicação
        void Awake()
        {
            // Inicia o canal se este for o primeiro listener
            if (stream == null || !stream.IsOpen) { 
                stream = new SerialPort(portSerial, baunds);
                stream.Open();
                listenerList.Clear();
                StartCoroutine(ReadStream());
            }

            // Adiciona o listener a lista
            listenerList.Add(this);
        }

        // Função que lê as informações do Nunchuck 
        static IEnumerator ReadStream()
        {
            while (true)
            {
                try
                {
                    // Faz a leitura da informação e converte para inteiro
                    string value = stream.ReadLine();
                    string[] dataString = value.Split('\t');
                    int[] data = new int[dataString.Length];

                    for (int i = 0; i < dataString.Length; i++)
                    {
                        int valueConverted = 0;
                        if (!int.TryParse(dataString[i], out valueConverted))
                            continue;

                        data[i] = valueConverted;
                    }

                    // Converte o vetor de inteiros para uma nunchuckData
                    NunchuckData nd = new NunchuckData();
                    nd.Analog.X = data[0]-NunchuckData.AnalogInfo.INIT_X;
					nd.Analog.Y = data[1]-NunchuckData.AnalogInfo.INIT_Y;
					
					nd.Acelerometro.X = data[2];
                    nd.Acelerometro.Y = data[3];
                    nd.Acelerometro.Z = data[4];

                    nd.Button.Z = !Convert.ToBoolean(data[5]);
                    nd.Button.C = !Convert.ToBoolean(data[6]);

                    // Implementa o novo NunchuckData em todos os listeners
                    foreach (NunchuckListener nl in listenerList)
                    {
                        nl.Listener(nd);
                    }

                    
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message + "\n" + e.StackTrace);
                }
                yield return new WaitForSeconds(0.01F);
            }
        }

		public NunchuckData[] fila{

			get{
				return NunchuckData.nunchuckQueue.ToArray();
			}

		}

        // Função chamada para quando o jogo fechar
        void OnApplicationQuit()
        {
            // Fecha a stream serial quando o game desligar
            if (stream != null || stream.IsOpen)    
            {
                stream.Close();
            }
        }

        /**
         * Listener do nunchuck abstrato. Ao implementar essa classe
         * esse listener deve ser reescrito e manuseado a partir do
         * argumento nunchuckData que representa as informações do 
         * nunchuck:
         * @param NunchuckData nunchuckData
         *          nunchuckData.Analog retornará informações do analógico       
         *          nunchuckData.Acelerometro retornará informações do acelerômetro
         *          nunchuckData.Button retornará informações dos dois botões
         **/
        public abstract void Listener(NunchuckData nunchuckData);

    }
}
