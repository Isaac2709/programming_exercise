using GTF.WordPuzzleSolver.Domain.Entities;
using GTF.WordPuzzleSolver.Infrastructure.DataAccess.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTF.WordPuzzleSover.Application.Services
{
    public class WordMatrixService
    {
        private readonly RulesRepository _rulesRepository;
        private readonly ValuesRepository _valuesRepository;
        private readonly WordsRepository _wordsRepository;
        private readonly CypherRepository _cypherRepository;

        private static WordMatrix matrix;

        public WordMatrixService()
        {
            _rulesRepository = new RulesRepository();
            _valuesRepository = new ValuesRepository();
            _wordsRepository = new WordsRepository();
            _cypherRepository = new CypherRepository();
        }

        public void Initialize()
        {
            var rules = _rulesRepository.LoadData();
            var values = _valuesRepository.LoadData();
            var words = _wordsRepository.LoadData();
            var cypher = _cypherRepository.LoadData();

            matrix = new WordMatrix()
            {
                Rules = rules,
                Values = values,
                Words = words,
                Cypher = cypher
            };
        }

        public WordMatrix Draw()
        {
            var index = 0;
            foreach (var line in matrix.Cypher)
            {
                var result = DrawLine(line, matrix.Values[index]);

                var lineList = new List<char>();
                foreach (var caracter in result)
                {
                    lineList.Add(caracter);
                }
                matrix.Matrix.Add(lineList);
                index += 1;
            }

            return matrix;
        }

        public IList<dynamic> GetWordLocation(string word)
        {
            for (var row = 0; row < matrix.Matrix.Count; row++)
            {
                for (var column = 0; column < matrix.Matrix[row].Count; column++)
                {
                    var currentLetter = matrix.Matrix[row][column];
                    if (currentLetter == word[0])
                    {
                        var matrixPositions = new int[] { row, column };
                        var recorded = FindAdjacentLetter(word, 1, matrixPositions, new List<dynamic>());
                        if(recorded.Count == word.Length)
                        {
                            return recorded;
                        }
                    }
                }
            }
            return null;
        }

        private IList<dynamic> FindAdjacentLetter(string word, int letterPosition, int[] matrixPositions, IList<dynamic> matrixRecorded)
        {
            var breakdown = new
            {
                Character = word[letterPosition - 1],
                Row = matrixPositions[0],
                Column = matrixPositions[1]
            };

            matrixRecorded.Add(breakdown);
            if (letterPosition >= word.Length)
            {
                return matrixRecorded;
            }
            var left = new int[] { matrixPositions[0] - 1, matrixPositions[1] };
            var right = new int[] { matrixPositions[0] + 1, matrixPositions[1] };
            var top = new int[] { matrixPositions[0], matrixPositions[1] - 1 };
            var bottom = new int[] { matrixPositions[0], matrixPositions[1] + 1 };
            var leftTop = new int[] { matrixPositions[0] - 1, matrixPositions[1] - 1 };
            var leftBottom = new int[] { matrixPositions[0] - 1, matrixPositions[1] + 1 };
            var rightTop = new int[] { matrixPositions[0] + 1, matrixPositions[1] - 1 };
            var rightBottom = new int[] { matrixPositions[0] + 1, matrixPositions[1] + 1 };
            var letter = word[letterPosition];

            if (left[0] > 0 && letter == matrix.Matrix[left[0]][left[1]])
            {
                return FindAdjacentLetter(word, letterPosition + 1, left, matrixRecorded);
            }
            else if (right[0] < matrix.Matrix.Count && letter == matrix.Matrix[right[0]][right[1]])
            {
                return FindAdjacentLetter(word, letterPosition + 1, right, matrixRecorded);
            }
            else if (top[1] > 0 && letter == matrix.Matrix[top[0]][top[1]])
            {
                return FindAdjacentLetter(word, letterPosition + 1, top, matrixRecorded);
            }
            else if (bottom[1] < matrix.Matrix[bottom[0]].Count && letter == matrix.Matrix[bottom[0]][bottom[1]])
            {
                return FindAdjacentLetter(word, letterPosition + 1, bottom, matrixRecorded);
            }
            else if (leftTop[0] > 0 && leftTop[1] > 0 && letter == matrix.Matrix[leftTop[0]][leftTop[1]])
            {
                return FindAdjacentLetter(word, letterPosition + 1, leftTop, matrixRecorded);
            }
            else if (leftBottom[0] > 0 && leftBottom[1] < matrix.Matrix[leftBottom[0]].Count && letter == matrix.Matrix[leftBottom[0]][leftBottom[1]])
            {
                return FindAdjacentLetter(word, letterPosition + 1, leftBottom, matrixRecorded);
            }
            else if (rightTop[0] < matrix.Matrix.Count && rightTop[1] > 0 && letter == matrix.Matrix[rightTop[0]][rightTop[1]])
            {
                return FindAdjacentLetter(word, letterPosition + 1, rightTop, matrixRecorded);
            }
            else if (rightBottom[0] < matrix.Matrix.Count && rightBottom[1] < matrix.Matrix[rightBottom[0]].Count && letter == matrix.Matrix[rightBottom[0]][rightBottom[1]])
            {
                return FindAdjacentLetter(word, letterPosition + 1, rightBottom, matrixRecorded);
            }

            return matrixRecorded;
        }

        private string DrawLine(string symbolString, Values valueRule)
        {
            var sortedRules = valueRule.ValueRules.OrderBy(r => r.Order);
            foreach (var rule in sortedRules)
            {
                var baseRule = matrix.Rules.FirstOrDefault(b => b.Id == rule.Rule);
                var containPattern = symbolString.Contains(baseRule.Source);
                if (containPattern)
                {
                    symbolString = symbolString.Replace(baseRule.Source, baseRule.Replacement);

                    if (rule.IsTermination) break;

                    return DrawLine(symbolString, valueRule);
                }
            }

            return symbolString;
        }
    }
}
