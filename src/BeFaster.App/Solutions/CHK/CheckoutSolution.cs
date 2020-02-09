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
                char freeKey;
                switch (key)
                {
                    case 'A':
                        while (val > 0)
                        {
                            total += CalcDiscount(ref val, 5, 200);
                            if (val <= 0) continue;
                            total += CalcDiscount(ref val, 3, 130);
                            if (val <= 0) continue;

                            total += val * 50;
                            val -= val;
                        }
                        break;
                    case 'B':
                        total += GetTotalOfDiscounted(val, 2, 45, 30);
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
                        freeKey = 'B';
                        if (val >= 2 && SKUs.ContainsKey(freeKey))
                        {
                            var bItemCount = SKUs[freeKey];
                            while (val >= 2 && bItemCount > 0)
                            {
                                if (bItemCount % 2 == 0)
                                {
                                    total -= 45;
                                    total += 30;
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
                            total += CalcDiscount(ref val, 10, 80);
                            if (val <= 0) continue;
                            total += CalcDiscount(ref val, 5, 45);
                            if (val <= 0) continue;

                            total += val * 10;
                            val -= val;
                        }
                        break;
                    case 'I':
                        total += CalculateNormalPrice(val, 35);
                        break;
                    case 'J':
                        total += CalculateNormalPrice(val, 60);
                        break;
                    case 'K':
                        while (val > 0)
                        {
                            total += CalcDiscount(ref val, 2, 150);
                            if (val <= 0) continue;
                            total += val * 80;
                            val -= val;
                        }
                        break;
                    case 'L':
                    case 'X':
                        total += CalculateNormalPrice(val, 90);
                        break;
                    case 'N':
                        freeKey = 'M';
                        var howMany = CalcIntValue(val, 3);
                        if (SKUs.ContainsKey(freeKey))
                        {
                            while (howMany > 0)
                            {
                                total -= 15;
                                howMany--;
                            }
                        }
                        total += CalculateNormalPrice(val, 40);
                        break;
                    case 'U':
                        total += GetOneFree(val, 40, 3);
                        break;
                    case 'O':
                    case 'Y':
                        total += CalculateNormalPrice(val, 10);
                        break;
                    case 'P':
                        while (val > 0)
                        {
                            total += CalcDiscount(ref val, 5, 200);
                            if (val <= 0) continue;
                            total += val * 50;
                            val -= val;
                        }
                        break;
                    case 'Q':
                        total += GetTotalOfDiscounted(val, 3, 80,30);
                        break;
                    case 'R':
                        freeKey = 'Q';
                        howMany = CalcIntValue(val, 3);
                        if (SKUs.ContainsKey(freeKey))
                        {
                            while (howMany > 0)
                            {
                                total -= 30;
                                howMany--;
                            }
                        }
                        total += CalculateNormalPrice(val, 50);
                        break;
                    case 'S':
                        total += CalculateNormalPrice(val, 30);
                        break;
                    case 'V':
                        while (val > 0)
                        {
                            total += CalcDiscount(ref val, 3, 130);
                            if (val <= 0) continue;
                            total += CalcDiscount(ref val, 2, 90);
                            if (val <= 0) continue;

                            total += val * 50;
                            val -= val;
                        }
                        break;
                    case 'Z':
                        total += CalculateNormalPrice(val, 50);
                        break;
                }
            }

            return total;
        }

        private static int GetTotalOfDiscounted(int val, int howManyForDiscount, int discountedPrice, int price)
        {
            var total = 0;
            while (val > 0)
            {
                total += CalcDiscount(ref val, howManyForDiscount, discountedPrice);
                if (val <= 0) continue;
                total += val * price;
                val -= val;
            }
            return total;
        }
        private static int CalcDiscount(ref int count, int howManyForDiscount, int discountedPrice)
        {
            var total = 0;
            if (count < howManyForDiscount) return total;
            var c = CalcIntValue(count, howManyForDiscount);
            total += c * discountedPrice;
            count -= c * howManyForDiscount;

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
                    total += (howManyToGetOneFree - 1) * price;
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





