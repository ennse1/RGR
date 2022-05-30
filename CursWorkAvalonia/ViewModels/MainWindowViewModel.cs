using Avalonia.Media;
using Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using CursWorkAvalonia.Models;
using System.Collections.Specialized;
using CursWorkAvalonia;

// Основной класс в котором происходит заполнение всех отношений бд нашей инфой.

namespace CursWorkAvalonia.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        // создание методов для написания запроса к бд, чтобы считать всю информацию с нее и записать в контейнреы
        private Request _request;
        public Request SelectedRequest
        {
            get => _request;
            set => this.RaiseAndSetIfChanged(ref _request, value);
        }


        private ObservableCollection<Request> _requests;
        public ObservableCollection<Request> Requests
        {
            get => _requests;
            set => this.RaiseAndSetIfChanged(ref _requests, value);
        }

        //  создание контейнеров для хранения инфы из отношений бд

        public ObservableCollection<Coach> Coach { get; set; }
        public ObservableCollection<Hippodrome> Hippodrome { get; set; }
        public ObservableCollection<Horse> Horse { get; set; }
        public ObservableCollection<HorseHasCoach> HorseHasCoach { get; set; }
        public ObservableCollection<HorseHasJockey> HorseHasJockey { get; set; }
        public ObservableCollection<Jockey> Jockey { get; set; }
        public ObservableCollection<Owner> Owner { get; set; }
        public ObservableCollection<Race> Race { get; set; }

        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public MainWindowViewModel()
        {
            using (var db = new NewDataContext())
            {
                // собственно процесс создания нового контейнера и переноса в него инфы из бд для каждого отношения
                this.Coach = new ObservableCollection<Coach>(db.Coaches);
                this.Hippodrome = new ObservableCollection<Hippodrome>(db.Hippodromes);
                this.Horse = new ObservableCollection<Horse>(db.Horses);
                this.HorseHasCoach = new ObservableCollection<HorseHasCoach>(db.HorseHasCoaches);
                this.HorseHasJockey = new ObservableCollection<HorseHasJockey>(db.HorseHasJockeys);
                this.Jockey = new ObservableCollection<Jockey>(db.Jockeys);
                this.Owner = new ObservableCollection<Owner>(db.Owners);
                this.Race = new ObservableCollection<Race>(db.Races);
            }
            Content = new DataBaseViewModel();
            Requests = new ObservableCollection<Request>()
            {
                new Request("1"),
                new Request("2")
            };


        }
        public void CreateRequest()
        {
            Requests.Add(new Request("New request"));
        }
        public void DeleteRequest(Request e)
        {
            Requests.Remove(e);
        }
        public void SQLRequestOpen()
        {
            Content = new SQLRequestViewModel();
        }

        // методы удаления кортежа (строки) отношения 
        public void DeleteCoach(Coach entity) => Coach.Remove(entity);
        public void DeleteHippodrome(Hippodrome entity) => Hippodrome.Remove(entity);
        public void DeleteHorse(Horse entity) => Horse.Remove(entity);
        public void DeleteHorseHasCoach(HorseHasCoach entity) => HorseHasCoach.Remove(entity);
        public void DeleteHorseHasJockey(HorseHasJockey entity) => HorseHasJockey.Remove(entity);
        public void DeleteJockey(Jockey entity) => Jockey.Remove(entity);
        public void DeleteOwner(Owner entity) => Owner.Remove(entity);
        public void DeleteRace(Race entity) => Race.Remove(entity);

        // методы добавления кортежа (строки) отношниея
        public void CreateCoach() => Coach.Add(new Coach() { CoachId = 0, Name = "0", Nationality = "0" });
        public void CreateHippodrome() => Hippodrome.Add(new Hippodrome() { Hippodrome1  = 0, Title = "new", PathLengthFur = "new" });
        public void CreateHorse() => Horse.Add(new Horse() { HorseId = 0, Name = "new", Rating = 0, Breed = "0", OwnerId = 0, RaceId = 0 });
        public void CreateHorseHasCoach() => HorseHasCoach.Add(new HorseHasCoach() { HorseId = 0, CoachId = 0 });
        public void CreateHorseHasJockey() => HorseHasJockey.Add(new HorseHasJockey() { HorseId = 0, JockeyId = 0 });
        public void CreateJockey() => Jockey.Add(new Jockey { JockeyId = 0, Name = "new", Nationality = "new", Income = 0 });
        public void CreateOwner() => Owner.Add(new Owner() { OwnerId = 0, Income = 0, Title = "new" });
        public void CreateRace() => Race.Add(new Race { RaceId = 0, Data = "new", Winner = "new" });
        public void SQLRequestRun()
        {

            using (var db = new NewDataContext())
            {

            }
            Content = new DataBaseViewModel();
        }
    }
}
