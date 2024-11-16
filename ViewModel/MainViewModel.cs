using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components.Web;

namespace Lendo_me
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly BoardService _boardService;

        [ObservableProperty]
        private bool _settingsButtonWasClicked = false;

        private string _backgroundColor = string.Empty;

        private short touchCount = 0;
        public string BackgroundColor
        {
            get => _backgroundColor;
            set => SetProperty(ref _backgroundColor, value);
        }

        public List<Board> BookOne { get; } = new();
        public List<Board> BookTwo { get; } = new();
        public List<Board> BookThree { get; } = new();
        public List<Board> BookFour { get; } = new();

        private List<Board> _currentBoardList = new();
        public List<Board> CurrentBoardList
        {
            get => _currentBoardList;
            set => SetProperty(ref _currentBoardList, value);
        }

        public MainViewModel(BoardService boardService)
        {
            _boardService = boardService;
            BackgroundColor = "#fcba03";
            CurrentBoardList = _boardService.Boards;
        }

        private System.Timers.Timer Timer;

        [RelayCommand]
        private void ButtonClicked(string? buttonName)
        {
            if (string.IsNullOrEmpty(buttonName))
                return;

            CurrentBoardList = buttonName switch
            {
                "generalBook" => _boardService.Boards,
                "bookOne" => BookOne,
                "bookTwo" => BookTwo,
                "bookThree" => BookThree,
                "bookFour" => BookFour,
                _ => CurrentBoardList
            };

            BackgroundColor = buttonName switch
            {
                "generalBook" => "#fcba03",
                "bookOne" => "#68b531",
                "bookTwo" => "#15b1e6",
                "bookThree" => "#aa1be3",
                "bookFour" => "#cf0c26",
                _ => BackgroundColor
            };


            if (buttonName.Equals("settings"))
            {
                if (Timer is null)
                {
                    Timer = new System.Timers.Timer(720);
                    Timer.Elapsed += ResetCounter;
                    Timer.AutoReset = false;
                }

                touchCount++;
                Timer.Stop();
                Timer.Start();

                if (touchCount is 5)
                {
                    touchCount = 0;
                    SettingsButtonWasClicked = true;
                    Timer.Stop();
                }
            }
        }



        private void ResetCounter(object? sender, System.Timers.ElapsedEventArgs e)
        {
            touchCount = 0;
            SettingsButtonWasClicked = false;
        }
    }
}
