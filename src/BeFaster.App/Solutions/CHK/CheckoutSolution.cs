using System;
using System.Collections.Generic;
using System.Linq;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string skus)
        {
            var SKUs = new Dictionary<char, int>();
            var knownSKUs = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            if (string.IsNullOrEmpty(skus))
            {
                return 0;
            }

            var total = 0;
            var charArr = skus.ToCharArray().OrderBy(c => c);
            foreach (var c in charArr)
            {
                if (!knownSKUs.Contains(c))
                {
                    return -1;
                }

                if (!SKUs.ContainsKey(c))
                {
                    SKUs.Add(c, 1);
                }
                else
                {
                    SKUs[c] += 1;
                }
            }

            foreach (var sku in SKUs)
            {
                var key = sku.Key;
                var val = sku.Value;
                switch (key)
                {
                    case 'A':
                        while (val > 0)
                        {
                            if (val >= 5)
                            {
                                var c = CalcIntValue(val, 5);
                                total += c * 200;
                                val -= c * 5;
                            }
                            else if (val >= 3)
                            {
                                var c = CalcIntValue(val, 3);
                                total += c * 130;
                                val -= c * 3;
                            }
                            else
                            {
                                total += val * 50;
                                val -= val;
                            }
                        }
                        break;
                    case 'B':
                        if (val >= 2)
                        {
                            var c = CalcIntValue(val, 2);
                            total += c * 45;
                            val -= c * 2;
                        }
                        total += CalculateNormalPrice(val, 30);
                        break;
                    case 'C':
                    case 'G':
                    case 'W':
                    case 'T':
                        total += CalculateNormalPrice(val, 20);
                        break;
                    case 'D':
                    case 'M':
                        total += CalculateNormalPrice(val, 15);
                        break;
                    case 'E':
                        // This could be converted to a function
                        if (val >= 2 && SKUs.ContainsKey('B'))
                        {
                            var bItemCount = SKUs['B'];
                            while (val >= 2 && bItemCount > 0)
                            {
                                if (bItemCount % 2 == 0)
                                {
                                    total -= 15;
                                    bItemCount -= 1;
                                }
                                else
                                {
                                    total -= 30;
                                    bItemCount -= 1;
                                }
                                total += 80;
                                val -= 2;
                            }
                        }
                        total += CalculateNormalPrice(val, 40);
                        break;
                    case 'F':
                        total += GetOneFree(val, 10, 3);
                        break;
                    case 'H':
                        while (val > 0)
                        {
                            if (val >= 10)
                            {
                                var c = CalcIntValue(val, 10);
                                total += c * 80;
                                val -= c * 10;
                            }
                            else if (val >= 5)
                            {
                                var c = CalcIntValue(val, 5);
                                total += c * 45;
                                val -= c * 5;
                            }
                            else
                            {
                                total += val * 10;
                                val -= val;
                            }
                        }
                        break;
                    case 'I':
                        total += CalculateNormalPrice(val, 35);
                        break;
                    case 'J':
                        total += CalculateNormalPrice(val, 60);
                        break;
                    case 'L':
                    case 'X':
                        total += CalculateNormalPrice(val, 90);
                        break;
                    case 'U':
                        total += GetOneFree(val, 40, 3);
                        break;
                    case 'O':
                    case 'Y':
                        total += CalculateNormalPrice(val, 10);
                        break;
                    case 'S':
                        total += CalculateNormalPrice(val, 30);
                        break;
                    case 'Z':
                        total += CalculateNormalPrice(val, 50);
                        break;
                }
            }

            return total;
        }

        private static int CalculateNormalPrice(int count, int price)
        {
            return count * price;
        }
        private static int GetOneFree(int itemCount, int price, int howManyToGetOneFree)
        {
            var total = 0;
            while (itemCount > 0)
            {
                if (itemCount % howManyToGetOneFree == 0)
                {
                    total += (howManyToGetOneFree-1) * price;
                    itemCount -= howManyToGetOneFree;
                }
                else
                {
                    total += price;
                    itemCount -= 1;
                }
            }

            return total;
        }
        private static int CalcIntValue(int x, int y)
        {
            return Convert.ToInt32(decimal.Truncate(x / y));
        }
    }
}





