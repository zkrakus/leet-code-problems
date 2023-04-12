namespace Problems.Algorithms.BestTimeToBuyAndSellStock;

/// <summary>
/// URL: https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
/// 
/// Problem:
/// You are given an array prices where prices[i] is the price of a given stock on the ith day.
/// You want to maximize your profit by choosing a single day to buy one stock and choosing 
/// a different day in the future to sell that stock.
/// Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
/// 
/// ex: 1
/// Input: [7,1,5,3,6,4]
/// Output: 5
/// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
/// Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
/// 
/// Input: prices = [7,6,4,3,1]
/// Output: 0
/// Explanation: In this case, no transactions are done and the max profit = 0.
/// 
/// Constraints:
/// 1 <= prices.length <= 10^5
/// 0 <= prices[i] <= 10^4
/// </summary>
public static class BestTimeToBuyAndSellStock
{
    /// <summary>
    /// Algorithm: 
    /// Iterate through the prices array and keep track of the current lowerBound on prices.
    /// If the price reaches a new lowerbound track it. For each price take the difference between
    /// the current price and the lowerbound. Store the difference as the max profit if it's greater than the max profit.
    /// 
    /// Analysis: 
    /// f(t) = O(n)
    /// f(s) = O(1)
    /// 
    /// </summary>
    /// <param name="prices">Integer aray for prices where each index is the ith day.</param>
    /// <returns>The maximum profit.</returns>
    public static int Run(int[] prices)
    {
        if (prices == null || prices.Length < 1)
            return 0;

        var lowerBound = int.MaxValue;
        var maxProfit = 0;
        for (var i = 0; i < prices.Length; i++)
        {
            if (prices[i] < lowerBound)
                lowerBound = prices[i];

            if (prices[i] - lowerBound > maxProfit)
                maxProfit = prices[i] - lowerBound;
        }

        return maxProfit;
    }

    /// <summary>
    /// Algorithm: 
    /// For each item in the prices array, search ahead to see the profit that would be received if you were to sell it in the future. 
    /// Keep track of the maximum attainable profit as you iterate.
    /// 
    /// Analysis: 
    /// f(t) = n(n-2)/2 = O(n*2) 
    /// f(s) = O(1)
    /// 
    /// </summary>
    /// <param name="prices">Integer aray for prices where each index is the ith day.</param>
    /// <returns>The maximum profit.</returns>
    public static int RunBruteForce(int[] prices)
    {
        if (prices == null || prices.Length < 1)
            return 0;

        var maxProfit = 0;
        for (var i = 0; i < prices.Length; i++)
        {
            for (var j = i + 1; j < prices.Length; j++)
            {
                var profit = prices[j] - prices[i];
                if (profit > maxProfit)
                    maxProfit = profit;
            }
        }

        return maxProfit;
    }
}
