using System;
using System.Data;
using System.Linq;

namespace CalculatorAlaBun.Classes
{
    class Utils
    {
        static public String ConcatenateStrings(String string1, String string2)
        {
            return String.Concat(string1, " ", string2);
        }

        static public String AddNumber(String result, String number)
        {
            if (result.Equals("0"))
            {
                result = String.Empty;
            }

            if (number.Equals(".") && result.Contains("."))
            {
                return result;
            }

            return result + number;
        }

        static public String AddOperationToInputBox(String input, String operation)
        {
            switch (operation)
            {
                case "⌫":
                    input = input.Substring(0, input.Length - 1);
                    if (input.Length == 0)
                        return "0";
                    return input;

                case "CE":
                    return "0";

                default:
                    return "0";
            }
        }

        static public String AddOperationToHistoryBox(String history, String operation)
        {
            switch (operation)
            {
                case "C":
                    return String.Empty;

                default:
                    return ConcatenateStrings(history, operation);
            }
        }

        static public String Calculate(String input, String history)
        {
            history = ConcatenateStrings(history, input);
            System.Object result = new DataTable().Compute(history, null);
            return result.ToString();
        }

        static public String CheckEndOfHistoryBox(String history)
        {
            const string operators = "+-/*";

            if (operators.Contains(history.Last()))
                history = history.Remove(history.Length - 1);

            return history;
        }

        static public String ChangeInputboxSign(String input)
        {
            if (input[0].Equals('-'))
            {
                input.Trim('-');
                return input;
            }

            return String.Concat("-", input);
        }

        static public String ChangeHistoryBoxSign(String history)
        {
            switch (history.Last().ToString())
            {
                case "+":
                    CheckEndOfHistoryBox(history);
                    history = String.Concat(history, " -");
                    return history;

                case "-":
                    CheckEndOfHistoryBox(history);
                    history = String.Concat(history, " +");
                    return history;

                default:
                    return history;
            }
        }
    }
}
