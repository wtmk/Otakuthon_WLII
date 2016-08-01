using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Otakuthon_App.Model
{
    public class Video : INotifyPropertyChanged
    {

        string _AnimeName;
        public string AnimeName
        {
            get
            {
                return _AnimeName;
            }
            set
            {
                if (_AnimeName != value)
                {
                    _AnimeName = value;
                    RaisePropertyChanged("AnimeName");
                }
            }
            
        }

        string _AnimeGenre;
        public string AnimeGenre
        {
            get
            {
                return _AnimeGenre;
            }
            set
            {
                if (_AnimeGenre != value)
                {
                    _AnimeGenre = value;
                    RaisePropertyChanged("AnimeGenre");
                }
            }

        }

        string _Character;
        public string Character
        {
            get
            {
                return _Character;
            }
            set
            {
                if (_Character != value)
                {
                    _Character = value;
                    RaisePropertyChanged("Character");
                }
            }
        }
        string _Voice_Actor;
        public string Voice_Actor
        {
            get
            {
                return _Voice_Actor;
            }
            set
            {
                if (_Voice_Actor != value)
                {
                    _Voice_Actor = value;
                    RaisePropertyChanged("Voice_Actor");
                }
            }
        }

        string _Filename;
        public string Filename
        {
            get
            {
                return _Filename;
            }
            set
            {
                if (_Filename != value)
                {
                    _Filename = value;
                    RaisePropertyChanged("Filename");
                }
            }
        }

        string _Anime_image;
        public string Anime_image
        {
            get
            {
                return _Anime_image;
            }
            set
            {
                if (_Anime_image != value)
                {
                    _Anime_image = value;
                    RaisePropertyChanged("Anime_image");
                }
            }
        }

        string _Is_used;
        public string Is_used
        {
            get
            {
                return _Is_used;
            }
            set
            {
                if (_Is_used != value)
                {
                    _Is_used = value;
                    RaisePropertyChanged("Is_used");
                }
            }
        }

        bool _Is_played;
        public bool Is_played
        {
            get
            {
                return _Is_played;
            }
            set
            {
                if (_Is_played != value)
                {
                    _Is_played = value;
                    RaisePropertyChanged("Is_played");
                }
            }
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
