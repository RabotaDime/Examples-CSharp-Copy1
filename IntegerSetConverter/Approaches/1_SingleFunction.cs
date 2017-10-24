using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace IntegerSetConverter
{
    class SingleFunctionConverter : INumericConverter
    {
        string INumericConverter.ConverterName
        {
            get { return "SingleFunctionConverter"; }
        }



        public static string Convert
        (
            int[] aData,
            string aSeparator   = ConvertOptions.DefaultSeparator,
            string aJoint       = ConvertOptions.DefaultJoint
        )
        {
            StringBuilder Result = new StringBuilder();


            if (aData.Length <= 0)
            {
                return String.Empty;
            }


            ///   Первый шаг. Обработка первого элемента. 
            int Prev = aData[0];

            int SequenceCounter = 0;

            Result.AppendFormat("{0}", Prev);


            ///   Обход остальных элементов. 
            for (int I = 1, Value; I < aData.Length; I++, Prev = Value)
            {
                Value = aData[I];

                ///   Проверка значений. 
                if (Value <= Prev)
                    throw new ArgumentException(String.Format("The input set contains invalid data at index [{0}]. The value is less or equal to previous element.", I), "Data");

                ///   Если предыдущий элемент на один шаг следует за данным, 
                ///   значит его можно записать в последовательность. 
                if (Value == Prev + 1)
                {
                    SequenceCounter++;
                }
                else
                {
                    ///   Вывод данных об обнаруженной последовательности. (Дубль!) 
                    if (SequenceCounter > 0)
                    {
                        Result.AppendFormat("{0}{1}", aJoint, Prev);
                        SequenceCounter = 0;
                    }

                    ///   Вывод отдельного элемента. 
                    Result.AppendFormat("{0}{1}", aSeparator, Value);
                }
            }

            ///   Вывод данных об обнаруженной последовательности. (Дубль!) 
            if (SequenceCounter > 0)
            {
                Result.AppendFormat("{0}{1}", aJoint, Prev);
                SequenceCounter = 0;
            }


            return Result.ToString();
        }



        public static int[] Convert
        (
            string aData,
            string aSeparator   = ConvertOptions.DefaultSeparator,
            string aJoint       = ConvertOptions.DefaultJoint
        )
        {
            var Result = new List<int> ();


            if (aData.Length <= 0)
                return Result.ToArray();

            if (aSeparator  .Length <= 0) throw new ArgumentException("", "Separator");
            if (aJoint      .Length <= 0) throw new ArgumentException("", "Joint");
            if (! ConvertOptions.Validate(aSeparator, aJoint)) throw new ArgumentException("", "Joint, Separator");


            Char C;
            ParseMode PrevMode = ParseMode.Undefined;

            int ParseSeparatorIndex = 0;
            int ParseJointIndex     = 0;
            int ParseNumber         = 0;
            int ParseNumberIndex    = 0;

            int SavedRangeStart     = 0;
            bool SavedRangeMode     = false;


            for (int I = 0; I < aData.Length; I++)
            {
                C = aData[I];


                ParseMode Mode = ParseMode.Error;


                if (Char.IsWhiteSpace(C))
                {
                    Mode = ParseMode.Whitespace;
                }
                else if ((ParseSeparatorIndex < aSeparator.Length) && (C == aSeparator[ParseSeparatorIndex]))
                {
                    ParseSeparatorIndex++;
                    Mode = ParseMode.Separator;
                }
                else if ((ParseJointIndex < aJoint.Length) && (C == aJoint[ParseJointIndex]))
                {
                    ParseJointIndex++;
                    Mode = ParseMode.Joint;
                }
                ///   Если мы не вошли в режим разделителя или связки, 
                ///   и обнаружен символ, отвечающий за цифры. 
                else if (Char.IsNumber(C)) // (ParseJointIndex == 0) && (ParseSeparatorIndex == 0) && 
                {
                    ///   Повышаем разряд числа и прибавляем новую часть. 
                    ParseNumber = (ParseNumber * 10) + (int) Char.GetNumericValue(C); 
                    ParseNumberIndex++;
                    Mode = ParseMode.Number;
                }


                if (Mode == ParseMode.Error)
                    throw new ArgumentException("Invalid input data.", "Data");


                if (PrevMode != Mode)
                {
                    if ((PrevMode == ParseMode.Joint) && (ParseJointIndex > 0))
                    {
                        if (ParseJointIndex == aJoint.Length)
                        {
                            ///   Обнаружена связка двух чисел (диапазон). 

                            SavedRangeMode = true;

                            ParseJointIndex = 0;
                        }
                        else if (ParseJointIndex > aJoint.Length)
                        {
                            throw new ArgumentException(String.Format("Invalid joint sequence detected at pos [{0}]", I), "Data");
                        }
                    }
                    else if ((PrevMode == ParseMode.Separator) && (ParseSeparatorIndex > 0))
                    {
                        if (ParseSeparatorIndex == aSeparator.Length)
                        {
                            ///   Обнаружен разделитель между элементами. 

                            ParseSeparatorIndex = 0;
                        }
                        else if (ParseSeparatorIndex > aSeparator.Length)
                        {
                            throw new ArgumentException(String.Format("Invalid separator sequence detected at pos [{0}]", I), "Data");
                        }
                    }
                    else if ((PrevMode == ParseMode.Number) && (ParseNumberIndex > 0))
                    {
                        ///   Обнаружено начало или продолжение числа. 

                        if (SavedRangeMode)
                        {
                            int RangeStart = SavedRangeStart + 1;
                            int RangeCount = ParseNumber - SavedRangeStart;

                            if (RangeCount <= 0)
                            {
                                throw new ArgumentException("Invalid elements in input data (invalid range).", "Data");
                            }

                            Result.AddRange(Enumerable.Range(RangeStart, RangeCount));

                            SavedRangeStart = 0;
                            SavedRangeMode = false;
                        }
                        else
                        {
                            Result.Add(ParseNumber);
                        }

                        SavedRangeStart = ParseNumber;

                        ParseNumber = 0;
                        ParseNumberIndex = 0;
                    }


                    PrevMode = Mode;
                }
            }


            if (SavedRangeMode)
            {
                Result.AddRange(Enumerable.Range(SavedRangeStart + 1, ParseNumber - SavedRangeStart));

                SavedRangeStart = 0;
                SavedRangeMode = false;
            }
            else
            {
                Result.Add(ParseNumber);
            }


            return Result.ToArray();
        }



        enum ParseMode
        {
            Undefined   = 0,
            Number      = 1,
            Separator   = 2,
            Joint       = 3,
            Whitespace  = 4,
            Error       = 10,
        }



        string INumericConverter.Convert (int[] aData, string aSeparator, string aJoint)
        {
            return SingleFunctionConverter.Convert(aData, aSeparator, aJoint);
        }



        int[] INumericConverter.Convert (string aData, string aSeparator, string aJoint)
        {
            return SingleFunctionConverter.Convert(aData, aSeparator, aJoint);
        }
    }
}
