/// <summary>
/// This class represents the OR expression.
/// Each OR expression consists of two other sub-expressions.
/// </summary>
class Or : Expression
{
    /// <summary>
    /// Constructor for the OR expression class.
    /// Every 'OR' expression is made out of two other expressions. 'exp1 and exp2'.
    /// </summary>
    /// <param name="left_expression">The left expression. e1 || e2 => this is e1</param>
    /// <param name="right_expression">The right expression. e1 || e2 => this is e2</param>
    public Or(Expression? left_expression, Expression? right_expression) : base(left_expression, right_expression)
    {
    }

    /// <summary>
    /// Calculates the OR expression.
    /// This function returns a set of all the indexes of sentences that passed the filter condition.
    /// It calls the calculate function on both expressions and combines them.
    /// </summary>
    /// <param name="sentences_dictionary">The data. Contains for each word, what sentences have this word in them.</param>
    /// <returns>A set of all the indexes of sentences that passed the filter condition.</returns>
    public override HashSet<int> calculate(Dictionary<string, HashSet<int>> sentences_dictionary)
    {
        if (_left_expression == null || _right_expression == null) {
            return new HashSet<int>();
        }

        HashSet<int> leftSet = _left_expression.calculate(sentences_dictionary);
        HashSet<int> rightSet = _right_expression.calculate(sentences_dictionary);

        leftSet.UnionWith(rightSet);
        return leftSet;
    }
}