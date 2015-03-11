using System.Collections.Generic;
namespace Assets.Scripts.MyScripts.MotionLib
{

    /*************************************************
     * Autor: Davi Salles
     * Função: Armazenar informações do nunchuck
     * ***********************************************/

    public class NunchuckData
    {
        // Lista de informações do nunchuck
        const int MAX_QUEUE_DATA = 50;                           // Quantidade máxima do histórico de dados do nunchuck
        public static Queue<NunchuckData> nunchuckQueue =      // Fila do histórico do nunchuck
            new Queue<NunchuckData>();

        // Variáveis de informação do estado do nunchuck
        public AnalogInfo Analog {get; set;}
        public ButtonInfo Button {get; set;}
        public AcelerometroInfo Acelerometro {get; set;}
         
        // Função de inicio da classe
        public NunchuckData()
        {
            Analog = new AnalogInfo();
            Button = new ButtonInfo();
            Acelerometro = new AcelerometroInfo();

            // Remove o item sobrando na lista
            if (nunchuckQueue.Count == MAX_QUEUE_DATA)
            {
                nunchuckQueue.Dequeue();
            }

            // Adiciona a nova informação do nunchuck na lista
            nunchuckQueue.Enqueue(this);
        }

        // Classe que representa as informações do analógico
        public class AnalogInfo {

			// Informaçoes de valores do hardware
			public const int INIT_X = 125;
			public const int INIT_Y = 129;

            // Métodos getters and setters do objeto
            public int X { get; set; }                  // Posição x do analógico
            public int Y { get; set; }                  // Posição y do analógico
            
        }

        // Classe que representa as informações do acelerômetro
		public class AcelerometroInfo
        {

            // Métodos getters and setters do objeto
            public int X { get; set; }                        // Posição x do acelerômetro
            public int Y { get; set; }                        // Posição y do acelerômetro
            public int Z { get; set; }                        // Posição z do acelerômetro

        }

        // Classe que representa as informações do botão C e Z
		public class ButtonInfo
        {

            // Métodos getters and setters do objeto
            public bool C { get; set; }                        // Retorna verdadeiro se o botão estiver clicado
            public bool Z { get; set; }                        // Retorna verdadeiro se o botão estiver clicado

        }

    }
}
