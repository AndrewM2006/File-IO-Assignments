using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_IO_Assignments
{
    class EventScore : IComparable<EventScore>
    {
        private string _name;
        private string _event;
        private List<double> _score;

        public EventScore (string  name, string talent, List<double> Score)
        {
            this._name = name.Trim();
            this._event = talent.Trim();
            this._score = Score;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                this._name = value;
            }
        }

        public string Event
        {
            get
            {
                return _event;
            }
            set
            {
                this._event = value;
            }
        }

        public List<double> Score
        {
            get
            {
                return _score;
            }
            set
            {
                this._score = value;
            }
        }

        public double GetTotalScore()
        {
            return Score.Sum();
        }

        public double GetAverage()
        {
            return Score.Average();
        }

        public override string ToString()
        {
            return _name + " showed skills in " + _event + " and recieved a score of " + GetTotalScore() + "/50";
        }

        public int CompareTo(EventScore that)
        {
            return this ._score.Sum().CompareTo(that._score.Sum());
        }
    }
}
