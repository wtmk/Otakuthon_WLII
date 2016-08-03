using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otakuthon_App.Model
{
    public class Game : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        string _scoreP1;
        public string ScoreP1
        {
            get
            {
                return _scoreP1;
            }
            set
            {
                if (_scoreP1 != value)
                {
                    _scoreP1 = value;
                    RaisePropertyChanged("ScoreP1");
                }
            }
        }

        string _scoreP2;
        public string ScoreP2
        {
            get
            {
                return _scoreP2;
            }
            set
            {
                if (_scoreP2 != value)
                {
                    _scoreP2 = value;
                    RaisePropertyChanged("ScoreP2");
                }
            }
        }

        string _scoreP3;
        public string ScoreP3
        {
            get
            {
                return _scoreP3;
            }
            set
            {
                if (_scoreP3 != value)
                {
                    _scoreP3 = value;
                    RaisePropertyChanged("ScoreP3");
                }
            }
        }

        string _scoreP4;
        public string ScoreP4
        {
            get
            {
                return _scoreP4;
            }
            set
            {
                if (_scoreP4 != value)
                {
                    _scoreP4 = value;
                    RaisePropertyChanged("ScoreP4");
                }
            }
        }

        string _roundPlayCount;
        public string roundPlayCount
        {
            get
            {
                return _roundPlayCount;
            }
            set
            {
                if (_roundPlayCount != value)
                {
                    _roundPlayCount = value;
                    RaisePropertyChanged("roundPlayCount");
                }
            }
        }
    }

}
