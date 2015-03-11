using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MyScripts.MotionLib
{

    /*************************************************
     * Autor: Davi Salles
     * Função: Classe que extende um listener para
     * testar o funcionamento do mesmo
     * ***********************************************/

    public class Acelerometro : NunchuckListener
    {


        public Text text;

        void Start()
        {

        }

        void Update()
        {

        }

        public override void Listener(NunchuckData nunchuckData)
        {
			text.text = nunchuckData.Acelerometro.X + " - " + nunchuckData.Acelerometro.Y + " - " + nunchuckData.Acelerometro.Z;
		}
    }
}
