﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using EstudiosBiblicos.Modelos;
using EstudiosBiblicos.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EstudiosBiblicos.Helpers
{
    public class WordManager
    {
        static Random Random = new Random();
        // Difficulty level
        //public App.GameDifficulty DifficultyLevel { get; set; }
        // tile sizes
        private const int TILE_ROWS_LEVEL_EASY = 8;
        private const int TILE_ROWS_LEVEL_MEDIUM = 12;
        private const int TILE_ROWS_LEVEL_HARD = 12;
        // words to solve per level
        private const int WORDS_LEVEL_EASY = 4;
        private const int WORDS_LEVEL_MEDIUM = 8;
        private const int WORDS_LEVEL_HARD = 16;
        // start seconds per level
        private const int START_SECS_EASY = 300;
        private const int START_SECS_MEDIUM = 240;
        private const int START_SECS_HARD = 300;
        // start seconds per level
        private const int POINTS_PER_LETTER_EASY = 10;
        private const int POINTS_PER_LETTER_MEDIUM = 20;
        private const int POINTS_PER_LETTER_HARD = 50;
        // array of random words
        private List<Word> Words { get; set; }
        private static object WordsLock = new object();
        // word list array
        public Tile[,] TileViewModels { get; set; }
        // delegate callback to update header text
        public delegate void WordCompletedDelegate(Word word);
        public event WordCompletedDelegate WordCompletedCallback;
        // delegate callback for game completed
        public delegate void GameCompletedDelegate();
        public event GameCompletedDelegate GameCompletedCallback;


        // previous clicked title that is not part of word
        private Tile LastFailedTileClicked { get; set; }

        public WordManager()
        {
            WordCompletedCallback = null;
            GameCompletedCallback = null;
            TileViewModels = null;
            Words = null;
            LastFailedTileClicked = null;
            //DifficultyLevel = App.GameDifficulty.easy;
        }

        // create new word tile multi dimentional array
        public bool InitializeWordList(int maxWordLength, Tile[,] viewModels)
        {
            bool bOK = true;
            try
            {
                // store tile array
                TileViewModels = viewModels;
                // put words in tiles
                int total = 10;//GetLevelWordCount();
                Words = new List<Word>();
                // Hard level will split easy + medium words
                //if (DifficultyLevel == App.GameDifficulty.hard)
                //{
                //    bOK = PlaceWordsInTiles(maxWordLength, App.GameDifficulty.easy, total / 2);
                //    Debug.Assert(bOK);
                //    bOK = PlaceWordsInTiles(maxWordLength, App.GameDifficulty.medium, total / 2);
                //    Debug.Assert(bOK);
                //}
                //else
                {
                    bOK = PlaceWordsInTiles(maxWordLength, total);
                    Debug.Assert(bOK);
                }
                if (bOK)
                {
                    // update tiles with words
                    bOK = RefreshWordTileStates();
                    Debug.Assert(bOK);
                }
                Debug.Assert(Words.Count == total, "InitializeWordList error Words.Count != total.");
            }
            catch (Exception ex)
            {
                ////Logger.Instance.Error($"InitializeWordList exception, {ex.Message}");
                bOK = false;
            }
            return bOK;
        }

        // put words in tiles
        private bool PlaceWordsInTiles(int maxWordLength, int totalWords)
        {
            bool bOK = true;
            try
            {
                // load words database
                //var wordDb = new WordDatabase();
                //bOK = wordDb.LoadWordsDB(difficulty);
                Debug.Assert(bOK);
                if (!bOK)
                    return false;
                int count = 0;
                int tries = 0;
                var filterList = new List<string>();
                var listado = App.Database.GetPalabra(App.LeccionSeleccionada.IdLeccion);
                var listado2 = listado.Palabras.Split(',');
                while (count < totalWords && tries < App.MAX_RANDOM_TRIES)
                {
                    string text= listado2[count].ToLower();
                    //bOK = wordDb.GetNextRandomWord(maxWordLength, filterList, out text);
                    Debug.Assert(bOK); //bOK = true;
                    if (bOK)
                    {
                        // create word object
                        Word word = new Word(text);
                        // select a random direction and position
                        bOK = SelectRandomPose(ref word);
                        Debug.Assert(bOK);
                        if (bOK)
                        {
                            bOK = word.CalculateTilePositions();
                            Debug.Assert(bOK);
                            if (bOK)
                            {
                                // found next word that fits ok
                                filterList.Add(text);
                                Debug.WriteLine($"PlaceWordsInTiles adding word {text}");
                                lock (WordsLock)
                                {
                                    Words.Add(word);
                                }
                                count++;
                                tries = 0;
                            }
                        }
                    }
                    tries++;
                }
            }
            catch (Exception ex)
            {
                //Logger.Instance.Error($"PlaceWordsInTiles exception, {ex.Message}");
                bOK = false;
            }
            return bOK;
        }

        // refresh all tiles that belong to a word
        private bool RefreshWordTileStates()
        {
            bool bOK = true;
            try
            {
                lock (WordsLock)
                {
                    foreach (var word in Words)
                    {
                        for (int n = 0; n < word.Text.Length; n++)
                        {
                            char ch = word.Text[n];
                            int row = (int)word.TilePositions[n].X;
                            int column = (int)word.TilePositions[n].Y;
                            TileViewModels[row, column].Letter = $"{ch}";
                            TileViewModels[row, column].LetterSelected = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.Instance.Error($"RefreshWordTileStates exception, {ex.Message}");
                bOK = false;
            }
            return bOK;
        }

        // select a random direction and position
        bool SelectRandomPose(ref Word word)
        {
            bool bOK = false;
            try
            {
                int rows = TileViewModels.GetLength(0);
                int columns = TileViewModels.GetLength(1);
                int tries = 0;
                while (tries < App.MAX_RANDOM_TRIES)
                {
                    int wordLen = word.Text.Length;
                    int row = Random.Next(rows);
                    int column = Random.Next(columns);
                    word.Row = row;
                    word.Column = column;
                    var directions = new List<App.WordDirection>();
                    var directionsToTest = new List<App.WordDirection>();
                    foreach (App.WordDirection direction in Enum.GetValues(typeof(App.WordDirection)))
                        directionsToTest.Add(direction);
                    directionsToTest.Add(App.WordDirection.TopLeftToBottomRight);
                    directionsToTest.Add(App.WordDirection.TopRightToBottomLeft);
                    directionsToTest.Add(App.WordDirection.BottomLeftToTopRight);
                    directionsToTest.Add(App.WordDirection.BottomRightToTopLeft);
                    foreach (App.WordDirection direction in directionsToTest)
                    {
                        // test if word fits
                        word.Direction = direction;
                        if (word.WordFits(rows, columns))
                        {
                            // test for collision with existing words
                            bool bHasCollision = false;
                            lock (WordsLock)
                            {
                                foreach (var existingWord in Words)
                                {
                                    if (existingWord.HasCollision(word))
                                    {
                                        bHasCollision = true;
                                        break;
                                    }
                                }
                            }
                            if (!bHasCollision)
                                directions.Add(direction);
                        }
                    }
                    if (directions.Count > 0)
                    {
                        // select direction and set row and column for word object
                        word.Direction = directions[Random.Next(directions.Count)];
                        bOK = true;
                        break;
                    }
                    tries++;
                }
            }
            catch (Exception ex)
            {
                //Logger.Instance.Error($"SelectRandomPose exception, {ex.Message}");
                bOK = false;
            }
            return bOK;
        }

        // Get copy of words list
        internal void GetWordsList(out List<Word> words)
        {
            lock (WordsLock)
            {
                words = Words;
            }
        }

        // get tile from array
        public bool GetTileAt(int row, int column, out Tile tile)
        {
            bool bOK = true;
            tile = null;
            try
            {
                tile = TileViewModels.GetValue(row, column) as Tile;
            }
            catch (Exception ex)
            {
                //Logger.Instance.Error($"GetTileAt exception, {ex.Message}");
                bOK = false;
            }
            return bOK;
        }

        // get tile width based on game difficulty
        public int GetMinRequiredTiles()
        {
            int result = 0;
            //switch (DifficultyLevel)
            //{
            //    case App.GameDifficulty.easy:
            //        result = TILE_ROWS_LEVEL_EASY;
            //        break;
            //    case App.GameDifficulty.medium:
            //        result = TILE_ROWS_LEVEL_MEDIUM;
            //        break;
            //    case App.GameDifficulty.hard:
            //        result = TILE_ROWS_LEVEL_HARD;
            //        break;
            //}

            result = TILE_ROWS_LEVEL_HARD;
            Debug.Assert(result != 0);
            return result;
        }

        // get text start and end position for header highlight
        internal object GetTextPos(Word word)
        {
            try
            {
                int count = GetLevelWordCount();
                int percentage = 100 / count;
                int wordPos = -1;
                lock (WordsLock)
                {
                    wordPos = Words.IndexOf(word);
                }
                int startPos = wordPos * percentage;
                if (wordPos > 8)
                    startPos = (wordPos - 8) * percentage;
                int endPos = percentage;
                var textPos = new { Word = word.Text, Start = startPos, End = endPos, WordPos = wordPos, WordTotal = count };
                return textPos;
            }
            catch (Exception ex)
            {
                //Logger.Instance.Error($"GetTextPos exception, {ex.Message}");
            }
            return null;
        }

        // get number of words to find based on difficulty
        public int GetLevelWordCount()
        {
            int count = 0;
            //switch (DifficultyLevel)
            //{
            //    case App.GameDifficulty.easy:
            //        count = WORDS_LEVEL_EASY;
            //        break;
            //    case App.GameDifficulty.medium:
            //        count = WORDS_LEVEL_MEDIUM;
            //        break;
            //    case App.GameDifficulty.hard:
            //        count = WORDS_LEVEL_HARD;
            //        break;
            //    default:
            //        Debug.Assert(false);
            //        break;
            //}
            count = WORDS_LEVEL_HARD;
            return count;
        }

        // get start seconds based on difficulty level
        internal int GetStartSecondsRemaining()
        {
            int secondsRemaining = 0;
            //switch (DifficultyLevel)
            //{
            //    case App.GameDifficulty.easy:
            //        secondsRemaining = START_SECS_EASY;
            //        break;
            //    case App.GameDifficulty.medium:
            //        secondsRemaining = START_SECS_MEDIUM;
            //        break;
            //    case App.GameDifficulty.hard:
            //        secondsRemaining = START_SECS_HARD;
            //        break;
            //    default:
            //        Debug.Assert(false);
            //        break;
            //}
            secondsRemaining = START_SECS_HARD;
            return secondsRemaining;
        }

        // get points per letter
        internal int GetPointsPerLetter()
        {
            int points = 0;
            //switch (DifficultyLevel)
            //{
            //    case App.GameDifficulty.easy:
            //        points = POINTS_PER_LETTER_EASY;
            //        break;
            //    case App.GameDifficulty.medium:
            //        points = POINTS_PER_LETTER_MEDIUM;
            //        break;
            //    case App.GameDifficulty.hard:
            //        points = POINTS_PER_LETTER_HARD;
            //        break;
            //    default:
            //        Debug.Assert(false);
            //        break;
            //}
            points = POINTS_PER_LETTER_HARD;
            return points;
        }

        // change word letter selection if clicked
        public bool CheckForSelectedWord(JObject json, out bool isPartOfWord)
        {
            bool bOK = true;
            isPartOfWord = false;
            try
            {
                int row = 0;
                int column = 0;
                if (json.SelectToken("TileRow", false) != null)
                    row = (int)json["TileRow"];
                if (json.SelectToken("TileColumn", false) != null)
                    column = (int)json["TileColumn"];
                bOK = GetTileAt(row, column, out Tile tile);
                Debug.Assert(bOK);
                if (!bOK)
                    return false;
                if (!tile.IsPartOfCompletedWord)
                {
                    tile.LetterSelected = !tile.LetterSelected;
                    isPartOfWord = false;
                    lock (WordsLock)
                    {
                        foreach (var word in Words)
                        {
                            for (int n = 0; n < word.Text.Length; n++)
                            {
                                row = (int)word.TilePositions[n].X;
                                column = (int)word.TilePositions[n].Y;
                                if (tile.TileRow == row && tile.TileColumn == column)
                                {
                                    isPartOfWord = true;
                                    // check if whole word is selected
                                    bool selected;
                                    bOK = CheckForCompletedWord(word, out selected);
                                    Debug.Assert(bOK);
                                    if (bOK && selected)
                                    {
                                        // mark tiles as part of completed word so they are not deselected
                                        bOK = MarkTilesAsWordCompleted(word);
                                        Debug.Assert(bOK);
                                        word.IsWordCompleted = true;
                                        // check if all words are selected
                                        bOK = CheckForAllWordsSelected(out bool allSelected);
                                        Debug.Assert(bOK);
                                        if (bOK && allSelected)
                                        {
                                            WordCompletedCallback?.Invoke(word);
                                            GameCompletedCallback?.Invoke();
                                        }
                                        else
                                        {
                                            WordCompletedCallback?.Invoke(word);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    // deselect previous click
                    if (LastFailedTileClicked != null)
                    {
                        LastFailedTileClicked.LetterSelected = false;
                        LastFailedTileClicked = null;
                    }
                    if (!isPartOfWord)
                        LastFailedTileClicked = tile;
                }
                else
                {
                    isPartOfWord = true;
                }
            }
            catch (Exception ex)
            {
                //Logger.Instance.Error($"CheckForSelectedWord exception, {ex.Message}");
                bOK = false;
            }
            return bOK;
        }

        // check if whole word is selected
        private bool CheckForCompletedWord(Word word, out bool selected)
        {
            bool bOK = true;
            selected = true;
            try
            {
                for (int n = 0; n < word.Text.Length; n++)
                {
                    int row = (int)word.TilePositions[n].X;
                    int column = (int)word.TilePositions[n].Y;
                    if (!TileViewModels[row, column].LetterSelected)
                    {
                        selected = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.Instance.Error($"CheckForCompletedWord exception, {ex.Message}");
                bOK = false;
            }
            return bOK;
        }

        // mark tiles as part of completed word so they are not deselected
        private bool MarkTilesAsWordCompleted(Word word)
        {
            bool bOK = true;
            try
            {
                for (int n = 0; n < word.Text.Length; n++)
                {
                    int row = (int)word.TilePositions[n].X;
                    int column = (int)word.TilePositions[n].Y;
                    TileViewModels[row, column].IsPartOfCompletedWord = true;
                }
            }
            catch (Exception ex)
            {
                //Logger.Instance.Error($"MarkTilesAsWordCompleted exception, {ex.Message}");
                bOK = false;
            }
            return bOK;
        }

        // check if all words are selected
        private bool CheckForAllWordsSelected(out bool allSelected)
        {
            bool bOK = true;
            allSelected = true;
            try
            {
                lock (WordsLock)
                {
                    foreach (var word in Words)
                    {
                        if (!word.IsWordCompleted)
                        {
                            allSelected = false;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.Instance.Error($"CheckForAllWordsSelected exception, {ex.Message}");
                bOK = false;
                allSelected = false;
            }
            return bOK;
        }

        // Show words in hard level after time up
        internal void ShowAllHardLevelWords()
        {
            try
            {
                lock (WordsLock)
                {
                    foreach (var word in Words)
                    {
                        word.IsWordHidden = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.Instance.Error($"ShowAllHardLevelWords exception, {ex.Message}");
            }
        }

        // Randomly hide and show words in hard level
        internal void HideHardLevelWords()
        {
            try
            {
                lock (WordsLock)
                {
                    Debug.Assert(Words.Count != 0);
                    if (Words.Count == 0)
                        return;
                    Word visibleWord = null;
                    int tries = 0;
                    // Try and find a random non completed word to make visible
                    while (tries < App.MAX_RANDOM_TRIES)
                    {
                        int num = Random.Next(Words.Count);
                        var word = Words[num];
                        if (!word.IsWordCompleted)
                        {
                            visibleWord = word;
                            break;
                        }
                        tries++;
                    }
                    foreach (var word in Words)
                    {
                        if (!word.IsWordCompleted && word != visibleWord)
                            word.IsWordHidden = true;
                        else
                            word.IsWordHidden = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.Instance.Error($"HideHardLevelWords exception, {ex.Message}");
            }
        }
    }
}
