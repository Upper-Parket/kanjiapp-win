using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;
using KanjiApp.Enums;

namespace KanjiApp.Converters
{
    public class QuizStateToBrushConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Count == 0 || values[0] == null) return null;
            if (values[0] is not QuizState quizState) return null;

            return quizState switch
            {
                QuizState.New => values[1],
                QuizState.GuessedWrong => values[2],
                QuizState.GuessedCorrectly => values[3],
                _ => null
            };
        }
    }
}