/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Collections.Generic;
using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
            Question1:

                // creating a list from scratch to hold the resultant missing ranges.
                List<string> result = new List<string>();


                long prevNum = (long)lower - 1; // In the event that there are missing numbers before the lower bound, this helps address the situation.

                // Go over the sorted array of numbers iteratively, taking the end boundary into consideration.
                foreach (int num in nums)
                {
                    // Determine the missing range that currently exists between num and prevNum.
                    // add missing range to the result list.
                    if (num - prevNum >= 2)
                    {
                        result.Add(FormatRange(prevNum + 1, num - 1));
                    }

                    // Before the following iteration, update the prevNum variable.
                    prevNum = num;
                }

                // Consideration must be given to a missing range if prevNum is smaller than upper.
                if (upper - prevNum >= 1)
                {
                    result.Add(FormatRange(prevNum + 1, upper));
                }

                // Provide the missing ranges list back.
                return result;
            }

    // An aid function to generate a missing range string in format.
    private string FormatRange(long start, long end)
            {
                // Return the start value as a string if the beginning and end values are the same.
                if (start == end)
                {
                    return start.ToString();
                }
                else
                {
                    // Use the "," separator to format the range's start and end values if they differ.
                    return start + "," + end;
                }


        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
         
            
                // Create a stack and initialize it to track open brackets.
                Stack<char> openBrackets = new Stack<char>();

                // To record mappings between open and closed brackets, define a dictionary.
                Dictionary<char, char> bracketMap = new Dictionary<char, char>();
                bracketMap.Add(')', '(');
                bracketMap.Add('}', '{');
                bracketMap.Add(']', '[');

                // Go over each character in the input string one by one.
                foreach (char ch in s)
                {

                    if (bracketMap.ContainsKey(ch))
                    {
                        // If the stack is not empty, remove the top element; if not, set a dummy value.
                        char topElement = openBrackets.Count > 0 ? openBrackets.Pop() : '#';


                        // If we check the open bracket with the matching open bracket, and they are not identical, the input text is invalid.
                        if (topElement != bracketMap[ch])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        // Place the character into the stack if it is an opening bracket.
                        openBrackets.Push(ch);
                    }
                }

                //The string is valid if all open brackets were correctly closed; if not, it is invalid.
                return openBrackets.Count == 0;
            }

        }
             
        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {           // Initialize minPrice as highest possible value
                        int buyPrice = int.MaxValue;
                        int maxGain = 0;
                        // Loop through all prices
                        for (int i = 0; i < prices.Length; i++)
                        {
                            // Update min price if current price is lower
                            if (prices[i] < buyPrice)
                            {
                                buyPrice = prices[i];
                            }
                            else if (prices[i] - buyPrice > maxGain)     // Compute potential profit if sold at current price
                                                                         // Update maxProfit if this profit is higher

                            {
                                maxGain = prices[i] - buyPrice;
                            }

                        }
                        // Return the maximum profit

                        return maxGain;
                }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {          // Initialize pointers at start and end of string
                        for (int i = 0, j = num.Length - 1; i <= j; i++, j--)
                        {   // If characters do not match as reversal 
                            if (!Match(num[i], num[j]))
                            {   // Number is not strobogrammatic if returns false
                                return false;
                            }
                        }
                        return true;
                    }
                   // Check if characters are reversals of each other
        private bool Match(char num1, char num2)
                    {
                        if (num1 == '6' && num2 == '9' ||
                        num1 == '9' && num2 == '6' ||
                        num1 == '0' && num2 == '0' ||
                        num1 == '1' && num2 == '1' ||
                        num1 == '8' && num2 == '8')
                        {
                            return true;
                        }
                        return false;
                    }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {            // Array to store frequency of each number
                        int[] count = new int[101];
                        int pairs = 0;
                        // Increment count for each number in nums

                        for (int i = 0; i < nums.Length; i++)
                        {
                            count[nums[i]]++;
                        }
                        // Check numbers with frequency > 1  
                        // Calculate pairs using nC2 formula
                        for (int i = 0; i < 101; i++)
                        {
                            if (count[i] > 1)
                            {
                                pairs += count[i] * (count[i] - 1) / 2;
                            }
                        }

                        return pairs;
                    }
}
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // The input array should be sorted descendingly.
                Array.Sort(nums);
                Array.Reverse(nums);

                int uniqueCount = 1;
                int? thirdMax = null;

                // Determine the third distinct maximum by iterating through the sorted array.
                for (int i = 1; i < nums.Length; i++)
                {
                    // If the current number is different from the previous one, raise the distinctCount.
                    if (nums[i] != nums[i - 1])
                    {
                        uniqueCount++;
                    }

                    // Break out of the loop and set the thirdMax variable if the distinctCount is 3.
                    if (uniqueCount == 3)
                    {
                        thirdMax = nums[i];
                        break;
                    }
                }

                // Return the highest possible number if the thirdMax variable is null. Return the third unique maximum number if not.
                return thirdMax ?? nums[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                List<string> output = new List<string>();

                // Find "++" by iterating through the currentState string.
                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // In order to create a new string, flip "++" to "--".
                        char[] newState = currentState.ToCharArray();
                        newState[i] = '-';
                        newState[i + 1] = '-';
                        output.Add(new string(newState));
                    }
                }

                
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
         
            // To eliminate the vowels "a," "e," "i," "o," and "u" from the input string, use regex.
            string pattern = "[aeiouAEUIOU]";

            // Every time a vowel appears, replace it with an empty string.
            string result = Regex.Replace(s, pattern, "");

            // Give back the revised string without any vowels.
            return result;

        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
