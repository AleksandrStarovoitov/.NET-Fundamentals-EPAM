using NLog;
using System;

namespace ClassLibrary
{
    public class StringConverter
    {
        private readonly ILogger logger;

        public StringConverter(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            this.logger.Debug("Call StringConverter constructor.");
        }

        public int ToInt32(string str)
        {
            try
            {
                logger.Info($"Call ToInt32 method with argument: \"{str}\".");

                if (String.IsNullOrEmpty(str))
                {
                    throw new ArgumentException("Input string is null or empty.", nameof(str));
                }

                checked
                {
                    int result = 0, index = 0, multBy = 1, digit = 0;

                    for (int i = str.Length - 1; i >= 0; i--)
                    {
                        if (i == 0 && str[0] == '-')
                        {
                            result *= -1;
                        }
                        else
                        {
                            multBy = (Int32)Math.Pow(10, index++);
                            digit = GetDigitFromChar(str[i]);
                            result += digit * multBy;
                        }
                    }

                    logger.Info($"Conversion compeleted. Returning result: {result}.");
                    return result;
                }
            }
            catch (OverflowException ex)
            {
                logger.Error(ex);
                throw;
            }
            catch (ArgumentException ex)
            {
                logger.Error(ex);
                throw;
            }
        }

        private int GetDigitFromChar(char c) => c switch
        {
            '0' => 0,
            '1' => 1,
            '2' => 2,
            '3' => 3,
            '4' => 4,
            '5' => 5,
            '6' => 6,
            '7' => 7,
            '8' => 8,
            '9' => 9,
            _ => throw new ArgumentException($"Invalid string. '{c}' is not a digit.")
        };
    }
}
