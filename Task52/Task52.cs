using System;
using System.Collections.Generic;
using System.Linq;

namespace Task52
{
    // 52. Write a small lexical analyzer - interviewer gave tokens.Expressions like "a*b" etc.
    // Time: O(2N)
    // Space: O(2N)
    public static class Task52
    {
        private enum TokenKind
        {
            Unknown,
            Number,
            Operation,
            OpenBracket,
            CloseBracket
        }

        private enum Operation
        {
            Add,
            Substract,
            Multiply,
            Divide,
            Negative
        }

        // Time: O(n)
        // Space: O(n)
        public static int EvaluateExpression(string expression)
        {
            if (string.IsNullOrEmpty(expression)) throw new ArgumentNullException(nameof(expression));

            // input example:   10 + 2 + (5 * 3) + (6 / 3) - 1
            // polish notation: - + + 10 2 + * 5 3 / 6 3 1

            var polishNotation = TranslateToPolishNotation(expression);

            var stack = new Stack<int>();
            var operands = new int[2];
            for (int i = polishNotation.Length - 1; i >= 0; i--)
            {
                object token = polishNotation[i];
                if (token is int)
                {
                    stack.Push((int)token);
                }
                else
                {
                    var operation = (Operation) token;
                    var neededOperands = operation == Operation.Negative ? 1 : 2;
                    if (stack.Count < neededOperands)
                    {
                        throw new Exception("Error in the expression.");
                    }

                    for (int j = 0; j < neededOperands; j++)
                    {
                        operands[j] = stack.Pop();
                    }

                    switch (operation)
                    {
                            case Operation.Add:
                                stack.Push(operands[0] + operands[1]);
                                break;
                            case Operation.Substract:
                                stack.Push(operands[0] - operands[1]);
                                break;
                            case Operation.Divide:
                                stack.Push(operands[0] / operands[1]);
                                break;
                            case Operation.Multiply:
                                stack.Push(operands[0] * operands[1]);
                                break;
                            case Operation.Negative:
                                stack.Push(-operands[0]);
                                break;
                            default:
                                throw new NotImplementedException();
                    }
                }
            }

            if (stack.Count != 1)
            {
                throw new Exception("Error in the expression.");
            }

            return stack.Pop();
        }

        // Time: O(n)
        // Space: O(n)
        private static object[] TranslateToPolishNotation(string expression)
        {
            const string digits = "0123456789";
            var result = new List<object>();

            TokenKind prevTokenKind = TokenKind.Unknown;
            Stack<int> scopes = new Stack<int>();
            int scopeIndex = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                var chr = expression[i];
                switch (chr)
                {
                    case ' ':
                        break;
                    case '+':
                        if (prevTokenKind != TokenKind.Number && prevTokenKind != TokenKind.CloseBracket)
                        {
                            throw new Exception($"Wrong operation '{chr}' location.");
                        }

                        result.Insert(scopeIndex, Operation.Add);
                        prevTokenKind = TokenKind.Operation;
                        break;
                    case '-':
                        if (prevTokenKind == TokenKind.Operation ||
                            prevTokenKind == TokenKind.Unknown ||
                            prevTokenKind == TokenKind.OpenBracket)
                        {
                            result.Add(Operation.Negative);
                            prevTokenKind = TokenKind.Operation;
                            break;
                        }

                        result.Insert(scopeIndex, Operation.Substract);
                        prevTokenKind = TokenKind.Operation;
                        break;
                    case '*':
                        if (prevTokenKind != TokenKind.Number && prevTokenKind != TokenKind.CloseBracket)
                        {
                            throw new Exception($"Wrong operation '{chr}' location.");
                        }

                        result.Insert(scopeIndex, Operation.Multiply);
                        prevTokenKind = TokenKind.Operation;
                        break;
                    case '/':
                        if (prevTokenKind != TokenKind.Number && prevTokenKind != TokenKind.CloseBracket)
                        {
                            throw new Exception($"Wrong operation '{chr}' location.");
                        }

                        result.Insert(scopeIndex, Operation.Divide);
                        prevTokenKind = TokenKind.Operation;
                        break;
                    case '(':
                        scopes.Push(scopeIndex);
                        scopeIndex = result.Count;
                        prevTokenKind = TokenKind.OpenBracket;
                        break;
                    case ')':
                        if (scopes.Count == 0)
                        {
                            throw new Exception("Brackets mismatch.");
                        }

                        scopeIndex = scopes.Pop();
                        prevTokenKind = TokenKind.CloseBracket;
                        break;
                    default:
                        if (prevTokenKind != TokenKind.Operation &&
                            prevTokenKind != TokenKind.Unknown &&
                            prevTokenKind != TokenKind.OpenBracket)
                        {
                            throw new Exception($"Wrong operand '{chr}' location.");
                        }

                        string intString = chr.ToString();
                        for (int j = i + 1 ; j < expression.Length; j++)
                        {
                            if (digits.Contains(expression[j]))
                            {
                                intString += expression[j];
                                i = j;
                            }
                            else
                            {
                                break;
                            }
                        }

                        int intValue;
                        if (!int.TryParse(intString, out intValue))
                        {
                            throw new Exception($"Can't treat '{intString}' as integer value.");
                        }

                        result.Add(intValue);
                        prevTokenKind = TokenKind.Number;
                        break;
                }
            }

            if (scopes.Count > 0)
            {
                throw new Exception("Brackets mismatch.");
            }

            return result.ToArray();
        }
    }
}