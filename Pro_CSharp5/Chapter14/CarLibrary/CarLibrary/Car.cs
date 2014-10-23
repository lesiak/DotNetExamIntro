using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace CarLibrary
{
    public enum EngineState {
        EngineAlive, EngineDead
    }

    public enum MusicMedia {
        CD,
        Tape,
        Radio,
        Mp3
    }

    public abstract class Car {
        
        public string PetName { get; set; }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }

        protected EngineState engState = EngineState.EngineAlive;
        
        public EngineState EngineState {
            get { return engState; }            
        }

        public abstract void TurboBoost();

        public Car() {
            MessageBox.Show("Car2 library version 2.0");
        }

        public Car(string name, int maxSp, int currSp) {
            MessageBox.Show("Car2 library version 2.0");
            PetName = name;
            MaxSpeed = maxSp;
            CurrentSpeed = currSp;
        }

        public void TurnOnRadio(bool musicOn, MusicMedia mm) {
            if (musicOn) {
                MessageBox.Show(string.Format("jamming {0}", mm));
            } else {
                MessageBox.Show("Quiet time");
            }
        }
        
    }
}
