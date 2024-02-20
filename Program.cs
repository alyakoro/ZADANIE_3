using System;

namespace ZADANIE_3
{
    class Program
    {
        static void Main()
        {
            bool exit = false;
            while (exit != true)
            {
                VvodCoordinat();

                Console.Write(Environment.NewLine +
                    "Введите 'exit' для выхода: " +
                    Environment.NewLine);
                string exitword = Console.ReadLine();
                if (exitword == "exit")
                    exit = true;
            }
        }


        // Функция рисование шахматной доски.
        static void DrawChessboard(int KX, int KY,
            int FX, int FY)
        {
            Console.WriteLine("  a b c d e f g h");
            for (int i = 8; i >= 1; i--)
            {
                Console.Write((i) + " ");
                for (int j = 1; j <= 8; j++)
                {
                    if (j == KX && i == KY)
                        Console.Write("K ");
                    else if (j == FX && i == FY)
                        Console.Write("F ");
                    else
                        Console.Write("- ");
                }
                Console.WriteLine();
            }
        }

        // Функция ввода и проверки данных.
        static void VvodCoordinat()
        {
            bool vvod_reght = false;
            do
            {
                Console.Write("Введите координаты ферзя(K) " +
                    "и фигуры(F) (например, a1 b3): ");
                string coordinat_fig = Console.ReadLine();

                string[] coordinat = coordinat_fig.Split(' ');

                if ((coordinat.Length == 2) &&
                    (coordinat[0] != coordinat[1]))
                {
                    string ferzPosition = coordinat[0];
                    string figurePosition = coordinat[1];

                    if (CorrectPosition(ferzPosition) &&
                        CorrectPosition(figurePosition))
                    {
                        vvod_reght = true;
                        SravnrniePossision(ferzPosition,
                            figurePosition);
                    }
                }

            } while (vvod_reght != true);
        }

        // Функция сравнения координаты слона и фигуры.
        static void SravnrniePossision(string ferz,
            string figure)
        {
            // Нахождение координат слона и фигуры.
            int ferzX = ferz[0] - 'a' + 1;
            int ferzY = ferz[1] - '0';
            int figureX = figure[0] - 'a' + 1;
            int figureY = figure[1] - '0';

            DrawChessboard(ferzX, ferzY, figureX, figureY);

            if ((OneFerzAttacking(ferzX, ferzY, figureX, figureY)) ||
                (TwoFerzAttacking(ferzX, ferzY, figureX, figureY)))
                Console.WriteLine("Ферзь сможет побить фигуру");
            else
                Console.WriteLine("Ферзь не сможет побить фигуру");
        }

        // Функция проверки на правильность ввода:
        // 1. Количество символов.
        // 2. Пределы (a-h) и (1 - 8).
        static bool CorrectPosition(string position)
        {
            if (position.Length != 2)
                return false;

            char bokva = position[0];
            char numer = position[1];

            return bokva >= 'a' && bokva <= 'h'
                && numer >= '1' && numer <= '8';
        }

        // 1 Функция определения, "нападает" ли ферзь (true/false).
        static bool OneFerzAttacking(int CX, int CY,
            int FX, int FY)
        {
            int XDiff = Math.Abs(CX - FX);
            int YDiff = Math.Abs(CY - FY);
            return XDiff == YDiff;
        }

        // 2 Функция определения, "нападает" ли ферзь (true/false).
        static bool TwoFerzAttacking(int CX, int CY,
            int FX, int FY)
        {
            return ((CX == FX) || (CY == FY));
        }
    }
}
